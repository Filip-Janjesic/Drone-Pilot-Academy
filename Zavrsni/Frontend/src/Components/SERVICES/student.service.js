import http from '../../http-common';

class studentDataService {
  async get() {
    return await http.get('/student');
  }

  async getByID(id) {
    return await http.get('/student/' + id);
  }

  async post(student) {
    const answer = await http.post('/student', student)
      .then(response => {
        return { ok: true, message: 'Student added' };
      })
      .catch(error => {
        console.log(error.response);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }

  async put(id, student) {
    const answer = await http.put('/student/' + id, student)
      .then(response => {
        return { ok: true, message: 'Student changed' };
      })
      .catch(error => {
        console.log(error.response);
        return { ok: false, poruka: error.response.data };
      });

    return answer;
  }


  async delete(id) {

    const answer = await http.delete('/student/' + id)
      .then(response => {
        return { ok: true, message: 'Succesfully deleted student' };
      })
      .catch(error => {
        console.log(error);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }





}

export default new studentDataService();