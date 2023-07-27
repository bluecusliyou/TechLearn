<template>
    <!-- 最新专题 -->
    <div class="topic wrapper">
      <div class="title">
        <div class="left">
          <h3>最新专题</h3>
        </div>
        <div class="right">
          <a href="#" class="more"
            >查看全部<span class="iconfont icon-arrow-right-bold"></span
          ></a>
        </div>
      </div>
      <div class="topic_bd">
        <ul>
          <li>
            <a href="#">
              <div class="pic">
                <img src="@/assets/images/topic1.png" alt="" />
                <div class="info">
                  <div class="left">
                    <h5>吃这些美食才不算辜负自己</h5>
                    <p>餐厨起居洗护好物</p>
                  </div>
                  <div class="right">¥<span>29.9</span>起</div>
                </div>
              </div>
              <div class="txt">
                <div class="left">
                  <p>
                    <span class="iconfont icon-favorites-fill red"></span>
                    <i>1200</i>
                  </p>
                  <p>
                    <span class="iconfont icon-browse"></span>
                    <i>1800</i>
                  </p>
                </div>
                <div class="right">
                  <span class="iconfont icon-comment"></span>
                  <i>246</i>
                </div>
              </div>
            </a>
          </li>
          <li>
            <a href="#">
              <div class="pic">
                <img src="@/assets/images/topic2.png" alt="" />
                <div class="info">
                  <div class="left">
                    <h5>吃这些美食才不算辜负自己</h5>
                    <p>餐厨起居洗护好物</p>
                  </div>
                  <div class="right">¥<span>29.9</span>起</div>
                </div>
              </div>
              <div class="txt">
                <div class="left">
                  <p>
                    <span class="iconfont icon-fabulous"></span>
                    <i>1200</i>
                  </p>
                  <p>
                    <span class="iconfont icon-browse"></span>
                    <i>1800</i>
                  </p>
                </div>
                <div class="right">
                  <span class="iconfont icon-comment"></span>
                  <i>246</i>
                </div>
              </div>
            </a>
          </li>
          <li>
            <a href="#">
              <div class="pic">
                <img src="@/assets/images/topic3.png" alt="" />
                <div class="info">
                  <div class="left">
                    <h5>吃这些美食才不算辜负自己</h5>
                    <p>餐厨起居洗护好物</p>
                  </div>
                  <div class="right">¥<span>29.9</span>起</div>
                </div>
              </div>
              <div class="txt">
                <div class="left">
                  <p>
                    <span class="iconfont icon-fabulous"></span>
                    <i>1200</i>
                  </p>
                  <p>
                    <span class="iconfont icon-browse"></span>
                    <i>1800</i>
                  </p>
                </div>
                <div class="right">
                  <span class="iconfont icon-comment"></span>
                  <i>246</i>
                </div>
              </div>
            </a>
          </li>
        </ul>
      </div>
    </div>
</template>

<script>
export default {

}
</script>

<style>

/* 最新专题 */
.topic {
  padding-top: 60px;
  margin-bottom: 40px;
}
.topic_bd ul {
  display: flex;
  justify-content: space-between;
}
.topic_bd li {
  width: 405px;
  height: 355px;
}
.topic_bd .pic {
  position: relative;
  width: 405px;
  height: 288px;
}
.topic_bd .txt {
  display: flex;
  justify-content: space-between;
  padding: 0 15px;
  height: 67px;
  line-height: 67px;
  color: #666;
  font-size: 14px;
}
.topic_bd .txt .left {
  display: flex;
}
.topic_bd .txt .left p {
  margin-right: 20px;
}
.topic_bd .txt .left .red {
  color: #AA2113;
}
.topic_bd .info {
  position: absolute;
  left: 0;
  bottom: 0;
  display: flex;
  justify-content: space-between;
  padding: 0 15px;
  width: 100%;
  height: 90px;
  background-image: linear-gradient(180deg, rgba(137,137,137,0.00) 0%, rgba(0,0,0,0.90) 100%);
}
.topic_bd .info .left {
  padding-top: 20px;
  color: #fff;
}
.topic_bd .info .left h5 {
  margin-bottom: 5px;
  font-size: 20px;
}
.topic_bd .info .right {
  margin-top: 35px;
  padding: 0 7px;
  height: 25px;
  line-height: 25px;
  background-color: #fff;
  color: #AA2113;
  font-size: 15px;
}
</style>