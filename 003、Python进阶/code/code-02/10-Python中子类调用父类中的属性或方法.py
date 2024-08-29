'''
在Python代码中，如果在继承重写的基础上，我们还需要强制调用父类中的属性或方法，可以考虑使用super()
基本语法：
super().属性
super().方法()
'''
class Animal():
    def __init__(self, name, age):
        self.name = name
        self.age = age

    def eat(self):
        print('吃...')

    def sleep(self):
        print('睡...')

    def call(self):
        print('叫...')

class Dog(Animal):
    def __init__(self, name, age, sex):
        super().__init__(name, age)
        self.sex = sex

    def __str__(self):
        return f'{self.name}，今年{self.age}岁了，我会汪汪叫...'


class Cat(Animal):
    def __init__(self, name, age, sex):
        super().__init__(name, age)
        self.sex = sex

    def __str__(self):
        return f'{self.name}，今年{self.age}岁了，我会喵喵叫...'

dog = Dog('阿呆',18,'男')
dog.eat()
print(dog)

cat = Cat('阿瓜',20,'女')
cat.eat()
print(cat)