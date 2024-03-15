import http from '../../http-common';


class categoryDataService {
  async get() {
    return await http.get('/Category');
  }

  async getByID(id) {
    return await http.get('/category/' + id);
  }

  async delete(id) {
    const answer = await http.delete('/Category/' + id)
      .then(response => {
        return { ok: true, message: 'Succesfully deleted' };
      })
      .catch(e => {
        return { ok: false, message: e.response.data };
      });

    return answer;
  }


  async post(category) {

    const answer = await http.post('/category', category)
      .then(response => {
        return { ok: true, message: 'Category added' };
      })
      .catch(error => {
        console.log(error.response);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }

  async put(id, category) {
    const answer = await http.put('/category/' + id, category)
      .then(response => {
        return { ok: true, message: 'Category changed' };
      })
      .catch(error => {
        console.log(error.response);
        return { ok: false, message: error.response.data };
      });

    return answer;
  }

}

export default new categoryDataService();