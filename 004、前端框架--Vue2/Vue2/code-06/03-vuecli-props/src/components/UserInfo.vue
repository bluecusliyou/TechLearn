<template>
  <div class="userinfo">
    <h3>我是个人信息组件</h3>
    <div>姓名：{{username}}</div>
    <div>年龄：{{age}}</div>
    <div>是否单身：{{isSingle}}</div>
    <div>座驾：{{car.brand}}</div>
    <div>兴趣爱好：{{hobby.join('、')}}</div>
  </div>
</template>

<script>
export default {
  props:['username','age','isSingle','car','hobby']
}
</script>

<style>
.userinfo {
  width: 300px;
  border: 3px solid #000;
  padding: 20px;
}
.userinfo > div {
  margin: 20px 10px;
}
</style>