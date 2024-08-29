'''
正则三步走之查多少，到底要匹配多少个字符
普通字符或元字符* : 0或多，匹配前面的字符出现0次或多次，实际工作中，经常和.号配合使用，代表匹配任意字符.*
普通字符或元字符+ : 1或多，匹配前面的字符出现1次或多次，至少要出现1次，至多出现N次
普通字符或元字符? : 0或1，匹配前面的字符出现0次或1次
普通字符或元字符{m} : 匹配前面的字符出现m次
普通字符或元字符{m,} : 匹配前面的字符至少出现m次
普通字符或元字符{m,n} : 匹配前面的字符至少出现m次，至多出现n次

注意：限定符，默认只能限定前面的第一个字符，比如10?，只能限定0不能限定1
101? 前面必须是10,1可以出现也可以不出现 => 首先匹配101，如果101匹配不到，则匹配10
'''
import re

# 1、匹配连续的3位纯数字
str1 = '666abcd'
result = re.match('\d{3}', str1)
if result:
    print(result.group())

# 2、匹配1或10开头的字符
str2 = '1abcabc'
result = re.match('10?', str2)
if result:
    print(result.group())

# 3、匹配所有字符
str3 = '<img src="avatar.jpg">'
result = re.match('.*', str3)
if result:
    print(result.group())

# 4、至少匹配连续4位字符(a-z)
str4 = 'abcdefg123'
result = re.match('[a-z]{4,}', str4)
if result:
    print(result.group())