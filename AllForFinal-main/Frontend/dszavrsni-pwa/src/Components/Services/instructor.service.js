import http from "../../http-common";


class instructorDataService {

  async get() {
    return await http.get('/Instructor');
  }

  async getByID(id) {
    return await http.get('instructor/' + id);
  }

  async delete(id) {
    const answer = await http.delete('/Instructor/' + id)
      .then(response => {
        return { ok: true, message: 'Succesfully deleted' };
      })
      .catch(e => {
        return { ok: false, message: e.response.data };
      });

    return answer;
  }


  async post(instructor) {
    //console.log(instructor);
    const answer = await http.post('/instructor', instructor)
      .then(response => {
        return { ok: true, message: 'Instructor added' };
      })
      .catch(error => {

        return { ok: false, message: error.response.data };
      });

    return answer;
  }

  async put(id, instructor) {

    const answer = await http.put('/instructor/' + id, instructor)
      .then(response => {
        return { ok: true, message: 'Instructor changed' };
      })
      .catch(error => {

        return { ok: false, message: error.response.data };
      });

    return answer;
  }

}

export default new instructorDataService();