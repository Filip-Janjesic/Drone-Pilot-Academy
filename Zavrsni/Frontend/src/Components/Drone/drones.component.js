import React, { Component } from "react";
import droneDataService from "../Services/drone.service";
import { Button, Container, Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';


export default class Drones extends Component {
    constructor(props) {
      super(props);
      this.state = {
        drones: [],
      };
    }
    
    componentDidMount() {
        this.getDrones();
      }
     async getDrones(){
        await droneDataService.get() 
          .then(response => {
            this.setState({
              drones: response.data
            });
          })
          .catch(e => {
            console.log(e);
          });
      }

      async deleteDrone(id){
    
        const answer = await droneDataService.delete(id);
        if(answer.ok){
         this.getDrones();
        }else{
          alert(answer.message);
        }
        
      }


       render() {
        const {drones} = this.state;
        return (
    
        <Container>
          <a href="/drones/add" className="btn btn-success gumb">
            Add new drone
            </a>

            <Table striped bordered hover responsive>
                <thead>
                    <tr>
                        <th>TYPE</th>
                        <th>BRAND</th>
                        <th>MODEL</th>
                        <th>PURCHASE_DATE</th>
                        <th>DATE_OF_REGISTRATION</th>
                        <th>ACTION</th>

                    </tr>
                </thead>
                <tbody>
                   { drones && drones.map((drone,id)=> (

                    <tr key={id}>
                         
                        <td>{drone.type}</td>
                        <td>{drone.brand}</td>
                        <td>{drone.purchasE_DATE}</td>
                        <td>{drone.datE_OF_REGISTRATION}</td>

                        <td>
                            <Link className="btn btn-primary gumb"
                            to={`/drones/${drone.id}`}>
                                <FaEdit />
                            </Link>

                            <Button variant="danger" className="gumb"
                            onClick={()=>this.deleteDrone(drone.id)}>
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
