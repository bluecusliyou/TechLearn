# 1、使用正则表达式匹配数字8
import re

str1 = '13567006604'
result = re.findall('8', str1)
if result:
    print(result)
else:
    print('暂未匹配到任何数据！')

# 2、查找一个字符串中是否具有数字(0-9)
str2 = 'abcdef9ghij6kl1mn'
result = re.findall('[0-9]', str2)
print(result)

# 3、查找一个字符串中是否具有非数字
str3 = '12345a67b89c0'
result = re.findall('[^0-9]', str3)
print(result)
