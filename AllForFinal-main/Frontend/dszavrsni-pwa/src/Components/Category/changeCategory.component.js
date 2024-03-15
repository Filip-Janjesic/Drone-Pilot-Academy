import React, { Component } from "react";
import categoryDataService from "../Services/category.service";
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import { Link } from "react-router-dom";




export default class changeCategory extends Component {

  constructor(props) {
    super(props);

    this.category = this.getCategory();
    this.changeCategory = this.changeCategory.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);

    this.state = {
      category: {}
    };
  }


  async getCategory() {
    let href = window.location.href;
    let niz = href.split('/');
    await categoryDataService.getByID(niz[niz.length - 1])
      .then(response => {
        this.setState({
          category: response.data
        });

      })
      .catch(e => {
        console.log(e);
      });
  }

  async changeCategory(category) {

    let href = window.location.href;
    let niz = href.split('/');
    const answer = await categoryDataService.put(niz[niz.length - 1], category);
    if (answer.ok) {
      window.location.href = '/categories';
    } else {

      console.log(answer);
    }
  }

  handleSubmit(e) {

    e.preventDefault();

    const datainfo = new FormData(e.target);

    this.changeCategory({
      name: datainfo.get('name'),
      price: datainfo.get('price'),
      numbeR_OF_TR_LECTURES: datainfo.get('numbeR_OF_TR_LECTURES'),
      numbeR_OF_DRIVING_LECTURES: datainfo.get('numbeR_OF_DRIVING_LECTURES')
    });

  }


  render() {

    const { category } = this.state;

    return (
      <Container>
        <Form onSubmit={this.handleSubmit}>

          <Form.Group className="mb-3" controlId="name">
            <Form.Label>NAME</Form.Label>
            <Form.Control type="text" name="nsme" placeholder="category name" maxLength={255}
              defaultValue={category.name} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="price">
            <Form.Label>PRICE</Form.Label>
            <Form.Control type="decimal" name="price" placeholder="350.50"
              defaultValue={category.price} required />
          </Form.Group>


          <Form.Group className="mb-3" controlId="numbeR_OF_TR_LECTURES">
            <Form.Label>NUMBER_OF_TR_LECTURES</Form.Label>

            <Form.Control type="text" name="numbeR_OF_TR_LECTURES" placeholder="50"
              defaultValue={category.numbeR_OF_TR_LECTURES} required />
          </Form.Group>

          <Form.Group className="mb-3" controlId="numbeR_OF_DRIVING_LECTURES">
            <Form.Label>NUMBER_OF_DL</Form.Label>
            <Form.Control type="text" name="numbeR_OF_DRIVING_LECTURES" placeholder="50"
              defaultValue={category.numbeR_OF_DRIVING_LECTURES} required />
          </Form.Group>




          <Row>
            <Col>
              <Link className="btn btn-danger gumb" to={`/categories`}>Cancel</Link>
            </Col>
            <Col>
              <Button variant="primary" className="gumb" type="submit">
                CHANGE CATEGORY
              </Button>
            </Col>
          </Row>
        </Form>



      </Container>
    );
  }
}

