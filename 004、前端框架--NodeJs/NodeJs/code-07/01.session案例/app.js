// 导入 express 模块
const express = require('express')
    // 创建 express 的服务器实例
const app = express()

// 导入 session 中间件
const session = require('express-session')

// 配置 session 中间件
app.use(
    session({
        secret: 'keytest', //secret属性值可以是任意字符串
        resave: false,
        saveUninitialized: true,
    })
)

// 托管静态页面
app.use(express.static('./pages'))
    // 解析 POST 提交过来的表单数据
app.use(express.urlencoded({ extended: false }))

// 登录的 API 接口
app.post('/api/login', (req, res) => {
    // 判断用户提交的登录信息是否正确
    if (req.body.username !== 'admin' || req.body.password !== '000000') {
        return res.send({ status: 1, msg: '登录失败' })
    }

    // 注意：只有成功配置了 express-session 这个中间件之后，才能够通过 req 点出来 session 这个属性
    req.session.user = req.body // 用户的信息存储到session中
    req.session.islogin = true // 用户的登录状态存储到session中

    res.send({ status: 0, msg: '登录成功' })
})

// 获取用户姓名的接口
app.get('/api/username', (req, res) => {
    //判断用户是否登录    
    if (!req.session.islogin) {
        return res.send({ status: 1, msg: 'fail' })
    }
    res.send({
        status: 0,
        msg: 'success',
        username: req.session.user.username,
    })
})

// 退出登录的接口
app.post('/api/logout', (req, res) => {
    //清空 Session 信息
    req.session.destroy()
    res.send({
        status: 0,
        msg: '退出登录成功',
    })
})

// 调用 app.listen 方法，指定端口号并启动web服务器
app.listen(80, function() {
    console.log('Express server running at http://127.0.0.1:80')
})