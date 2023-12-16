'''
在Python中，字符串类型的数据每个字符都有一个编号，我们称之为索引下标，默认从0开始，到字符串最大长度-1结束。
str1 = 'myname'
str1[0] 对应 字符m
str1[1] 对应 字符y
还可以通过 字符名称[索引下标] 来访问字符串中的某个或某几个字符

len(字符串名称) ：代表获取字符串的长度
'''
str1 = 'abcdef'
# print(str1[0])  # a
# print(str1[1])  # b
# print(str1[2])  # c
# print(str1[3])  # d
# print(str1[4])  # e
# print(str1[5])  # f
#
# print(str1[6])  # 报错：out of range

# 使用while循环或for循环遍历
i = 0
while i < len(str1):  # abcdef一共6个字符，循环条件 0 < 6 取值0 1 2 3 4 5
    print(str1[i])
    i += 1

for i in str1:
    print(i)