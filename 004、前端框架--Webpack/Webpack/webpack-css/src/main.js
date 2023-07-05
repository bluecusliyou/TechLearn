import $ from 'jquery'
import "./css/index.css"

$(function() {
    $('#app li:nth-child(odd)').css('color', 'red')
    $('#app li:nth-child(even)').css('color', 'green')
})