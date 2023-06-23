const http = require('http')
const server = http.createServer()

server.on('request', (req, res) => {
    res.end('请求成功' + new Date().toLocaleTimeString())
})
server.listen(8001, () => {
    console.log('server running at http://127.0.0.1:8001')
})