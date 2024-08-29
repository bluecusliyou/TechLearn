import copy

# 定义两个变量都是可变数据类型
a = [1, 2, 3]
b = [11, 22, 33]

list1 = [a, b]  # [[1, 2, 3], [11, 22, 33]]
# print(id(list1))
print(id(list1[0]))  # a的内存地址

list2 = copy.copy(list1)
# print(id(list2))
print(id(list2[0]))  # 拷贝后a的内存地址