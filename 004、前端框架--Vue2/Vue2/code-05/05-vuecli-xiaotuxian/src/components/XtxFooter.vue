<template>
  <!-- 版权底部 -->
  <div class="footer">
    <div class="wrapper">
      <div class="service">
        <ul>
          <li>
            <span></span>
            <p>价格亲民</p>
          </li>
          <li>
            <span></span>
            <p>物流快捷</p>
          </li>
          <li>
            <span></span>
            <p>品质新鲜</p>
          </li>
          <li>
            <span></span>
            <p>售后无忧</p>
          </li>
        </ul>
      </div>
      <div class="help">
        <div class="left">
          <dl>
            <dt>购物指南</dt>
            <dd><a href="#">购物流程</a></dd>
            <dd><a href="#">支付方式</a></dd>
            <dd><a href="#">售后规则</a></dd>
          </dl>
          <dl>
            <dt>配送方式</dt>
            <dd><a href="#">配送运费</a></dd>
            <dd><a href="#">配送范围</a></dd>
            <dd><a href="#">配送时间</a></dd>
          </dl>
          <dl>
            <dt>关于我们</dt>
            <dd><a href="#">平台规则</a></dd>
            <dd><a href="#">联系我们</a></dd>
            <dd><a href="#">问题反馈</a></dd>
          </dl>
          <dl>
            <dt>售后服务</dt>
            <dd><a href="#">售后政策</a></dd>
            <dd><a href="#">退款说明</a></dd>
            <dd><a href="#">取消订单</a></dd>
          </dl>
          <dl>
            <dt>服务热线</dt>
            <dd>
              <a href="#"
                >在线客服<span class="iconfont icon-customer-service"></span
              ></a>
            </dd>
            <dd><a href="#">客服电话 400-0000-000</a></dd>
            <dd><a href="#">工作时间 周一至周日 8:00-18:00</a></dd>
          </dl>
        </div>
        <div class="right">
          <ul>
            <li>
              <div><img src="@/assets/images/wechat.png" alt="" /></div>
              <p>微信公众号</p>
            </li>
            <li>
              <div><img src="@/assets/images/app.png" alt="" /></div>
              <p>APP下载二维码</p>
            </li>
          </ul>
        </div>
      </div>
      <div class="copyright">
        <p>
          <a href="#">关于我们</a>|<a href="#">帮助中心</a>|<a href="#"
            >售后服务</a
          >|<a href="#">配送与验收</a>|<a href="#">商务合作</a>|<a href="#"
            >搜索推荐</a
          >|<a href="#">友情链接</a>
        </p>
        <p>CopyRight © 小兔鲜</p>
      </div>
    </div>
  </div>
</template>

<script>
export default {}
</script>

<style>
/* 版权底部 */
.footer {
  height: 580px;
  background-color: #f5f5f5;
}
.footer .service {
  padding: 60px 0;
  height: 180px;
  border-bottom: 1px solid #e8e8e8;
}
.footer .service ul {
  display: flex;
  justify-content: space-around;
}
.footer .service li {
  display: flex;
  line-height: 58px;
}
.footer .service span {
  display: block;
  margin-right: 20px;
  width: 58px;
  height: 58px;
  background-image: url(~@/assets/images/sprite.png);
}
.footer .service li:nth-child(2) span {
  background-position: 0 -58px;
}
.footer .service li:nth-child(3) span {
  background-position: 0 -116px;
}
.footer .service li:nth-child(4) span {
  background-position: 0 -174px;
}
.footer .service p {
  font-size: 28px;
}
.footer .help {
  display: flex;
  justify-content: space-between;
  margin-top: 60px;
}
.footer .help .left {
  display: flex;
}
.footer .help .left dl {
  margin-right: 84px;
}
.footer .help .left dt {
  margin-bottom: 30px;
  font-size: 18px;
}
.footer .help .left dd {
  margin-bottom: 10px;
}
.footer .help .left dd a {
  color: #969696;
}
.footer .help .right ul {
  display: flex;
  align-items: flex-start;
}
.footer .help .right li:nth-child(1) {
  margin-right: 55px;
  text-align: center;
}
.footer .help .right div {
  margin-bottom: 10px;
  width: 120px;
  height: 120px;
  color: #969696;
}
.icon-customer-service {
  margin-left: 3px;
  color: #00be9a;
}
.copyright {
  margin-top: 100px;
  text-align: center;
  color: #a1a1a1;
}
.copyright p {
  margin-bottom: 15px;
}
.copyright a {
  margin: 0 10px;
  color: #a1a1a1;
}
</style>
