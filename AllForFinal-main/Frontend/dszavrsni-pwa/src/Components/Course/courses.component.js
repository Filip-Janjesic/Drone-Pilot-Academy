import React, { Component } from "react";
import courseDataService from "../Services/course.service";
import studentDataService from "../Services/student.service";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table';
import Button from 'react-bootstrap/Button';
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';
import moment from 'moment';
import { Modal } from 'react-bootstrap';


export default class Courses extends Component {
  constructor(props) {
    super(props);
    this.getCourses = this.getCourses.bind(this);

    this.state = {
      courses: [],
      showModal: false
    };
  }

  openModal = () => this.setState({ showModal: true });
  closeModal = () => this.setState({ showModal: false });


  componentDidMount() {
    this.getCourses();
  }

  async getCourses() {
    courseDataService.getAll()
      .then(response => {
        this.setState({
          courses: response.data
        });
        console.log(response);
      })
      .catch(e => {
        console.log(e);
      });
  }

  async deleteCourse(ID) {

    const answer = await courseDataService.delete(ID);
    if (answer.ok) {
      this.getCourses();
    } else {
      this.openModal();
    }

  }

  render() {
    const { courses } = this.state;
    return (


      //nezz jel idu i kljucevi vamo ili ne


      <Container>
        <a href="/courses/add" className="btn btn-success gumb">  ADD NEW COURSE  </a>
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>Start date</th>
              <th>Number of students</th>
              <th>Action</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {courses && courses.map((c, index) => (

              <tr key={index}>
                <td>
                  <p className="course">{c.name} ({c.startDate})</p>
                  {c.idVehicle} {c.idInstructor} {c.idCategory}
                </td>
                <td className="course">
                  {c.startDate == null ? "Start date and time are not defined" :
                    moment.utc(c.startDate).format("DD. MM. YYYY. HH:mm")}
                </td>
                <td>
                  <Row>
                    <Col>
                      <Link className="btn btn-primary gumb" to={`/courses/${c.id}`}><FaEdit /></Link>
                    </Col>
                    <Col>
                      {
                        <Button variant="danger" className="gumb" onClick={() => this.deleteCourse(c.id)}><FaTrash /></Button>
                      }
                    </Col>
                  </Row>

                </td>
              </tr>
            ))
            }
          </tbody>
        </Table>

        <Modal show={this.state.showModal} onHide={this.closeModal}>
          <Modal.Header closeButton>
            <Modal.Title>Error has occured while deleting</Modal.Title>
          </Modal.Header>
          <Modal.Footer>
            <Button variant="secondary" onClick={this.closeModal}>
              Close
            </Button>
          </Modal.Footer>
        </Modal>

      </Container>


    );

  }
}
