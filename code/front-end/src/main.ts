import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
//import * as VueGoogleMaps from 'vue2-google-maps'
import router from './router'
import "bootstrap/dist/css/bootstrap.min.css"
import './assets/main.css'



const app = createApp(App)

app.use(createPinia())
app.use(router)
app.mount('#appl')

import "bootstrap/dist/js/bootstrap.js"
