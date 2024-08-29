'''
什么样的方法可以封装为静态方法？
答：既不需要调用自身属性（对象属性、类属性），也不需要调用自身方法（对象方法、类方法），本身就是一个独立功能。
定义：
class 类名称():
    @staticmethod
    def 静态方法():
        由于静态方法本身就是一个独立功能，既不需要调用自身属性也不需要调用自身方法，所以其没有参数
'''
class StudentManager(object):
    # 打印系统功能菜单
    @staticmethod
    def menu():
        print('-' * 40)
        print('欢迎使用学生管理系统V1.0')
        print('【1】添加学员信息')
        print('【2】删除学员信息')
        print('【3】修改学员信息')
        print('【4】查询学员信息')
        print('-' * 40)

# 调用静态方法 => 类名.静态方法() 或者 对象.静态方法()
StudentManager.menu()