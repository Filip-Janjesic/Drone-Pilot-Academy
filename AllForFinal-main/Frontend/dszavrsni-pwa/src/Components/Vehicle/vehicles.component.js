import React, { Component } from "react";
import vehicleDataService from "../Services/vehicle.service";
import { Button, Container, Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import { FaEdit } from 'react-icons/fa';
import { FaTrash } from 'react-icons/fa';


export default class Vehicles extends Component {
    constructor(props) {
      super(props);
      //this.getVehicles= this.getVehicles.bind(this);
      
      this.state = {
        vehicles: [],
      };
    }
    
    componentDidMount() {
        this.getVehicles();
      }
     async getVehicles(){
        await vehicleDataService.get() 
          .then(response => {
            this.setState({
              vehicles: response.data
            });
          })
          .catch(e => {
            console.log(e);
          });
      }

      async deleteVehicle(id){
    
        const answer = await vehicleDataService.delete(id);
        if(answer.ok){
         this.getVehicles();
        }else{
          alert(answer.message);
        }
        
      }


       render() {
        const {vehicles} = this.state;
        return (
    
        <Container>
          <a href="/vehicles/add" className="btn btn-success gumb">
            Add new vehicle
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
                   { vehicles && vehicles.map((vehicle,id)=> (

                    <tr key={id}>
                         
                        <td>{vehicle.type}</td>
                        <td>{vehicle.brand}</td>
                        <td>{vehicle.purchasE_DATE}</td>
                        <td>{vehicle.datE_OF_REGISTRATION}</td>

                        <td>
                            <Link className="btn btn-primary gumb"
                            to={`/vehicles/${vehicle.id}`}>
                                <FaEdit />
                            </Link>

                            <Button variant="danger" className="gumb"
                            onClick={()=>this.deleteVehicle(vehicle.id)}>
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
