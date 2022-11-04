import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import BootstrapVue from "bootstrap-vue"
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap-vue/dist/bootstrap-vue.css"

import './assets/main.css'

const app = createApp(App)

app.use(createPinia())
app.use(router)
app.use(BootstrapVue)

app.mount('#app')
