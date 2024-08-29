'''
类装饰器编写规则：
① 必须有一个__init__初始化方法，用于接收要装饰函数的函数
② 必须把这个类转换为可以调用的函数
问题：如何把一个类当做一个装饰器函数进行调用（把类当做函数）
'''

class Check():
    def __init__(self, fn):
        # fn就是要修饰函数的名称，当Check装饰器类被调用时，系统会自动把comment函数名称传递给fn变量
        self.__fn = fn
    # __call__方法：把一个类转换为函数的形式进行调用
    def __call__(self, *args, **kwargs):
        # 编写装饰器代码
        print('请先登录')
        # 调用comment函数本身
        self.__fn(*args, **kwargs)

# 编写一个函数，用于实现评论功能，底层comment = Check(comment)
@Check
def comment():
    print('评论功能')

# 调用comment函数，实现评论功能
comment()