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