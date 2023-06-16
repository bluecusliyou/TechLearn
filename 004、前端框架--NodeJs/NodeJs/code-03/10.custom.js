const age = 20

// 向 exports 对象上挂载 username 属性
exports.username = 'zs'

// 向 exports 对象上挂载 sayHello 方法
exports.sayHello = function() {
    console.log('Hello!')
}

exports.age = age