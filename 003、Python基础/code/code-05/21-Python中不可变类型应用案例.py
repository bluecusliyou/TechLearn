# 定义一个函数
def func(num):
    # num = a
    num += 1
    print(num)

# 定义一个全局变量
a = 10
# 调用函数
func(a)
# 在全局作用域中打印a
print(a)  # 10