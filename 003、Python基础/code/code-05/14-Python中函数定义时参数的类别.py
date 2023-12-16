'''
在Python代码中，函数定义时的参数一共有3种类别：
① 普通参数，如def func(name, age, mobile)
② 缺省参数（默认值参数），如def func(name, age, gender='male')
③ 不定长参数，如def func(*args, **kwargs)
有些情况下，我们可以为某个参数定义一个默认值，我们把这种带有默认值的参数就称之为缺省参数（默认值参数）
基本语法：
def 函数名称(普通参数, 参数名称=默认值):
    pass

# 优点：① 如果我们传参过程中，想让某个参数拥有默认值，可以直接省略参数的传递
函数名称（普通参数的值）
       ② 如果你不想使用默认值，则可以给默认值参数传递一个值，用于替换默认值
'''
def student(name, age, gender='male'):
    print(name, age, gender)

# 调用student函数
student('Tom', 23)
student('Jack', 25)
student('婉儿', 19, 'female')