<template>
  <div class="goods-container">
    <!-- 左侧图片区域 -->
    <div class="left">
      <img :src="item.thumb" class="avatar" alt="">
    </div>
    <!-- 右侧商品区域 -->
    <div class="right">
      <!-- 标题 -->
      <div class="title">{{ item.name }}</div>
      <div class="info">
        <!-- 单价 -->
        <span class="price">￥{{ item.price }}</span>
        <div class="btns">
          <!-- 按钮区域 -->
          <button class="btn btn-light" @click="btnClick(-1)">-</button>
          <span class="count">{{ item.count }}</span>
          <button class="btn btn-light" @click="btnClick(1)">+</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CartItem',
  methods: {
    btnClick (step) {
      const newCount = this.item.count + step
      const id = this.item.id

      if (newCount < 1) return

      this.$store.dispatch('cart/updateCountAsync', {
        id,
        newCount
      })
    }
  },
  props: {
    item: {
      type: Object,
      required: true
    }
  }
}
</script>

<style lang="less" scoped>
.goods-container {
  display: flex;
  padding: 10px;
  + .goods-container {
    border-top: 1px solid #f8f8f8;
  }
  .left {
    .avatar {
      width: 100px;
      height: 100px;
    }
    margin-right: 10px;
  }
  .right {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    flex: 1;
    .title {
      font-weight: bold;
    }
    .info {
      display: flex;
      justify-content: space-between;
      align-items: center;
      .price {
        color: red;
        font-weight: bold;
      }
      .btns {
        .count {
          display: inline-block;
          width: 30px;
          text-align: center;
        }
      }
    }
  }
}

.custom-control-label::before,
.custom-control-label::after {
  top: 3.6rem;
}
</style>
