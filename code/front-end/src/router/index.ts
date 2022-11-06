import { createRouter, createWebHistory } from 'vue-router'
import MainPageView from '@/views/MainPageView.vue'
import LogInView from '../views/LogInView.vue'
import GoogleMap from '../views/GoogleMap.vue'


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
      path: '/',
      name: 'Map',
      component: GoogleMap
    },

  ]
})

export default router
