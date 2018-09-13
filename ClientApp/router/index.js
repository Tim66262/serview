import Vue from 'vue'
import Router from 'vue-router'
import Home from '../components/pages/Home'
import Series from '../components/pages/Series'
import Ratings from '../components/pages/Ratings'
import SerieDetail from '../components/pages/SerieDetail'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'home',
            component: Home
        },
        {
            path: '/series',
            name: 'series',
            component: Series
        },
        {
            path: '/ratings',
            name: 'ratings',
            component: Ratings
        },
        {
            path: '/series/:id',
            name: 'seriedetail',
            component: SerieDetail
        },
    ]
})