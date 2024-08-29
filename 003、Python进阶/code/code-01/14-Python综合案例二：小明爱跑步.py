'''
案例2：小明体重75.0公斤，小明每次跑步会减掉0.10公斤，小明每次吃东西体重增加0.20公斤。
分析：① 对象：小明 => 人类别 ② 属性：姓名、体重 ③ 方法：跑步、吃东西 ④ 添加一个打印方法，输出自身信息
'''
class Person(object):
    # 1、定义对象自身属性
    def __init__(self, name, weight):
        self.name = name
        self.weight = weight

    # 2、定义对象自身方法
    def run(self):
        # 跑步可以减少自身的体重属性
        self.weight -= 0.1

    def eat(self):
        # 吃东西可以增加自身的体重属性
        self.weight += 0.2

    # 3、定义一个__str__魔术方法，打印对象自身信息
    def __str__(self):
        return f'我的名字叫{self.name}，当前体重{self.weight:.2f}kg！'

p1 = Person('小明', 75)
print(p1)

# 小明爱跑步
p1.run()
print(p1)

p1.eat()
print(p1)