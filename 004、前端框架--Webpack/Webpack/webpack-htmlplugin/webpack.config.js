const path = require("path")

// 引入自动生成 html 的插件
const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = {
    entry: "./src/main.js", // 入口：可以是相对路径
    output: {
        path: path.join(__dirname, "dist"), // 出口：必须是绝对路径
        filename: "bundle.js" // 出口"文件"名
    },
    plugins: [
        // html 插件
        new HtmlWebpackPlugin({
            // 指定要复制的HTML文件位置
            // 可以使用相对路径
            // 作用: 每次打包时自动从该目录下复制HTML到出口, 同时自动引入js文件, 并添加defer属性
            // defer: 等页面资源加载完成后加载js文件
            template: './public/index.html'
        })
    ]
}