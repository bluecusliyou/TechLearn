// 导入 express 模块
const express = require('express')
    // 创建 express 的服务器实例
const app = express()

// 定义中间件函数mw1
const mw1 = (req, res, next) => {
    console.log('调用了第一个局部生效的中间件')
    next()
}

// 定义中间件函数mw2
const mw2 = (req, res, next) => {
    console.log('调用了第二个局部生效的中间件')
    next()
}

// 以下两种写法是"完全等价"的，可根据自己的喜好，选择任意一种方式进行使用
app.get('/', mw1, mw2, (req, res) => {
    res.send('Home page.')
})
app.get('/', [mw1, mw2], (req, res) => {
    res.send('Home page.')
})


app.get('/user', (req, res) => {
    res.send('User page.')
})

// 调用 app.listen 方法，指定端口号并启动web服务器
app.listen(80, function() {
    console.log('Express server running at http://127.0.0.1')
})