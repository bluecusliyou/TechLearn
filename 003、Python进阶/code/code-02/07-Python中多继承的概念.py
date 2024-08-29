'''
Python语言是少数支持多继承的一门编程语言，所谓的多继承就是允许一个类同时继承自多个类的特性。
class C(object):
    pass
class B(object):
    pass

class A(B, C):
    pass
'''
# 汽油车类
class GasolineCar(object):
    def run_with_gasoline(self):
        print('i can run with gasoline!')

# 电动车类
class ElectricCar(object):
    def run_with_electric(self):
        print('i can run with electric!')

# 混动汽车
class HybridCar(ElectricCar, GasolineCar):
    pass

benz = HybridCar()
benz.run_with_gasoline()
benz.run_with_electric()