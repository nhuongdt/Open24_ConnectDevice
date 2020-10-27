import axios from 'axios'


const client = axios.create({
  baseURL: 'http://localhost:5000/Open24_ConnectDevice/api/SetupConnect',
  json: true
})

export default {
  async execute(method, resource, data) {  
    return client({
      method,
      url: resource,
      data,     
      // headers:{
      //   "Content-Type": "application/json"
      // }
    }).then(req => {
      return req.data
    }).catch(err=>{console.log('err ', err)})
  },
  getAll() {   
//     fetch("http://localhost:5000/api/SetupConnect/GetAll", {
//     "headers": {
//       "accept": "application/json, text/plain, */*",
//       "accept-language": "vi",
//       "cache-control": "no-cache",
//       "pragma": "no-cache",
//       "sec-fetch-dest": "empty",
//       "sec-fetch-mode": "cors",
//       "sec-fetch-site": "same-origin"
//     },
//     "referrer": "http://localhost:5000/",
//     "referrerPolicy": "no-referrer-when-downgrade",
//     "body": null,
//     "method": "get",
//     "mode": "cors",
//     "credentials": "include"
// }).then(req=>{
//   console.log('req ', req)
// })
   return this.execute('Get', '/')
  },
  create(data) {
    return this.execute('post', '/', data)
  },
  update(id, data) {
    return this.execute('put', `/${id}`, data)
  },
}