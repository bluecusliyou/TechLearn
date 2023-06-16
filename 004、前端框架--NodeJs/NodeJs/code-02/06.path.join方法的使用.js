const path = require('path')

// 注意：  ../ 会抵消前面的路径
const pathStr = path.join('/a', '/b/c', '../', './d', 'e')
console.log(pathStr) // \a\b\d\e

const pathStr2 = path.join(__dirname, './files/1.txt')
console.log(pathStr2) //当前文件所处目录\files\1.txt