import React, { Component } from "react";
import vehicleDataService from "../Services/vehicle.service";
import studentDataService from "../Services/student.service";
import instructorDataService from "../Services/instructor.service";
import categoryDataService from "../Services/category.service";
import courseDataService from "../Services/course.service"; 

import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from 'moment';
import Table from 'react-bootstrap/Table';
import { FaTrash } from 'react-icons/fa';

import { AsyncTypeahead } from 'react-bootstrap-typeahead';


export default class ChangeCourse extends Component {

  constructor(props) {
    super(props);

  

    this.course = this.getcourse();
    this.changeCourse = this.changeCourse.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.vehicles = this.getVehicles();
    this.students = this.getStudents();
    this.instructors= this.getInstructors();
    this.category=this.getCategory();
    //ovo vidi jel ti treba
    this.obrisiStudent = this.deleteStudent.bind(this);
    this.searchStudent = this.searchStudent.bind(this);
    this.addStudent = this.addStudent.bind(this);


    this.state = {
      course: {},
      students: [],
      vehicles: [],
      instructors: [],
      categores: [],
      IDVehicle:0,
      IDCategory:0,
      IDInstructor:0, 
      foundStudents: []
    };
  }




  async getCourse() {
   
    let href = window.location.href;
    let niz = href.split('/'); 
    await courseDataService.getByID(niz[niz.length-1])
      .then(response => {
        let c = response.data;
        c.startTime = moment.utc(c.startTime).format("HH:mm");
        c.startDate = moment.utc(c.startDate).format("yyyy-MM-DD");
        
        this.setState({
          course: c
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  

  async changeCourse(course) {
    const answer = await courseDataService.post(course);
    if(answer.ok){

      window.location.href='/course';
    }else{
      console.log(answer);
    }
  }

  // pitaj profa jel da dohvacam sve 4 bindane veze na course
  // također za search i delete
  async getVehicles() {
    console.log('Getting vehicles');
    await vehicleDataService.get()
      .then(response => {
        this.setState({
          vehicles: response.data,
          IDVehicle: response.data[0].ID
        });

      })
      .catch(e => {
        console.log(e);
      });
  }
  async getInstructors() {
    console.log('Getting instructors');
    await instructorDataService.get()
      .then(response => {
        this.setState({
          instructors: response.data,
          IDInstructor: response.data[0].ID
        });

      })
      .catch(e => {
        console.log(e);
      });
  }

  async getCategories() {
    console.log('Getting categories');
    await categoryDataService.get()
      .then(response => {
        this.setState({
          categories: response.data,
          IDCategory: response.data[0].ID
        });

      })
      .catch(e => {
        console.log(e);
      });
  }

  
  async getStudents() {
    let href = window.location.href;
    let niz = href.split('/'); 
    await courseDataService.getStudents(niz[niz.length-1])
       .then(response => {
         this.setState({
           students: response.data
         });
       })
       .catch(e => {
         console.log(e);
       });
   }

   async searchStudent(condition) {

    await studentDataService.searchStudent(condition)
       .then(response => {
         this.setState({
          foundStudents: response.data
         });
       })
       .catch(e => {
         console.log(e);
       });
   }

   async addStudent(course, student){
    const answer = await courseDataService.addStudent(course, student);
    if(answer.ok){
     this.getStudents();
    }else{
    
    }
   }
 

  handleSubmit(e) {
    e.preventDefault();
    const datainfo = new FormData(e.target);
    console.log(datainfo.get('startDate'));
    console.log(datainfo.get('Time'));
    let DaTe = moment.utc(datainfo.get('startDate') + ' ' + datainfo.get('Time'));
    console.log("neam pojma");

    this.changeCourse({
      startDate: DaTe,
    });
    
  }


  render() { 
    const { students} = this.state;
    const { course} = this.state;
    const { instructors} = this.state;
    const {vehicles}=this.state;
    const {categories}=this.state;
    const { foundStudents} = this.state;


    const goSearch = (condition) => {
      this.searchStudent(condition);
    };

    const chosenstudent = (student) => {
      if(student.length>0){
        this.addStudent(course.ID, student[0].ID);
      }
     
    };

    return (
    <Container>
       
        <Form onSubmit={this.handleSubmit}>
          <Row>
          <Col key="1" sm={12} lg={6} md={6}>

              <Form.Group className="mb-3" controlId="instructor">
                <Form.Label>Instructor</Form.Label>
                <Form.Select defaultValue={course.IDInstructor}  onChange={e => {
                  this.setState({ IDInstructor: e.target.value});
                }}>
                {instructors && instructors.map((instructor,index) => (
                      <option key={index} value={instructor.ID}>{instructor.FIRST_NAME}</option>

                ))}
                </Form.Select>
              </Form.Group>

              <Form.Group className="mb-3" controlId="category">
                <Form.Label>Category</Form.Label>
                <Form.Select defaultValue={course.IDCategory}  onChange={e => {
                  this.setState({ IDCategory: e.target.value});
                }}>
                {categories && categories.map((category,index) => (
                      <option key={index} value={category.ID}>{category.NAME}</option>

                ))}
                </Form.Select>
              </Form.Group>

              <Form.Group className="mb-3" controlId="vehicle">
                <Form.Label>Vehicle</Form.Label>
                <Form.Select defaultValue={course.IDVehicle}  onChange={e => {
                  this.setState({ IDVehicle: e.target.value});
                }}>
                {vehicles && vehicles.map((vehicle,index) => (
                      <option key={index} value={vehicle.ID}>{vehicle.BRAND}</option>

                ))}
                </Form.Select>
              </Form.Group>

              <Form.Group className="mb-3" controlId="student">
                <Form.Label>Student</Form.Label>
                <Form.Select defaultValue={course.IDStudent}  onChange={e => {
                  this.setState({ IDStudent: e.target.value});
                }}>
                {instructors && instructors.map((student,index) => (
                      <option key={index} value={student.ID}/>

                ))}
                </Form.Select>
              </Form.Group>

              <Form.Group className="mb-3" controlId="startDate">
                <Form.Label>Start Date</Form.Label>
                <Form.Control type="date" name="startDate" placeholder="" defaultValue={course.startDate}  />
              </Form.Group>

              <Form.Group className="mb-3" controlId="vrijeme">
                <Form.Label>Vrijeme</Form.Label>
                <Form.Control type="time" name="vrijeme" placeholder="" defaultValue={course.startTime}  />
              </Form.Group>

            



              <Row>
                <Col>
                  <Link className="btn btn-danger gumb" to={`/grupe`}>Cancel</Link>
                </Col>
                <Col>
                <Button variant="primary" className="gumb" type="submit">
                  Change Course 
                </Button>
                </Col>
              </Row>
          </Col>
          <Col key="2" sm={12} lg={6} md={6} className="studentsCourse">
          <Form.Group className="mb-3" controlId="condition">
                <Form.Label>Search student/students</Form.Label>
                
          <AsyncTypeahead
            className="autocomplete"
            id="condition"
            emptyLabel="No results"
            searchText="Search..."
            labelKey={(student) => `${student.LAST_NAME } ${student.FIRST_NAME}`}
            minLength={3}
            options={foundStudents}
            onSearch={goSearch}
            placeholder="First or last name"
            renderMenuItemChildren={(student) => (
              <>
                <span>{student.LAST_NAME} {student.FIRST_NAME}</span>
              </>
            )}
            onChange={chosenstudent}
          />
          </Form.Group>
          <Table striped bordered hover responsive>
              <thead>
                <tr>
                  <th>Student</th>
                  <th>Action</th>
                </tr>
              </thead>
              <tbody>
              {students && students.map((student,index) => (
                
                <tr key={index}>
                  <td > {student.FIRST_NAME} {student.LAST_NAME}</td>
                  <td>
                  <Button variant="danger"   onClick={() => this.deleteStudent(course.ID, student.ID)}><FaTrash /></Button>
                    
                  </td>
                </tr>
                ))
              }
              </tbody>
            </Table>    
          </Col>
          </Row>

          
         
          
        </Form>


      
    </Container>
    );
  }
}

