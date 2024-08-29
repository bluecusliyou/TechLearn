'''
在Python代码中，我们在定义类的时候，只需要在定义属性时为其添加两个__，其就变成了私有属性！
class 类名(object):
    # 定义属性
    def __init__(self, name, age):
        self.name = 公有属性
        self.__age = 私有属性
    # 定义方法
'''
class Girl(object):
    # 定义属性
    def __init__(self, name):
        self.name = name
        self.__age = 18

g1 = Girl('小美')
print(g1.name)
print(g1.__age)# 报错，提示Girl对象没有__age属性