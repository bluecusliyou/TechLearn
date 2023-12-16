'''
在Python代码中，函数定义时的参数一共有3种类别：
① 普通参数，如def func(name, age, mobile)
② 缺省参数（默认值参数），如def func(name, age, gender='male')
③ 不定长参数，如def func(*args, **kwargs)
在函数中，以上三种参数还可以混合在一起使用，特别注意：顺序很重要
def func(① 普通参数 ② *args ③ 缺省参数 ④ **kwargs):
    pass
'''
def func(a, b, *args, c=4, **kwargs):
    print(a, b)
    print(args)
    print(c)
    print(kwargs)

# 如何传递参数
func(1, 2, 3, c=100, d=5, e=6)