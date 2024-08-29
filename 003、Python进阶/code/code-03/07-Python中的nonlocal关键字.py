'''
global ：声明全局变量，代表从这行代码开始，使用的变量都是全局中的变量：只能使用在函数内部
nonlocal ：声明离它最近的外层的局部变量
问题：在函数嵌套的情况下，我们的内部函数能不能修改外部函数的局部变量
'''
def outer():
    # 局部变量
    num = 10
    def inner():
        nonlocal num
        num = 100
    inner()
    print(num)  # 100

outer()