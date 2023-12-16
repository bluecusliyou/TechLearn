'''
在Python中，三目运算符也叫三元运算符，其基本语法如下：
if 条件判断:
    条件成立则执行if缩进代码
else:
    条件不成立则执行else中的缩进代码

三目运算符：
值1 if 条件判断 else 值2

如果条件判断成立，则返回值1；如果条件判断不成立，则返回else中的值2
案例：求两个数中的最大值
'''
num1 = 10
num2 = 100

# if num1 > num2:
#     max = num1
# else:
#     max = num2

# 把以上代码改成三目运算符
max = num1 if num1 > num2 else num2
print(f'num1与num2中的最大值为{max}')
