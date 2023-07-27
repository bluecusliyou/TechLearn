import axios from 'axios'
export default {
  namespaced: true,
  state () {
    return {
      // 购物车数据 [{}, {}]
      list: []
    }
  },
  mutations: {
    updateList (state, newList) {
      state.list = newList
    },
    // obj: { id: xxx, newCount: xxx }
    updateCount (state, obj) {
      // 根据 id 找到对应的对象，更新count属性即可
      const goods = state.list.find(item => item.id === obj.id)
      goods.count = obj.newCount
    }
  },
  actions: {
    // 请求方式：get
    // 请求地址：http://localhost:3000/cart
    async getList (context) {
      const res = await axios.get('http://localhost:3000/cart')
      context.commit('updateList', res.data)
    },
    // 请求方式：patch
    // 请求地址：http://localhost:3000/cart/:id值  表示修改的是哪个对象
    // 请求参数：
    // {
    //   name: '新值',  【可选】
    //   price: '新值', 【可选】
    //   count: '新值', 【可选】
    //   thumb: '新值'  【可选】
    // }
    async updateCountAsync (context, obj) {
      // 将修改更新同步到后台服务器
      await axios.patch(`http://localhost:3000/cart/${obj.id}`, {
        count: obj.newCount
      })
      // 将修改更新同步到 vuex
      context.commit('updateCount', {
        id: obj.id,
        newCount: obj.newCount
      })
    }
  },
  getters: {
    // 商品总数量 累加count
    total (state) {
      return state.list.reduce((sum, item) => sum + item.count, 0)
    },
    // 商品总价格 累加count * price
    totalPrice (state) {
      return state.list.reduce((sum, item) => sum + item.count * item.price, 0)
    }
  }
}
