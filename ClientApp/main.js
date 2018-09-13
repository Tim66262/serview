import Vue from 'vue'
import router from './router'
import App from './components/App'
import Vuetify from 'Vuetify'
import axios from 'axios'
import VueAxios from 'vue-axios'

// Defaults für axios definnieren
axios.defaults.withCredentials = true;
axios.defaults.headers.put["Content-Type"] = "application/json";
axios.defaults.headers.post["Content-Type"] = "application/json";

Vue.use(Vuetify)
Vue.use(VueAxios, axios)

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  components: { App },
  router,
  template: '<App/>'
})