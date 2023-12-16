'''
特别特殊的数据类型转换方法
eval() : 把字符串类型的数据转换为原数据类型，简单来说就是字符串中的数据像什么就转化为什么类型
'10' => eval => int
'9.88' => eval => float
'123abc' => eval => 报错 => 本身无法发生转换，因为里面的内容没有意义
eval方法必须发生类型转换，如果想把一个字符串在转换为字符串，eval方法会报错的！

注意：类型转换中的数据必须是有意义的！
'''
str1 = '10'
num1 = eval(str1)
print(num1)
print(type(num1))

str2 = '9.88'
num2 = eval(str2)
print(num2)
print(type(num2))

# 错误演示
# str3 = '123abc'
# num3 = eval(str3)
# print(num3)

# str4 = '9.88'
# num4 = int(str4)  # 正确转换方法 str => float => int
# print(num4)