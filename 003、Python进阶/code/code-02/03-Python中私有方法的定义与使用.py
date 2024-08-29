'''
如何定义私有方法？
class 类名():
    # 定义属性
    # 定义方法
    def __方法名称(self):
        私有方法
私有方法有何意义呢？答：私有方法并不是用于保护数据，简化程序的复杂度。
银行 => ATM取款 => ① 插卡 ② 用户验证 ③ 输入取款金额 ④ 取款 ⑤ 打印账单
'''
class ATM(object):
    # 1、定义一个插卡方法
    def __card(self):
        print('插卡')
    # 2、定义一个用户验证
    def __auth(self):
        print('用户验证')
    # 3、定义一个方法
    def __input(self):
        print('输入取款金额')
    # 4、取款
    def __take_money(self):
        print('取款')
    # 5、打印账单
    def __print_bill(self):
        print('打印账单')

    # 定义一个统一的"接口"，专门用于实现取款操作
    def withdraw(self):
        self.__card()
        self.__auth()
        self.__input()
        self.__take_money()
        self.__print_bill()

# 实例化ATM类，进行取款操作
atm = ATM()
atm.withdraw()