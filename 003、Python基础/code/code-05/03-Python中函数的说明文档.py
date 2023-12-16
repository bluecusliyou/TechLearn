'''
函数说明文档：就相当于函数的说明书，在这个说明书中我们需要标注这个函数的作用、拥有的参数以及最终的返回值！
基本语法：
def func():
    """ 函数说明文档 """
    函数体代码

如何快速查看函数的说明文档呢？
help(函数名称)
可以基于PyCharm中快捷键 => Ctrl + Q
'''
def sum_num(num1, num2):
    '''
    sum_num函数主要用于实现对两个数进行求和操作
    :param num1: int，代表第一个参数
    :param num2: int，代表第二个参数
    :return: 返回num1与num2的加和
    '''
    result = num1 + num2
    return result

# 使用help方法就可以查看sum_num函数说明文档
help(sum_num)

# 使用快捷键快速查看某个函数说明文档 => Ctrl + Q
sum_num()

# 扩展一下：在Python中，所有的系统函数都有说明文档，如果遇到某个函数没有见过，直接使用Ctrl + Q就可以快速查看此函数说明文档
list1 = [1, 2, 3, 4, 5]
list1.reverse()
