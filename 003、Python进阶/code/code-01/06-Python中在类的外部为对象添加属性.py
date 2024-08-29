'''
在Python中，每个对象一般都是由两部分内容组成的：① 属性 ② 方法
我们既可以在类的内部也可以在类的外部为其对象添加属性或获得属性
在类的外部如何添加属性：
对象名称.属性 = 属性值，如果属性值是一个字符串类型，还需要使用引号引起来！
在类的外部如何获得属性：
print(对象名称.属性)
'''
class Person(object):
    # 属性
    # 方法
    def eat(self):
        print('i can eat food!')

    def drink(self):
        print('i can drink juice!')

# 实例化产生对象
p1 = Person()
# 在类外部为p1对象添加属性
p1.name = '小明'
p1.age = 23
# 在类外部获得p1对象的属性
print(p1.name)
print(p1.age)

p1.eat()
p1.drink()

p2 = Person()
p2.name = '小美'
p2.age = 19

print(p2.name)
print(p2.age)