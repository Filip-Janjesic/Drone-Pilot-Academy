import React, { Component } from "react";
import instructorDataService from "../Services/instructor.service";
import { Button, Container, Table } from 'react-bootstrap';
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';

export default class Instructors extends Component {

  constructor(props) {
    super(props);
    //this.getInstructors = this.getInstructors.bind(this);

    this.state = {
      instructors: [],
    };
  }


  componentDidMount() {
    this.getInstructors();
  }
  async getInstructors() {
    await instructorDataService.get()
      .then(response => {
        this.setState({
          instructors: response.data
        });
        console.log(response.data);
      })
      .catch(e => {
        console.log(e);
      });
  }

  async deleteInstructor(id) {

    const answer = await instructorDataService.delete(id);
    if (answer.ok) {
      this.getInstructors();
    } else {

      alert(answer.message);
    }

  }

  render() {
    const { instructors } = this.state;
    return (

      <Container>
        <a href="/instructors/add" className="btn btn-success gumb">
          ADD NEW INSTRUCTOR
        </a>

        <Table striped bordered hover responsive>
          <thead>

            <tr>
              <th>FIRST_NAME</th>
              <th>LAST_NAME</th>
              <th>DRIVER_LICENSE_NUMBER</th>
              <th>EMAIL</th>
              <th>CONTACT_NUMBER</th>
              <th>Action</th>
            </tr>

          </thead>
          <tbody>
            {instructors && instructors.map((instructor, index) => (

              <tr key={index}>
                <td>{instructor.firsT_NAME}</td>

                <td>{instructor.lasT_NAME}</td>

                <td>{instructor.driveR_LICENSE_NUMBER}</td>

                <td>{instructor.email}</td>

                <td>{instructor.contacT_NUMBER}</td>

                <td>
                  <Link className="btn btn-primary gumb"
                    to={`/instructors/${instructor.id}`}>
                    <FaEdit />
                  </Link>

                  <Button variant="danger" className="gumb"
                    onClick={() => this.deleteInstructor(instructor.id)}>
                    <FaTrash />
                  </Button>
                </td>
              </tr>

            ))}
          </tbody>
        </Table>



      </Container>


    );

  }
}