'''
扩展：子类继承父类的同时，还可以编写一些属于自己的属性和方法。甚至重写父类属性或方法，我们把这种形式就称之为扩展。
继承意义：① 实现代码重用 ② 子类应该在继承的同时，拥有自己的特性（扩展）
'''
class Animal(object):
    def eat(self):
        print('i can eat food!')

    def call(self):
        print('i can call!')

class Dog(Animal):
    # 重写父类中的call方法
    def call(self):
        print('i can wang wang wang!')


class Cat(Animal):
    # 重写父类中的call方法
    def call(self):
        print('i can miao miao miao!')

dog = Dog()
dog.eat()
dog.call()

cat = Cat()
cat.eat()
cat.call()


