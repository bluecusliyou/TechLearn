'''
__init__() ：初始化方法（在其他编程语言中，也称之为构造函数），顾名思义，其主要的作用就是进行一些初始化工作
实际工作场景：
① 在类的定义，用于描述对象未来所拥有的公共属性
② 还可以用于进行系统的初始化工作 => 比如文件操作中的打开文件，数据库操作中的连接数据库等等

魔术方法：
① 在什么情况下，__init__()会被触发（调用），当实例化对象时，__init__()方法会自动被触发
实例化多少次，__init__()方法就会被调用多少次
② 在实际工作中，主要用于公共属性的初始化或者项目的初始化工作

举个栗子：让我们Person实例化对象自动拥有name、age以及address三个公共属性
'''
class Person(object):
    # 1、描述未来对象所拥有的公共属性
    def __init__(self):
        self.name = '孙悟空'
        self.age = 50
        self.address = '花果山水帘洞'

    # 2、描述未来对象所拥有的公共方法
    def eat(self):
        print('i can eat food!')
    def drink(self):
        print('i can drink juice!')

# 1、实例化对象p1
p1 = Person()
print(p1.name)
print(p1.age)
print(p1.address)

p2 = Person()
print(p2.name)
print(p2.age)
print(p2.address)