import React, { Component } from "react";
import vehicleDataService from "../Services/vehicle.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from "moment";

export default class addVehicle extends Component {

  constructor(props) {
    super(props);
    this.addVehicle = this.addVehicle.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  async addVehicle(vehicle) {
    const answer = await vehicleDataService.post(vehicle);
    if (answer.ok) {
      window.location.href = '/vehicles';
    } else {
      console.log(answer);
    }
  } // mislim da fali ruta za dodavanje u corse



  handleSubmit(e) {
    e.preventDefault();
    const datainfo = new FormData(e.target);
    console.log(datainfo.get('date'));
    console.log(datainfo.get('time'));
    let datetime = moment.utc(datainfo.get('date') + ' ' + datainfo.get('time'));
    console.log(datetime);

    this.addVehicle({
      type: datainfo.get('type'),
      brand: datainfo.get('brand'),
      model: datainfo.get('model'),
      purchasE_DATE: datetime,
      datE_OF_REGISTRATION: datetime
    });

  }

  render() {
    return (
      <Container>
        <Form onSubmit={this.handleSubmit}>

          <Form.Group className="mb-3" controlId="type">
            <Form.Label>TYPE</Form.Label>
            <Form.Control type="text" name="type" placeholder="karavan" maxLength={50} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="brand">
            <Form.Label>BRAND</Form.Label>
            <Form.Control type="text" name="brand" placeholder="310B" />
          </Form.Group>


          <Form.Group className="mb-3" controlId="model">
            <Form.Label>MODEL</Form.Label>
            <Form.Control type="text" name="model" placeholder="50-1" />
          </Form.Group>

          <Form.Group className="mb-3" controlId="startdate">
            <Form.Label>PURCHASE_DATE</Form.Label>
            <Form.Control type="date" name="startdate" placeholder=" " required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="startdate">
            <Form.Label>DATE_OF_REGISTRATION</Form.Label>
            <Form.Control type="date" name="startdate" placeholder=" " required />
          </Form.Group>


          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/vehicles`}>Cancel</Link>
            </Col>
            <Col>
              <Button variant="primary" className="gumb" type="submit">
                Add vehicle
              </Button>
            </Col>
          </Row>


        </Form>


      </Container>
    );
  }
}

