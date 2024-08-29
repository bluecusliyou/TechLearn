# 全局作用域（全局变量）
num1 = 10
def func():
    # 局部作用域（局部变量）
    num2 = 20
    # ① 在局部访问局部变量
    print(num2)

# ① 在全局访问全局变量
print(num1)
# 调用函数
func()