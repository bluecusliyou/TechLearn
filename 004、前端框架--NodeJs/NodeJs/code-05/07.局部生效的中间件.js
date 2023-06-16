// 导入 express 模块
const express = require('express')
    // 创建 express 的服务器实例
const app = express()

// 定义中间件函数mw1
const mw1 = (req, res, next) => {
    console.log('调用了局部生效的中间件')
    next()
}

// mw1这个中间件只在"当前路由中生效"，这种用法属于"局部生效的中间件"
app.get('/', mw1, (req, res) => {
    res.send('Home page.')
})

// mw1这个中间件不会影响下面这个路由
app.get('/user', (req, res) => {
    res.send('User page.')
})

// 调用 app.listen 方法，指定端口号并启动web服务器
app.listen(80, function() {
    console.log('Express server running at http://127.0.0.1')
})