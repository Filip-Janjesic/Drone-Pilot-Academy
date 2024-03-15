import React from 'react';
import './App.css';
import MainMenu from './Components/MainMenu.component'; 
import MainPage from './Components/MainPage.component';
import AddCategory from './Components/Category/addCategory.component';
import Categories from './Components/Category/categories.component';
import ChangeCategory from './Components/Category/changeCategory.component';
import AddInstructor from './Components/Instructor/addInstructor.component';
import ChangeInstructor from './Components/Instructor/changeInstructor.component';
import Instructors from './Components/Instructor/instructors.component';
import AddStudent from './Components/Student/addStudent.component';
import ChangeStudent from './Components/Student/changeStudent.component';
import Students from './Components/Student/students.component';
import AddVehicle from './Components/Vehicle/addVehicle.component';
import ChangeVehicle from './Components/Vehicle/changeVehicle.component';
import Vehicles from './Components/Vehicle/vehicles.component';
import Courses from './Components/Course/courses.component';
import ChangeCourse from './Components/Course/changeCourse.component';
import AddCourse from './Components/Course/addCourse.component';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';


export default function App() {
  return (
    <Router>
      <MainMenu />
      <Routes>
        <Route path= '/' element={<MainPage />} />
        <Route path= "/Categories/add" element={<AddCategory />} />
        <Route path= "/Categories" element= {<Categories />} />
        <Route path= "/Categories/:ID" element={<ChangeCategory />} /> 
        <Route path= "/Instructors" element={<Instructors />} />
        <Route path= "/Instructors/add" element={<AddInstructor />} />
        <Route path= "/Instructors/:ID" element={<ChangeInstructor />} />
        <Route path= '/Students' element={<Students />} />
        <Route path= "/Student/add" element={<AddStudent />} />
        <Route path= "/Students/:ID" element={<ChangeStudent />} />
        <Route path= "/Vehicles" element={<Vehicles />} />
        <Route path= "/Vehicles/add" element={<AddVehicle />} />
        <Route path= "/Vehicles/:ID" element={<ChangeVehicle />} />
        <Route path= '/Courses' element={<Courses/>}/>
        <Route path= "/Courses/add" element={<AddCourse/>}/>
        <Route path= "/Courses/:ID" element={<ChangeCourse/>}/>


      </Routes>
    </Router>
  );
}


