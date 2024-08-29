'''
正则表达式 => ① 查什么 ② 查多少 ③ 从哪查
import re模块
要用到的知识点：match() => re.match('正则表达式', 字符串)
match只能匹配出以正则开头的内容，使用match匹配某个字符
'''
import re
# 1、匹配字符串中的第一个数字字符
str1 = '6abcdefg'
result = re.match('\d', str1)
if result:
    print(result.group())

# 2、匹配任意某1个字符
str2 = '@abcd123'
result = re.match('.', str2)
if result:
    print(result.group())

# 3、匹配aeiou字符中的任意某个字符
str3 = 'abcdefg'
result = re.match('[aeiou]', str3)
if result:
    print(result.group())

# 4、匹配空白字符\s字符串
str4 = ' admin'
result = re.match('\s', str4)
if result:
    print(len(result.group()))

# 5、字符簇取反[0-9] => [^0-9]匹配0-9以外的其他某1个字符
str5 = 'z12345'
result = re.match('[^0-9]', str5)
if result:
    print(result.group())

# 6、匹配26个字符中的任意某个字符
str6 = 'Abc123'
result = re.match('[a-zA-Z]', str6)
if result:
    print(result.group())

# 7、匹配0-9或a-z或A-Z或_中的任意某1个字符
str7 = '_bc123'
result = re.match('\w', str7)
if result:
    print(result.group())