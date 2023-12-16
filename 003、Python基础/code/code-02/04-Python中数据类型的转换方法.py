'''
在Python代码中，需要大家掌握4种数据类型的转换方法。
int() : 把其他数据类型转换为整数
float() : 把其他数据类型转换为浮点数
str() : 把其他数据类型转换为字符串类型大数据
'''
# 1、定义一个str字符串类型的数据
str1 = '10'
num1 = int(str1)
print(num1)
print(type(num1))

# 2、float => int
float2 = 9.88
num2 = int(float2)  # 把浮点数直接转换为整数（警告：浮点类型转换为整数类型，则小数点后面的数据都会被舍弃）
print(num2)

# 3、int/float => str
num3 = 6.95
str3 = str(num3)
print(str3)
print(type(str3))

