import React, { Component } from "react";
import droneDataService from "../Services/drone.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";
import moment from "moment";



export default class changeDrone extends Component {

  constructor(props) {
    super(props);

    this.drone = this.getDrone();
    this.changeDrone = this.changeDrone.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);

    this.state = {
      drone: {}
    };
  }


  async getDrone() {

    let href = window.location.href;
    let niz = href.split('/');
    await droneDataService.getByID(niz[niz.length - 1])
      .then(response => {
        this.setState({
          drone: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  async changeDrone(drone) {

    let href = window.location.href;
    let niz = href.split('/');
    const answer = await droneDataService.put(niz[niz.length - 1], drone);
    if (answer.ok) {
      window.location.href = '/drones';
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

    this.changeDrone({
      type: datainfo.get('type'),
      brand: datainfo.get('brand'),
      model: datainfo.get('model'),
      purchasE_DATE: datetime,
      datE_OF_REGISTRATION: datetime
    });

  }


  render() {

    const { drone } = this.state;
    return (
      <Container>
        <Form onSubmit={this.handleSubmit}>

          <Form.Group className="mb-3" controlId="type">
            <Form.Label>TYPE</Form.Label>
            <Form.Control type="text" name="type" placeholder="karavan"
              maxLength={50} defaultValue={drone.type} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="brand">
            <Form.Label>BRAND</Form.Label>
            <Form.Control type="text" name="brand"
              defaultValue={drone.brand} placeholder="310B" />
          </Form.Group>


          <Form.Group className="mb-3" controlId="model">
            <Form.Label>MODEL</Form.Label>
            <Form.Control type="text" name="model"
              defaultValue={drone.model} placeholder="50-1" />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datetime">
            <Form.Label>PURCHASE_DATE</Form.Label>
            <Form.Control type="date" name="datetime" placeholder=""
              defaultValue={drone.purchasE_DATE} required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="datetime">
            <Form.Label>DATE_OF_REGISTRATION</Form.Label>
            <Form.Control type="date" name="datetime" placeholder=" "
              defaultValue={drone.datE_OF_REGISTRATION} required />
          </Form.Group>



          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/drones`}>Cancel</Link>
            </Col>
            <Col>
              <Button variant="primary" className="gumb" type="submit">
                Change drone
              </Button>
            </Col>
          </Row>
        </Form>



      </Container>
    );
  }
}

