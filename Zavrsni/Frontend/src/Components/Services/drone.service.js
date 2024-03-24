import http from "../../http-common";


class droneDataService {

  async get() {
    return await http.get('/Drone');
  }

  async getByID(id) {
    return await http.get('/drone/' + id);
  }

  async delete(id) {
    const answer = await http.delete('/Drone/' + id)
      .then(response => {
        return { ok: true, message: 'Succesfully deleted' };
      })
      .catch(e => {
        return { ok: false, message: e.response.data };
      });

    return answer;
  }

  async post(drone) {

    const answer = await http.post('/drone', drone)
      .then(response => {
        return { ok: true, message: 'Drone added' };
      })
      .catch(error => {

        return { ok: false, message: error.response.data };
      });

    return answer;
  }

  async put(id, F) {

    const answer = await http.put('/Drone/' + id, drone)
      .then(response => {
        return { ok: true, message: 'Drone changed' };
      })
      .catch(error => {

        return { ok: false, message: error.response.data };
      });

    return answer;
  }

}

export default new droneDataService();