import React, { Component } from "react";
import studentDataService from "../Services/student.service";
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Card from 'react-bootstrap/Card';
import Button from 'react-bootstrap/Button';
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';
import { Modal } from 'react-bootstrap';


export default class Students extends Component {
  constructor(props) {
    super(props);

    this.getStudents = this.getStudents.bind(this);

    this.state = {
      students: [],
      showModal: false
    };
  }



  openModal = () => this.setState({ showModal: true });
  closeModal = () => this.setState({ showModal: false });

  componentDidMount() {
    this.getStudents();
  }
  getStudents() {
    studentDataService.get()
      .then(response => {

        this.setState({
          students: response.data
        });
      })
      .catch(e => {
        console.log(e);
      });
  }

  async deleteStudent(id) {

    const answer = await studentDataService.delete(id);
    if (answer.ok) {
      this.getStudents();
    } else {
      this.openModal();
    }

  }

  render() {
    const { students } = this.state;
    return (

      <Container>
        <a href="/students/add" className="btn btn-success gumb">Add new student</a>
        <Row>
          {students && students.map((s) => (

            <Col key={s.id} sm={10} lg={3} md={3}>

              <Card style={{ width: '18rem' }}>
                <Card.Body>
                  <Card.Title>{s.firsT_NAME} {s.lasT_NAME}</Card.Title>
                  <Card.Text>
                    {s.address} {s.oib} {s.contacT_NUMBER} {s.datE_OF_ENROLLMENT}
                  </Card.Text>
                  <Row>
                    <Col>
                      <Link className="btn btn-primary gumb" to={`/students/${s.id}`}><FaEdit /></Link>
                    </Col>
                    <Col>
                      <Button variant="danger" className="gumb" onClick={() => this.deleteStudent(s.id)}><FaTrash /></Button>
                    </Col>
                  </Row>
                </Card.Body>
              </Card>
            </Col>
          ))
          }
        </Row>

        <Modal show={this.state.showModal} onHide={this.closeModal}>
          <Modal.Header closeButton>
            <Modal.Title>There has been an error while executing delete action</Modal.Title>
          </Modal.Header>
          <Modal.Body>Bla bla</Modal.Body>
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
