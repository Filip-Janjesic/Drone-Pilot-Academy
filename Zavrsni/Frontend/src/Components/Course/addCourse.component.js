import React, { Component } from "react";
import courseDataService from "../Services/course.service";
import instructorDataService from "../Services/instructor.service";
import vehicleDataService from "../Services/vehicle.service";
import categoryDataService from "../Services/category.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from 'moment';




export default class addCourse extends Component {

  constructor(props) {
    super(props);

    this.addCourse = this.addCourse.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.getCategories= this.getCategories.bind(this);
    this.getInstructors= this.getInstructors.bind(this);
    this.getDrones= this.getDrones.bind(this);
    this.state = {
      categories: [], 
      ID_CATEGORY:0,
      instructors:[],
      ID_INSTRUCTOR:0,
      drones:[],
      ID_DRONE:0,
      students:[]
    };
  }
 
  componentDidMount() {
  
    this.getCategories();
    this.getInstructors();
    this.getDrones();
    this.getStudents();
  }

  async addCourse(course) {
    const answer = await courseDataService.post(course);
    if(answer.ok){
     
      window.location.href='/courses';
    }else{
      
      console.log(answer);
    }
  }


  async getInstructors() {

    await instructorDataService.get()
      .then(response => {
        this.setState({
          instructors: response.data,
          ID_INSTRUCTOR: response.data[0].ID
        });

      })
      .catch(e => {
        console.log(e);
      });
  }

  async getDrones() {

    await droneDataService.get()
      .then(response => {
        this.setState({
          drones: response.data,
          ID_DRONE: response.data[0].ID
        });

      })
      .catch(e => {
        console.log(e);
      });
  }

  async getCategories() {

    await categoryDataService.get()
      .then(response => {
        this.setState({
          categories: response.data,
          ID_CATEGORY: response.data[0].ID
        });

      })
      .catch(e => {
        console.log(e);
      });
  }


  handleSubmit(e) {
    e.preventDefault();
    const dataInfo = new FormData(e.target);
    console.log(dataInfo.get('startDate'));
    console.log(dataInfo.get('Time'));
    let datetime = moment.utc(dataInfo.get('startDate') + ' ' + dataInfo.get('Time'));
    console.log(datetime);

    this.addCourse({
      startDate: datetime,
      ID_INSTRUCTOR:this.state.ID_INSTRUCTOR,
      ID_DRONE:this.state.ID_DRONE,
      ID_CATEGORY:this.state.ID_CATEGORY,
      
    });
    
  }


  render() { 
    const { instructors,drones,categories} = this.state; 
    return (
    <Container>
        <Form onSubmit={this.handleSubmit}>

         
        <Form.Group className="mb-3" controlId="DRONE">
            <Form.Label>DRONE</Form.Label>
            <Form.Select onChange={e => {
              this.setState({ droneID: e.target.value});
            }}>
            {drones && drones.map((drone,index) => (
                  <option key={index} value={drone.ID}>{drone.BRAND}</option>

            ))}
            </Form.Select>
          </Form.Group>

          <Form.Group className="mb-3" controlId="INSTRUCTOR">
            <Form.Label>INSTRUCTOR</Form.Label>
            <Form.Select onChange={e => {
              this.setState({ instructorID: e.target.value});
            }}>
            {instructors && instructors.map((instructor,index) => (
                  <option key={index} value={instructor.ID}>{instructor.NAME}</option>

            ))}
            </Form.Select>
          </Form.Group>

          <Form.Group className="mb-3" controlId="CATEGORY">
            <Form.Label>CATEGORY</Form.Label>
            <Form.Select onChange={e => {
              this.setState({ categoryID: e.target.value});
            }}>
            {categories && categories.map((category,index) => ( // sta je ovo
                  <option key={index} value={category.ID}>{category.NAME}</option>

            ))}
            </Form.Select>
          </Form.Group>




          <Form.Group className="mb-3" controlId="startDate">
            <Form.Label>startDate</Form.Label>
            <Form.Control type="date" name="startDate" placeholder=""  />
          </Form.Group>

          <Form.Group className="mb-3" controlId="TIME">
            <Form.Label>TIME</Form.Label>
            <Form.Control type="date" name="TIME" placeholder=""  />
          </Form.Group>
  



          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/courses`}>Cancel</Link>
            </Col>
            <Col>
            <Button variant="primary" className="gumb" type="submit">
              Add course
            </Button>
            </Col>
          </Row>
         
          
        </Form>


      
    </Container>
    );
  }
}

