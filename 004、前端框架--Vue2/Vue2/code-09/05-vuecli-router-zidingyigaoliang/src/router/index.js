import Find from '@/views/Find'
import My from '@/views/My'
import Friend from '@/views/Friend'

import Vue from 'vue'
import VueRouter from 'vue-router'
Vue.use(VueRouter) // VueRouter插件初始化

// 创建了一个路由对象
const router = new VueRouter({
  // routes 路由规则们
  // route  一条路由规则 { path: 路径, component: 组件 }
  routes: [
    { path: '/find', component: Find },
    { path: '/my', component: My },
    { path: '/friend', component: Friend },
  ],
  // link自定义高亮类名
  linkActiveClass: 'active', // 配置模糊匹配的类名
  linkExactActiveClass: 'exact-active' // 配置精确匹配的类名
})

export default router