'''
在Python代码中，只要涉及到模块的导入你都有两种导入方式：① import ② from
'''
# import my_module1
# 导入模块中已经封装好的sum_num()方法
# my_module1.sum_num(10, 20)

from my_module1 import sum_num
# 调用方法
sum_num(10, 20)