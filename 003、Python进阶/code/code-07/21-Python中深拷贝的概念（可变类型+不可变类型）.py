'''
什么是深拷贝？所谓的深拷贝代表不仅可以拷贝外层对象，也可以拷贝内层对象。如果是可变数据类型，两者会指向不同的内存空间
结论：如果深拷贝拷贝的是一个不可变类型，其无法实现拷贝，两者还是指向相同的内存空间
'''
import copy

list1 = [1, 2, 3, (4, 5)]
list2 = copy.deepcopy(list1)

print(id(list1))
print(id(list2))

print(id(list1[3]))
print(id(list2[3]))