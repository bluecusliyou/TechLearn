'''
global ：声明全局变量，代表从这行代码开始，使用的变量都是全局中的变量
'''
num = 10
def func():
    # 尝试在局部作用域中修改全局变量
    global num
    num = 100

func()
print(num)