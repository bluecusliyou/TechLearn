'''
在Python代码中，为了实现代码重用 => 体现共性与个性的问题，可以通过继承来实现重用关系
如果A类继承了B中的所有公共属性和公共方法，基本语法：
class B(object):
    # 公共属性
    # 公共方法

class A(B):
    A这个类实例化的对象会自动拥有B类的中所有公共属性和公共方法
'''
class Person(object):
    # 定义公共方法
    def eat(self):
        print('i can eat food!')

    # 定义公共方法
    def run(self):
        print('i can run!')

class Student(Person):
    pass

# 实例化对象
stu = Student()
stu.eat()
stu.run()