<template>
  <!-- 新鲜好物 -->
  <div class="goods wrapper">
    <div class="title">
      <div class="left">
        <h3>新鲜好物</h3>
        <p>新鲜出炉 品质靠谱</p>
      </div>
      <div class="right">
        <a href="#" class="more"
          >查看全部<span class="iconfont icon-arrow-right-bold"></span
        ></a>
      </div>
    </div>
    <div class="bd">
      <ul>
        <BaseGoodsItem></BaseGoodsItem>
        <BaseGoodsItem></BaseGoodsItem>
        <BaseGoodsItem></BaseGoodsItem>
        <BaseGoodsItem></BaseGoodsItem>
      </ul>
    </div>
  </div>
</template>

<script>
export default {}
</script>

<style>
/* 新鲜好物 */
.goods .bd ul {
  display: flex;
  justify-content: space-between;
}
</style>
