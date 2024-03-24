
import http from "../../http-common";

class courseDataService {
  getAll() {
    return http.get("/course");
  }

  async getByID(ID) {

    return await http.get('/course/' + ID);
  }

  async getStudents(ID) {

    return await http.get('/course/' + ID + '/students');
  }

  async getInstructors(ID) {

    return await http.get('/course/' + ID + '/instructors');
  }

  async getVehicles(ID) {

    return await http.get('/course/' + ID + '/vehicles');
  }

  async getCategories(ID) {

    return await http.get('/course/' + ID + '/categories');
  }

  async post(course) {

    const answer = await http.post('/course', course)
      .then(response => {
        return { ok: true, message: 'Course added' };
      })
      .catch(error => {
        console.log(error.response);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }



  async delete(ID) {

    const answer = await http.delete('/course/' + ID)
      .then(response => {
        return { ok: true, message: 'Succesfully deleted' };
      })
      .catch(error => {
        console.log(error);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }

  async deletestudent(course, student) {

    const answer = await http.delete('/course/' + course + '/delete/' + student)
      .then(response => {
        return { ok: true, message: 'Succesfully deleted' };
      })
      .catch(error => {
        console.log(error);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }

  async addStudent(course, student) {

    const answer = await http.post('/course/' + course + '/add/' + student)
      .then(response => {
        return { ok: true, message: 'Succesfully added' };
      })
      .catch(error => {
        console.log(error);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }

}

export default new courseDataService();