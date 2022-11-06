import { createRouter, createWebHistory } from 'vue-router'
import MainPageView from '@/views/MainPageView.vue'
import LogInView from '../views/LogInView.vue'
import CreateEvent from '@/views/CreateEvent.vue'


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: MainPageView
    },
    {
      path: '/login',
      name: 'login',
      component: LogInView
    },
    {
      path: '/create-event',
      name: 'createEvent',
      component: CreateEvent
    },

  ]
})

export default router
