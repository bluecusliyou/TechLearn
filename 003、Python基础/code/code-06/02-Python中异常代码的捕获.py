'''
在Python中，我们可以通过try...except捕获异常
try:
    可能出现异常的代码
except:
    如果try语句中的代码出现了异常，则立即执行except缩进代码

优势：提高程序的健壮性
'''
num = int(input('请输入要进行除法运算的数字：'))
try:
    result = 10 / num
    print(result)
except:
    print('已经捕获到异常，执行B方案！')