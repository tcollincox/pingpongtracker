import Vue from 'vue'
import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import router from './router'
import store from './store'
import LottieAnimation from "lottie-vuejs/src/LottieAnimation.vue";
import 'bootstrap/dist/css/bootstrap.min.css'
import VueLodash from 'vue-lodash'
import lodash from 'lodash'
import 'animate.css';

Vue.use(VueLodash, { name: 'custom' , lodash: lodash })
Vue.use(BootstrapVue)
Vue.use(LottieAnimation);

Vue.config.productionTip = false

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount('#app')
