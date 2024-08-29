'''
掌握一个魔术方法有两个地方：① 在什么情况下会被触发 ② 在实际工作中，__str__()方法有何作用
__str__() ：① 当我们使用print()直接打印对象时，__str__()魔术方法会自动被触发
           ② 当我们需要打印输出某个对象的信息时，一般都可以定义__str__()魔术方法
注意事项：__str__()，必须返回字符串类型的数据，否则会直接报错。

需求：定义一个汽车类，类实例化对象必须要拥有哪些属性？brand品牌、model型号、color颜色
当我们打印这个汽车类对象时，要求输出这辆车的相关信息
'''
# 1、定义一个类
class Car(object):
    # 2、为未来对象添加公共属性
    def __init__(self, brand, model, color):
        self.brand = brand
        self.model = model
        self.color = color

    # 3、定义一个魔术方法__str__()
    def __str__(self):
        return f'汽车品牌：{self.brand}，汽车型号：{self.model}，汽车颜色：{self.color}'

# 4、实例Car类，产生一个对象
bmw = Car('宝马', '320', '黑色')
print(bmw)# 汽车品牌：宝马，汽车型号：320，汽车颜色：黑色

benz = Car('奔驰', '600', '灰色')
print(benz)# 汽车品牌：奔驰，汽车型号：600，汽车颜色：灰色