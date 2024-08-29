# 汽油车类
class GasolineCar(object):
    def run(self):
        print('i can run with gasoline!')

# 电动车类
class ElectricCar(object):
    def run(self):
        print('i can run with electric!')

# 混动汽车
class HybridCar(ElectricCar, GasolineCar):
    pass

# 到底HybridCar优先继承哪个类中的所有公共属性和公共方法呢？
benz = HybridCar()
benz.run()  # i can run with electric!