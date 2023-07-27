<template>
  <div class="app">
    <BaseCount :count="count" @changeCount="handleChange"></BaseCount>
  </div>
</template>

<script>
import BaseCount from './components/BaseCount.vue'
export default {
  components:{
    BaseCount
  },
  data(){
    return {
      count:100
    }
  },
  methods:{
    handleChange(newVal){
      // console.log(newVal);
      this.count = newVal
    }
  }
}
</script>

<style>

</style>