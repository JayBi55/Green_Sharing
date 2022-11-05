import { createRouter, createWebHistory } from 'vue-router'
import MainPageView from '@/views/MainPageView.vue'
import LogInView from '../views/LogInView.vue'


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

  ]
})

export default router
