import React, { Component } from "react";
import studentDataService from "../Services/student.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from "moment";




export default class changestudent extends Component {

  constructor(props) {
    super(props);

    this.student = this.getStudent();
    this.changeStudent = this.changeStudent.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);




    this.state = {
      student: {}
    };
  }


  async getStudent() {

    let href = window.location.href;
    let niz = href.split('/');
    await studentDataService.getByID(niz[niz.length - 1])
      .then(response => {
        this.setState({
          student: response.data
        });

      })
      .catch(e => {
        console.log(e);
      });
  }

  async changeStudent(student) {

    let href = window.location.href;
    let niz = href.split('/');
    const answer = await studentDataService.put(niz[niz.length - 1], student);
    if (answer.ok) {
      window.location.href = '/students';
    } else {

      console.log(answer);
    }
  }


  handleSubmit(e) {

    e.preventDefault();


    const datainfo = new FormData(e.target);
    console.log(datainfo.get('datE_OF_ENROLLMENT'));
    console.log(datainfo.get('time'));
    let datE_OF_ENROLLMENT = moment.utc(datainfo.get('datE_OF_ENROLLMENT') + ' ' + datainfo.get('time'));
    console.log(datE_OF_ENROLLMENT);

    this.changeStudent({

      firsT_NAME: datainfo.get('firsT_NAME'),
      lasT_NAME: datainfo.get('lasT_NAME'),
      ADDRESS: datainfo.get('address'),
      oib: datainfo.get('oib'),
      contacT_NUMBER: datainfo.get('contacT_NUMBER'),
      datE_OF_ENROLLMENT: datE_OF_ENROLLMENT
    });

  }


  render() {

    const { student } = this.state;

    return (
      <Container>
        <Form onSubmit={this.handleSubmit}>

          <Form.Group className="mb-3" controlId="firsT_NAME">
            <Form.Label>FIRST_NAME</Form.Label>
            <Form.Control type="text" name="firsT_NAME" placeholder="Anja" maxLength={30}
              defaultValue={student.firsT_NAME} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="lasT_NAME">
            <Form.Label>LAST_NAME</Form.Label>
            <Form.Control type="text" name="lasT_NAME" placeholder="Petakić"
              defaultValue={student.lasT_NAME} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="address">
            <Form.Label>ADDRESS</Form.Label>
            <Form.Control type="text" name="address" placeholder="somewhat street "
              defaultValue={student.address} required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="oib">
            <Form.Label>OIB</Form.Label>
            <Form.Control type="text" name="oib" placeholder="" required
              defaultValue={student.oib} />
          </Form.Group>

          <Form.Group className="mb-3" controlId="contacT_NUMBER">
            <Form.Label>CONTACT_NUMBER</Form.Label>
            <Form.Control type="text" name="contacT_NUMBER" placeholder="99999999999" required
              defaultValue={student.contacT_NUMBER} />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datE_OF_ENROLLMENT">
            <Form.Label>DATE_OF_ENROLLMENT</Form.Label>
            <Form.Control type="date" name="datE_OF_ENROLLMENT" placeholder="" required
              defaultValue={student.datE_OF_ENROLLMENT} />
          </Form.Group>

          <Form.Group className="mb-3" controlId="time">
            <Form.Label>TIME</Form.Label>
            <Form.Control type="time" name="time" placeholder="" defaultValue={student.time} />
          </Form.Group>


          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/students`}>Cancel</Link>
            </Col>
            <Col>
              <Button variant="primary" className="gumb" type="submit">
                Change student
              </Button>
            </Col>
          </Row>
        </Form>



      </Container>
    );
  }
}

