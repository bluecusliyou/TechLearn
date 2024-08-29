'''
浅拷贝只能拷贝外层数据，内层嵌套数据是一种引用关系无法拷贝，所以内层对象还是指向原来的内存地址！
'''
import copy

list1 = [1, 2, 3, [4, 5]]
list2 = copy.copy(list1)

print(id(list1))
print(id(list2))  # 不同

print(id(list1[3]))
print(id(list2[3]))  # 相同


