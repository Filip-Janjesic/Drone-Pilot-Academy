import React, { Component } from "react";
import studentDataService from "../Services/student.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from "moment";

export default class addStudent extends Component {

  constructor(props) {
    super(props);
    this.addStudent = this.addStudent.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  async addStudent(student) {
    const answer = await studentDataService.post(student);
    if (answer.ok) {

      window.location.href = '/students';
    } else {
      // pokaži grešku
      console.log(answer);
    }
  }



  handleSubmit(e) {
    e.preventDefault();
    const datainfo = new FormData(e.target);
    console.log(datainfo.get('date'));
    console.log(datainfo.get('time'));
    let datetime = moment.utc(datainfo.get('date') + ' ' + datainfo.get('time'));
    console.log(datetime);

    this.addStudent({
      firsT_NAME: datainfo.get('firsT_NAME'),
      lasT_NAME: datainfo.get('lasT_NAME'),
      address: datainfo.get('address'),
      oib: datainfo.get('oib'),
      contacT_NUMBER: datainfo.get('contacT_NUMBER'),
      datE_OF_ENROLLMENT: datetime
    });

  }

  render() {
    return (
      <Container>
        <Form onSubmit={this.handleSubmit}>




          <Form.Group className="mb-3" controlId="firsT_NAME">
            <Form.Label>FIRST_NAME</Form.Label>
            <Form.Control type="text" name="firsT_NAME" placeholder="Anja" maxLength={255} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="lasT_NAME">
            <Form.Label>LAST_NAME</Form.Label>
            <Form.Control type="text" name="lasT_NAME" placeholder="Petakić" required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="address">
            <Form.Label>ADDRESS</Form.Label>
            <Form.Control type="text" name="address" placeholder="somewhat street " />
          </Form.Group>

          <Form.Group className="mb-3" controlId="oib">
            <Form.Label>OIB</Form.Label>
            <Form.Control type="text" name="oib" placeholder="" />
          </Form.Group>

          <Form.Group className="mb-3" controlId="contacT_NUMBER">
            <Form.Label>CONTACT_NUMBER</Form.Label>
            <Form.Control type="text" name="contacT_NUMBER" placeholder="99999999999" />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datE_OF_ENROLLMENT">
            <Form.Label>DATE_OF_ENROLLMENT</Form.Label>
            <Form.Control type="text" name="datE_OF_ENROLLMENT" placeholder="05.08.2023" />
          </Form.Group>


          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/students`}>Cancel</Link>
            </Col>
            <Col>
              <Button variant="primary" className="gumb" type="submit">
                Add Student
              </Button>
            </Col>
          </Row>


        </Form>



      </Container>
    );
  }
}

