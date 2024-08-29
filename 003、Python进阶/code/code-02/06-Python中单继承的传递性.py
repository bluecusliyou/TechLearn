'''
多层继承也是单继承的一种延伸，简单来说：A => B => C，所以A自动继承了C中的所有公共属性和公共方法
'''
class C(object):
    def func1(self):
        print('C类中的func1方法')

class B(C):
    def func2(self):
        print('B类中的func2方法')

class A(B):
    pass

# 实例化A类产生一个a对象
a = A()
a.func2()
a.func1()