'''
私有属性有何意义？
答：明确区分内外，控制外部对内部数据访问，起到保护数据以及过滤异常数据目的！
'''
class Girl(object):
    # 定义属性
    def __init__(self, name):
        self.name = name
        self.__age = 18

    # 给__age私有属性添加一个访问"接口"
    def get_age(self):
        # 获取属性之前
        # 1、需要验证用户是否具有查看属性的权限
        # 2、如果有，则返回私有属性；如果没有权限，则直接禁止访问
        return self.__age

    # 给__age私有属性添加一个设置"接口"
    def set_age(self, age):
        # 在设置属性之前
        # 1、首先对age进行判断，判断是否是一个合理数据
        if not isinstance(age, int):
            print('很抱歉，您设置的age参数非整数类型')
            return
        if age <= 0 or age > 250:
            print('很抱歉，您设置的age参数范围不合理')
            return

        # 2、如果是合理的数据，则允许设置；反之，则直接禁止
        self.__age = age


g1 = Girl('小美')
print(g1.name)
g1.set_age(20)
print(g1.get_age())