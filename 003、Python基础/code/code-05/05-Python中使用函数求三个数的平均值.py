'''
案例：封装一个函数，求三个数的平均值
'''
# 1、定义一个函数
def func(num1, num2, num3):
    '''
    func函数主要用于求三个数的平均值
    :param num1: int, 第一个参数
    :param num2: int, 第二个参数
    :param num3: int, 第三个参数
    :return: 函数的返回值，返回三个数的平均值
    '''
    result = (num1 + num2 + num3) / 3
    return result

# 2、调用函数
print(func(10, 20, 30))