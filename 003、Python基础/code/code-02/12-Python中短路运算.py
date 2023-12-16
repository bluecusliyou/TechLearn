'''
短路运算原则：逻辑与以及逻辑或运算符的两边不一定都是布尔类型的数据，也可以是数值类型或者字符串类型。那最终结果？？？
记住：谁决定了这个表达式最终结果，则表达式就返回谁
在计算机底层：Python把0、空字符串''和None看成 False，其他数值和非空字符串都看成 True
print(3 and 4)  # 3相当于True，4相当于True，最终结果为4
print(6 or 7)  # 6 or 7，6相当True，7相当于True，最终结果为6
'''
print(3 and 4 and 5)  # 5
print(5 and 6 or 7)  # 6
4 > 3 and print('hello world')  # hello world