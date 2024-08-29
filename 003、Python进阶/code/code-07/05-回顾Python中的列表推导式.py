'''
推导式：把一个有规律的数据推导为列表结构（有规律），主要作用：用于简化for...in循环代码
'''
list1 = []
for i in range(10):
    list1.append(i)
print(list1)

# 把以上代码更改为推导式的形式
list2 = [i for i in range(10)]
print(list2)