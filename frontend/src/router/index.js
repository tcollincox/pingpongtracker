import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import PlayerStats from '../views/PlayerStats.vue'
import AddGame from '../views/AddGame.vue'
import AddPlayer from '../views/AddPlayer.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/playerStats',
    name: 'PlayerStats',
    component: PlayerStats
  },
  {
    path: '/addGame',
    name: 'AddGame',
    component: AddGame
  },
  {
    path: '/addPlayer',
    name: 'AddPlayer',
    component: AddPlayer
  }

]

const router = new VueRouter({
  routes
})

export default router
