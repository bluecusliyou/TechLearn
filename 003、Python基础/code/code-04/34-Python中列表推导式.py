'''
列表推导式就是用于简化以下代码：
① for循环结构
list1 = []
for i in range(10):
    list1.append(i)
简化为推导式：
list2 = [i(列表中最终的元素) for i in range(10)]

② for循环 + if嵌套结构
# 案例1：生成一个列表，包含0-9之间所有的偶数 => [0, 2, 4, 6, 8]
'''
list1 = []
for i in range(10):
    if i % 2 == 0:
        list1.append(i)
print(list1)

# 简化为列表推导式
list2 = [i for i in range(10) if i % 2 == 0]
print(list2)

# 案例2：有一个列表，里面内容为[1, 2, 3, 4, 5]，通过Python代码将其转换为[1, 4, 9, 16, 25]
list3 = [1, 2, 3, 4, 5]
list4 = []
for i in list3:
    list4.append(i ** 2)
print(list4)

list5 = [i ** 2 for i in list3]
print(list5)  # 1, 4, 9, 16, 25