'''
类是相同或相似属性和方法的一组对象的集合，是一个抽象概念。
如果想获得一个对象，首先应该创建一个类，基本语法：
class 类名(object):
    # 属性 => 变量
    # 方法 => 函数

注意事项：类名在Python中，一般采用大驼峰的命名法，其主要由字母、数字以及下划线，但是不能以数字开头！！！
注意事项：类在定义构成中，只是描述了一下未来这个对象所拥有的属性和方法，但是其本身并没有并调用，只有在实例化对象时其才真正执行！！！
'''
class Person(object):
    # 属性
    # 方法
    def eat(self):
        print('i can eat food!')

    def run(self):
        print('i can run!')