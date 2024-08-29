# 全局作用域（全局变量）
num1 = 10
def func():
    # 局部作用域（局部变量）
    num2 = 20

# 调用函数
func()
# 在全局作用域中调用局部变量num2
print(num2)