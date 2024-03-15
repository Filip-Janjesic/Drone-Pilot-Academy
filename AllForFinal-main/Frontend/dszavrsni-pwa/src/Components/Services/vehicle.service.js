import http from "../../http-common";


class vehicleDataService {

  async get() {
    return await http.get('/Vehicle');
  }

  async getByID(id) {
    return await http.get('/cehicle/' + id);
  }

  async delete(id) {
    const answer = await http.delete('/Vehicle/' + id)
      .then(response => {
        return { ok: true, message: 'Succesfully deleted' };
      })
      .catch(e => {
        return { ok: false, message: e.response.data };
      });

    return answer;
  }

  async post(vehicle) {

    const answer = await http.post('/vehicle', vehicle)
      .then(response => {
        return { ok: true, message: 'Vehicle added' };
      })
      .catch(error => {

        return { ok: false, message: error.response.data };
      });

    return answer;
  }

  async put(id, vehicle) {

    const answer = await http.put('/Vehicle/' + id, vehicle)
      .then(response => {
        return { ok: true, message: 'Vehicle changed' };
      })
      .catch(error => {

        return { ok: false, message: error.response.data };
      });

    return answer;
  }

}

export default new vehicleDataService();