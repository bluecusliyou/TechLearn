'''
在Python中，逻辑运算符主要有三种情况：
① 逻辑与 => and符号，表达式1 and 表达式2，当两边表达式全部为True，则最终结果为True。如果有一方为False，
则最终结果为False
② 逻辑或 => or符号，表达式1 or 表达式2，当两边的表达式有一方为True，则最终结果为True。如果两边同时为False，
则最终结果为False
③ 逻辑非 => not bool布尔类型表达式，代表取反的含义。如果表达式返回的结果为True，添加了not以后就变成False。
如果bool布尔类型的表达式为False，则添加了not以后就变成True。
'''
a = 1
b = 2
c = 3

print((a > b) and (b > c))  # False and False => False
print((a < b) or (b < c))  # True or True => True
print(not (a > b))  # False => True