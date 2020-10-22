import Vue from 'vue'
import Router from 'vue-router'
import Hello from '@/components/Hello'
import SetupConnect from '@/components/SetupConnect'


Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/setup-connect',
      name: 'SetupConnect',
      component: SetupConnect,
      meta: {
        requiresAuth: true
      }
    }]
})
