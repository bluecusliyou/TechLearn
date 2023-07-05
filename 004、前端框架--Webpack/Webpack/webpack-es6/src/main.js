import $ from 'jquery'
import "./css/index.css"
import "./less/index.less"
import './assets/fonts/iconfont.css'

$(function() {
    $('#app li:nth-child(odd)').css('color', 'red')
    $('#app li:nth-child(even)').css('color', 'green')
})

// 引入图片-使用
import imgUrl from './assets/1.gif'
const theImg = document.createElement("img")
theImg.src = imgUrl
document.body.appendChild(theImg)

const fn = () => { // 高级语法
    console.log("你好babel");
}
console.log(fn) // 一定打印函数, 才会被webpack把"函数体"打包起来