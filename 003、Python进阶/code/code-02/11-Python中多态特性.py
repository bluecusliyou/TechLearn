'''
什么是多态？简单来说就是一种事物，随着传入对象的不同，可以返回多种形态。
① 多态依赖继承
② 子类还需要重写父类中的方法
'''
class Fruit(object):
    # 定义一个公共方法
    def makejuice(self):
        pass

class Apple(Fruit):
    # 重写父类中的公共方法
    def makejuice(self):
        print('i can make apple juice!')

class Orange(Fruit):
    # 重写父类中的公共方法
    def makejuice(self):
        print('i can make orange juice!')

class Banana(Fruit):
    # 重写父类中的公共方法
    def makejuice(self):
        print('i can make banana juice!')

# 定义一个公共接口 => 多态特性 => 要求传入一个对象作为参数
def service(obj):
    obj.makejuice()

apple = Apple()
orange = Orange()
banana = Banana()

service(apple)
service(orange)
service(banana)
