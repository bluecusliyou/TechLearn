'''
+ 代表合并操作，主要针对字符串、列表、元组
'''
str1 = 'hello'
str2 = 'python'
print(str1 + str2)

list1 = [1, 3, 5]
list2 = [2, 4, 6]
print(list1 + list2)

tuple1 = (1, 2, 3)
tuple2 = (3, 4, 5)
print(tuple1 + tuple2)

# 乘法代表复制
print('-' * 40)
print([10] * 4)  # [10, 10, 10, 10]

# in方法，判断元素是否出现在容器中
str3 = 'python+bigdata'
if 'bigdata' in str3:
    print('bigdata exist in the str3')
else:
    print('bigdata exist not in the str3')