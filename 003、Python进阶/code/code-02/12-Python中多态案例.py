'''
多态：同一个方法，随着传入对象的不同，返回不同的结果（多态）
① 有继承
② 重写父类中的公共方法
'''
class Dog():
    # 定义一个公共方法
    def work(self):
        pass

class ArmyDog(Dog):
    # 重写父类中的work方法
    def work(self):
        print('追击敌人...')

class DrugDog(Dog):
    # 重写父类中的work方法
    def work(self):
        print('追查毒品...')

class Person(object):
    # 定义一个多态接口 => 函数、方法
    def work_with_dog(self, obj):
        obj.work()

# 实例化Person类生成一个对象
police = Person()
police.work_with_dog(ArmyDog())