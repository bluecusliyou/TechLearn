<template>
  <div class="son" style="border:3px solid #000;margin:10px">
    <!-- 3.直接使用props的值 -->
    我是Son组件--{{title}}
  </div>
</template>

<script>
export default {
  name: 'Son-Child',
  // 2.通过props来接受
  props:['title']
}
</script>

<style>

</style>