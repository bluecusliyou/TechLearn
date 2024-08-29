'''
类方法：在Python代码中，类属性与对象属性一样，都强调封装特性，不建议直接在类的外部直接对类属性进行操作。
如果想在类的外部获取类属性的信息，必须使用类方法来实现。
类方法 => 基本语法：
class 类名称():
    类属性 = 属性值

    @classmethod => 装饰器
    def 类方法(cls):
        因为这个方法属于类方法，所以cls代表这个类本身

调用类方法：
类名称.类方法()  =>  强烈推荐使用第一种
对象.类方法()
案例：统计Tool工具类到底生成了多少个工具类对象
'''
class Tool(object):
    # 定义一个类属性
    count = 0
    # 定义对象属性
    def __init__(self, name):
        self.name = name
        # 对类属性进行操作，进行+1
        Tool.count += 1
    # 定义一个类方法 => 专门用于操作类属性
    @classmethod
    def getCount(cls):
        return f'您一共实例化了{cls.count}个对象！'

# 实例化对象
t1 = Tool('斧头')
t2 = Tool('榔头')
t3 = Tool('锤子')

# 调用类方法，输出一共创建了多少个对象
print(Tool.getCount())