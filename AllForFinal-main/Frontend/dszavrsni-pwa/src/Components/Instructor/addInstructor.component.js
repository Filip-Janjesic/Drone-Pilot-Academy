import React, { Component } from "react";
import instructorDataService from "../Services/instructor.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";

export default class addInstructor extends Component {

    constructor(props) {
      super(props);
      this.addInstructor = this.addInstructor.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
    }
    async addInstructor(instructor) {
      const answer = await instructorDataService.post(instructor);
      if(answer.ok){
        
        window.location.href='/instructors';
      }else{
        
        console.log(answer);
      }
    }
  
  
  
    handleSubmit(e) {
      e.preventDefault();
      const datainfo = new FormData(e.target);
  
      this.addInstructor({
      firsT_NAME: datainfo.get('firsT_NAME'),
      lasT_NAME: datainfo.get('lasT_NAME'),
      driveR_LICENSE_NUMBER: datainfo.get('driveR_LICENSE_NUMBER'),
      email: datainfo.get("email"),
      contacT_NUMBER: datainfo.get('contacT_NUMBER'),
      });
      
    }

    render() { 
        return (
        <Container>
            <Form onSubmit={this.handleSubmit}>
    
            <Form.Group className="mb-3" controlId="first name">
                <Form.Label>FIRST_NAME</Form.Label>
                <Form.Control type="text" name="first name" placeholder="Petak" maxLength={30}/>
            </Form.Group>

            <Form.Group className="mb-3" controlId="last name">
                <Form.Label>LAST_NAME</Form.Label>
                <Form.Control type="text" name="last name" placeholder="Petakić"/>
            </Form.Group>

            <Form.Group className="mb-3" controlId="driver license number">
                <Form.Label>DRIVER_LICENSE_NUMBER</Form.Label>
                <Form.Control type="text" name="driver license number"placeholder="6546464 "/>
            </Form.Group>

            <Form.Group className="mb-3" controlId="email">
                <Form.Label>EMAIL</Form.Label>
                <Form.Control type="text" name="email" placeholder="abcd.pet@gmail.com"/>
            </Form.Group>

            <Form.Group className="mb-3" controlId="contact number">
                <Form.Label>CONTACT_NUMBER</Form.Label>
                <Form.Control type="text" name="contact number" placeholder="1234567890"/>
            </Form.Group>
        
              
            <Row>
                <Col>
                  <Link className="btn btn-danger gumb" to={`/instructors`}>Cancel</Link>
                </Col>
                <Col>
                <Button variant="primary" className="gumb" type="submit">
                  Add instructor
                </Button>
                </Col>
            </Row>
             
              
            </Form>
    
          
        </Container>
        );
    }
}
    
    