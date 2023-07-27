<template>
  <div class="footer-container">
    <!-- 中间的合计 -->
    <div>
      <span>共 {{ total }} 件商品，合计：</span>
      <span class="price">￥{{ totalPrice }}</span>
    </div>
    <!-- 右侧结算按钮 -->
    <button class="btn btn-success btn-settle">结算</button>
  </div>
</template>

<script>
import { mapGetters } from 'vuex'
export default {
  name: 'CartFooter',
  computed: {
    ...mapGetters('cart', ['total', 'totalPrice'])
  }
}
</script>

<style lang="less" scoped>
.footer-container {
  background-color: white;
  height: 50px;
  border-top: 1px solid #f8f8f8;
  display: flex;
  justify-content: flex-end;
  align-items: center;
  padding: 0 10px;
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
  z-index: 999;
}

.price {
  color: red;
  font-size: 13px;
  font-weight: bold;
  margin-right: 10px;
}

.btn-settle {
  height: 30px;
  min-width: 80px;
  margin-right: 20px;
  border-radius: 20px;
  background: #42b983;
  border: none;
  color: white;
}
</style>
