<template>
  <div class="app">
    <button @click="openDialog">退出按钮</button>
    <!-- isShow.sync  => :isShow="isShow" @update:isShow="isShow=$event" -->
    <BaseDialog :isShow.sync="isShow"></BaseDialog>
  </div>
</template>

<script>
import BaseDialog from './components/BaseDialog.vue'
export default {
  data() {
    return {
      isShow: false,
    }
  },
  methods: {
    openDialog() {
      this.isShow = true
      // console.log(document.querySelectorAll('.box')); 
    },
  },
  components: {
    BaseDialog,
  },
}
</script>

<style>
</style>