<template>
  <div>
    <h1>自定义指令</h1>
    <input v-focus type="text">
  </div>
</template>

<script>
export default {
  // 2. 局部注册指令
  directives: {
    // 指令名：指令的配置项
    focus: {
      inserted (el) {
        el.focus()
      }
    }
  }
}
</script>

<style>

</style>