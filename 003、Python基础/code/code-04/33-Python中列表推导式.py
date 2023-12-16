'''
案例：生成一个0-9之间的列表，[0, 1, 2, 3, ..., 7, 8, 9]
'''
# 1、while循环
i = 0
list1 = []
while i < 10:
    list1.append(i)
    i += 1
print(list1)

# 2、for循环
list2 = []
for i in range(10):
    list2.append(i)
print(list2)

# 3、推导式的概念 => 用于推导生成一个有规律的列表
list3 = [i for i in range(10)]
print(list3)