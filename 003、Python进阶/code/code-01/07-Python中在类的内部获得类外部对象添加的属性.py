'''
刚才为大家介绍过，可以在类的外部为对象添加动态属性，添加完成后，我们是否可以在类的内部对其进行获取呢？
在类的内部，我们可以通过对象方法中的self关键字来实现对自身属性和方法的调用
① self指向谁？谁实例化这个类，self就指向谁（对象）
② self有何作用？可以通过self.属性或者self.方法()形式来实现对自身属性或方法的调用
'''
# 1、定义一个类
class Person(object):
    # 2、定义属性
    # 3、定义方法
    def eat(self):
        pass

    def print_info(self):
        print(f'姓名：{self.name}')
        print(f'年龄：{self.age}')
        print(f'地址：{self.address}')

# 4、实例化Person类产生对象
p1 = Person()
# 5、动态为对象添加属性
p1.name = '小明'
p1.age = 23
p1.address = '广州市天河区'

# 6、通过p1对象，调用自身的print_info方法
p1.print_info()