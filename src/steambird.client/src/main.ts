import './assets/main.css'

import { createApp } from 'vue'
import { createMemoryHistory, createRouter, createWebHashHistory, createWebHistory } from 'vue-router'
import App from './App.vue'

import Home from './Home.vue'
import Post from './components/Post.vue'

const test = {template: "<p>This is test</p>"}

const routes = [
    {path: '/', component: Home},
    {path: '/:date/:slug', component: Post, props: true}
]

const router = createRouter({
    history: createWebHistory(),
    routes: routes,
})

createApp(App)
    .use(router)
    .mount('#app')
