<template>
  <div class="app" style="border: 3px solid #000; margin: 10px">
    我是APP组件
    <!-- 2.父组件对子组件的消息进行监听 -->
    <Son :title="myTitle" @changTitle="handleChange"></Son>
  </div>
</template>

<script>
import Son from './components/Son.vue'
export default {
  name: 'App',
  data() {
    return {
      myTitle: '我是父组件传进来的值',
    }
  },
  components: {
    Son,
  },
  methods: {
    // 3.提供处理函数，提供逻辑
    handleChange(newTitle) {
      this.myTitle = newTitle
    },
  },
}
</script>

<style>
</style>