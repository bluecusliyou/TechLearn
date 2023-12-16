'''
在函数的内部，当函数执行完毕后，可能会给函数调用的位置一个返回值，接下来聊聊返回值的概念
① 一个函数中是否可以同时拥有多个return，是否全部会被执行
答：从语法上，一个函数内部是可以同时拥有多个return关键字的，但是只有第一个return会被执行。因为函数一旦遇到了
return返回值，会立即执行两个操作：返回return后面的结果，强制中止此函数的继续执行。

② 在其他编程语言中，一个函数只能返回一个值，那Python中的函数是否可以同时返回多个值呢？
答：在Python语言中，函数既可以返回一个值，也可以返回多个值（注意：多个值的返回，是以元组形式进行返回输出的）

③ 当函数执行完毕后，return返回值到底返回到哪里了，如果一个函数要是没有返回值，则默认返回什么？
答：返回给函数调用位置，如果一个函数没有return返回值，则当这个函数执行完毕后，其返回None！
'''
# 1、定义一个func1()函数
def func1():
    return 1  # 多个return，返回第一个，后面代码不执行
    return 2
    return 3

result1 = func1()
print(result1) # 1

# 2、定义一个func2函数
def func2():
    return 1, 2, 3 # 多个返回值

result2 = func2()
print(result2) # (1, 2, 3)
print(type(result2)) # <class 'tuple'>

# 3、定义一个func3()函数
def func3():
    pass # 无返回值

result3 = func3()
print(result3)  # None
