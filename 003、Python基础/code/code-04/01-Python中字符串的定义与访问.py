'''
在Python代码中，字符串是最常见的一种数据类型 => 数据容器的一种，一个变量中可以同时保存多个字符
基本语法：
变量名称 = '变量的值'
或
变量名称 = "变量的值"
另外注意：字符串在输出时，是没有引号的！
'''
name = '刘备'
address = "四川省成都市"

print(type(name))  #<class 'str'>
print(type(address))  #<class 'str'>

# 访问以及获取变量的信息
print(name)
print(address)

print(name, address)