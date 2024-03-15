import React, { Component } from "react";
import vehicleDataService from "../Services/vehicle.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from "moment";



export default class changeVehicle extends Component {

  constructor(props) {
    super(props);

    this.vehicle = this.getVehicle();
    this.changeVehicle = this.changeVehicle.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);

    this.state = {
      vehicle: {}
    };
  }


  async getVehicle() {

    let href = window.location.href;
    let niz = href.split('/');
    await vehicleDataService.getByID(niz[niz.length - 1])
      .then(response => {
        this.setState({
          vehicle: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  async changeVehicle(vehicle) {

    let href = window.location.href;
    let niz = href.split('/');
    const answer = await vehicleDataService.put(niz[niz.length - 1], vehicle);
    if (answer.ok) {
      window.location.href = '/vehicles';
    } else {

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

    this.changeVehicle({
      type: datainfo.get('type'),
      brand: datainfo.get('brand'),
      model: datainfo.get('model'),
      purchasE_DATE: datetime,
      datE_OF_REGISTRATION: datetime
    });

  }


  render() {

    const { vehicle } = this.state;
    return (
      <Container>
        <Form onSubmit={this.handleSubmit}>

          <Form.Group className="mb-3" controlId="type">
            <Form.Label>TYPE</Form.Label>
            <Form.Control type="text" name="type" placeholder="karavan"
              maxLength={50} defaultValue={vehicle.type} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="brand">
            <Form.Label>BRAND</Form.Label>
            <Form.Control type="text" name="brand"
              defaultValue={vehicle.brand} placeholder="310B" />
          </Form.Group>


          <Form.Group className="mb-3" controlId="model">
            <Form.Label>MODEL</Form.Label>
            <Form.Control type="text" name="model"
              defaultValue={vehicle.model} placeholder="50-1" />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datetime">
            <Form.Label>PURCHASE_DATE</Form.Label>
            <Form.Control type="date" name="datetime" placeholder=""
              defaultValue={vehicle.purchasE_DATE} required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datetime">
            <Form.Label>DATE_OF_REGISTRATION</Form.Label>
            <Form.Control type="date" name="datetime" placeholder=" "
              defaultValue={vehicle.datE_OF_REGISTRATION} required />
          </Form.Group>



          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/vehicles`}>Cancel</Link>
            </Col>
            <Col>
              <Button variant="primary" className="gumb" type="submit">
                Change vehicle
              </Button>
            </Col>
          </Row>
        </Form>



      </Container>
    );
  }
}

