import axios from 'axios'

const client = axios.create({
  baseURL: 'http://localhost:5000/api/SetupConnect',
  json: true
})

export default {
  async execute(method, resource, data) {  
    return client({
      method,
      url: resource,
      data,     
    }).then(req => {
      return req.data
    }).catch(err=>{console.log('err ', err)})
  },
  getAll() {
    return this.execute('getAll', '/')
  },
  create(data) {
    return this.execute('post', '/', data)
  },
  update(id, data) {
    return this.execute('put', `/${id}`, data)
  },
}