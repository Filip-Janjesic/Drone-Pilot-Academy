import React, { Component } from "react";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import NavDropdown from 'react-bootstrap/NavDropdown';

import logo from '../logo.svg';

export default class MainMenu extends Component {


  render() {
    return (

      <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
          {/* <Navbar.Brand href="/"><img src={logo} className="App-logo" alt="logo" /> DS START</Navbar.Brand> */}
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="Tu isto nesto">
              <NavDropdown title="Select" id="basic-nav-dropdown">

                <NavDropdown.Item href="/vehicles">Vehicles</NavDropdown.Item>


                <NavDropdown.Item href="/students">Students</NavDropdown.Item>


                <NavDropdown.Item href="/instructors">Instructors</NavDropdown.Item>


                <NavDropdown.Item href="/categories">Categories</NavDropdown.Item>


                <NavDropdown.Item href="/courses">Courses</NavDropdown.Item>


                <NavDropdown.Divider />
                <NavDropdown.Item target="_blank" href="/swagger/index.html">
                  Swagger
                </NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>



    );
  }
}
