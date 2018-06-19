// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import App from './App'
import router from './router'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
// Steff
import VueI18n from 'vue-i18n'

Vue.use(Vuetify)
// Steff
Vue.use(VueI18n)

// i18n
const translations = {
  en: {
    account: 'Account',
    contact: 'Contact'
  }
}

// Create VueI18n instance with options
const i18n = new VueI18n({
  locale: 'nl',
  fallbackLocale: 'en',
  translations
})

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  i18n,
  components: { App },
  template: '<App/>'
})
