const path = require("path")

module.exports = {
    entry: "./src/main.js", // 入口：可以是相对路径
    output: {
        path: path.join(__dirname, "dist"), // 出口：必须是绝对路径
        filename: "bundle.js" // 出口"文件"名
    }
}