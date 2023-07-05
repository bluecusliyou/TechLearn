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
    ],
    module: { // 如何处理项目中不同模块文件
        rules: [ // 规则
            {
                // . 表示除换行符以外的任意字符
                // \ 转义符
                test: /\.css$/, // 匹配所有的css文件
                // loader的加载顺序是从右往左
                // 先用css-loader让webpack能够识别css文件并打包
                // 再用style-loader将样式插入到dom中
                use: ["style-loader", "css-loader"]
            },
            {
                test: /\.less$/, // 匹配.less结尾文件
                // 使用less-loader让webpack能够识别less文件 
                // 内置还会用less模块, 翻译less代码成css代码
                // 然后再打包CSS文件，并将样式插入到dom中
                use: ["style-loader", "css-loader", 'less-loader']
            },
            {
                test: /\.(png|jpg|gif|jpeg)$/i, // 匹配图片文件
                // asset
                // 大于 8KB 不转 base64 直接复制
                // 小于 8KB 转成 base64 插入到 js 中
                type: 'asset',
                // generator 就是定义打包输出的规则
                generator: {
                    // [] 的内容当做内置的变量
                    // [name] 表示原先的文件名
                    // [hash:6] 表示使用哈希字符串, 长度6
                    // [ext] 表示后缀名 带 .
                    filename: 'imgs/[name].[hash:4][ext]'
                }
            }
        ]
    }
}