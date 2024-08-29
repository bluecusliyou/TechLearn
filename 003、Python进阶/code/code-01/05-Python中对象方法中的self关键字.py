'''
有一个问题：在我们定义类的时候，我们描述的是未来实例化对象所拥有的属性和方法，但是为什么所有的对象方法都要有一个参数self，self关键字到底代表什么含义呢？
答：在类中定义的对象方法中的self参数，与实例化产生的对象内存地址一致，所以代表两者指向了相同的内存空间。所以self
关键字就代表实例化对象本身。
简单来说：谁实例化了Person类，类中的对象方法就指向谁，self就相当于实例化对象本身！
由于self关键字在类的内部就代表对象本身，所以我们在方法的里面可以使用self调用自身的属性或方法。
'''
class Person(object):
    # 属性
    # 方法
    def speak(self):
        print(self)

# 实例化p1对象
p1 = Person()
print(p1)   # <__main__.Person object at 0x00000184FF8FD3D0>
p1.speak()  # <__main__.Person object at 0x00000184FF8FD3D0>

p2 = Person()
print(p2)   # <__main__.Person object at 0x00000184FF8FD400>
p2.speak()  # <__main__.Person object at 0x00000184FF8FD400>