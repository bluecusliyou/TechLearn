<template>
  <div class="base-chart-box" ref="baseChartBox">子组件</div>
</template>

<script>
import * as echarts from 'echarts'

export default {
  mounted() {
    // 基于准备好的dom，初始化echarts实例
    // document.querySelector 会查找项目中所有的元素
    // $refs只会在当前组件查找盒子
    // var myChart = echarts.init(document.querySelector('.base-chart-box'))
    var myChart = echarts.init(this.$refs.baseChartBox)
    // 绘制图表
    myChart.setOption({
      title: {
        text: 'ECharts 入门示例',
      },
      tooltip: {},
      xAxis: {
        data: ['衬衫', '羊毛衫', '雪纺衫', '裤子', '高跟鞋', '袜子'],
      },
      yAxis: {},
      series: [
        {
          name: '销量',
          type: 'bar',
          data: [5, 20, 36, 10, 10, 20],
        },
      ],
    })
  },
}
</script>

<style scoped>
.base-chart-box {
  width: 400px;
  height: 300px;
  border: 3px solid #000;
  border-radius: 6px;
}
</style>