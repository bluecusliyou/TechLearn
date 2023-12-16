# 定义一个函数
def func(names2):
    # names2 = names1
    # 局部作用域
    names2.append('赵六')

# 定义一个全局变量
names1 = ['张三', '李四', '王五']
# 调用函数
func(names1)
print(names1)  # A. ['张三', '李四', '王五'] B. ['张三', '李四', '王五', '赵六']