import React, { Component } from "react";
import categoryDataService from "../Services/category.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";


export default class addCategory extends Component {

  constructor(props) {
    super(props);

    this.addCategory = this.addCategory.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }
  async addCategory(category) {
    const answer = await categoryDataService.post(category);
    if (answer.ok) {

      window.location.href = '/categories';
    } else {

      console.log(answer);
    }
  }


  handleSubmit(e) {
    e.preventDefault();


    const datainfo = new FormData(e.target);

    this.addCategory({
      name: datainfo.get('name'),
      price: parseFloat(datainfo.get('price')),
      numbeR_OF_TR_LECTURES: parseInt(datainfo.get('numbeR_OF_TR_LECTURES')),
      numbeR_OF_DRIVING_LECTURES: parseInt(datainfo.get('numbeR_OF_DRIVING_LECTURES'))
    });

  }

  render() {
    return (
      <Container>
        <Form onSubmit={this.handleSubmit}>


          <Form.Group className="mb-3" controlId="name">
            <Form.Label>NAME</Form.Label>
            <Form.Control type="text" name="name" placeholder="something" maxLength={255} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="price">
            <Form.Label>PRICE</Form.Label>
            <Form.Control type="text" name="price" placeholder="350.50" required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="number of tr lectures">
            <Form.Label>NUMBER_OF_TR_LECTURES</Form.Label>
            <Form.Control type="text" name="number of tr lectures" placeholder="50" required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="number of driving lectures">
            <Form.Label>NUMBER_OF_DRIVING_LECTURES</Form.Label>
            <Form.Control type="text" name="number of driving lectures" placeholder="50" required />
          </Form.Group>



          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/categories`}>Cancel</Link>
            </Col>
            <Col>
              <Button variant="primary" className="gumb" type="submit">
                Add Category
              </Button>
            </Col>
          </Row>


        </Form>



      </Container>
    );
  }
}

