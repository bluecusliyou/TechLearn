'''
遗留问题：虽然我们可以通过__init__()魔术方法为每一个对象添加三个属性name、age以及address，但是每个实例化对象
所拥有的属性值都是一样的，如何解决以上问题。
答：通过__init__()方法进行传递参数
'''
class Person(object):
    # 定义公共属性
    def __init__(self, name, age, address):
        # self => 对象本身
        # self.name属性 = 参数，即使属性与参数同名也没有任何影响
        self.name = name
        self.age = age
        self.address = address

    # 定义公共方法
    def speak(self):
        # self还可以调用自身属性或方法
        print(f'我的名字：{self.name}，年龄：{self.age}，来自：{self.address}')

# 实例化对象
p1 = Person('孙悟空', 23, '花果山水帘洞')
print(p1.name)
print(p1.age)
print(p1.address)

p2 = Person('猪八戒', 22, '高老庄')
print(p2.name)
print(p2.age)
print(p2.address)