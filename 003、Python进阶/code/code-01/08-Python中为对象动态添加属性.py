'''
遗留问题：有没有一个方法，对象的属性能不能在实例化对象时，直接进行设置
答：可以，但是需要使用魔术方法来实现！
'''
# 1、定义一个类
class Person(object):
    # 定义对象方法
    def eat(self):
        print('i can eat food!')
    def drink(self):
        print('i can drink juice!')

# 2、在类的外部为对象动态添加属性
p1 = Person()
p1.name = '孙悟空'
p1.age = 50
p1.address = '花果山'

p2 = Person()
p2.name = '猪八戒'
p2.age = 46
p2.address = '高老庄'

