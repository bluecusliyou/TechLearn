<template>
  <div class="SonA">我是SonA组件
    <GrandSon></GrandSon>
  </div>
</template>

<script>
import GrandSon from '../components/GrandSon.vue'
export default {
  components:{
    GrandSon
  }
}
</script>

<style>
.SonA {
  border: 3px solid #000;
  border-radius: 6px;
  margin: 10px;
  height: 200px;
}
</style>