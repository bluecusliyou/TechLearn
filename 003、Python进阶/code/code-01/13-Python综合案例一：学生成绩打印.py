'''
案例1：定义学员信息类，包含姓名、成绩属性，定义成绩打印方法（90分及以上显示优秀，80分及以上显示良好，70分及以上显示中等，60分及以上显示合格，60分以下显示不及格）

记住：在实际工作中，为了保证数据的安全性，一般不建议在类外部直接调用自身属性，如果想调用自身属性都是通过对应的方法
实现的！
'''
class Student(object):
    # 为未来实例化对象定义公共属性
    def __init__(self, name, score):
        self.name = name
        self.score = score

    # 为未来实例化对象定义公共方法
    def print_grade(self):
        if self.score >= 90:
            print(f'{self.name}成绩为{self.score}分，优秀！')
        elif self.score >= 80:  # 隐藏条件 80 <= score < 90
            print(f'{self.name}成绩为{self.score}分，良好！')
        elif self.score >= 70:
            print(f'{self.name}成绩为{self.score}分，中等！')
        elif self.score >= 60:
            print(f'{self.name}成绩为{self.score}分，合格！')
        else:
            print((f'{self.name}成绩为{self.score}分，不及格！'))

s1 = Student('Tom', 98)
s1.print_grade()

s2 = Student('Jennifer', 59)
s2.print_grade()