'''
增加方法：add()，主要用于向集合中添加数据
删除方法：remove()，根据值删除指定的元素
        pop()，删除第一个元素，删除后，pop()方法返回被删除的那个元素
查询方法：if 元素 in 集合，判断元素是否出现在集合中，出现True，反之，则返回False
'''
# 1、定义一个空集合
set1 = set()

# 2、想其追加数据
set1.add(10)
set1.add(20)
set1.add(30)
set1.add(20)
set1.add(40)
print(set1) # {40, 10, 20, 30}

# 3、在2的基础上，删除20这个元素
set1.remove(20)
print(set1) # {40, 10, 30}

# 4、删除第一个元素
set1.pop()
print(set1) # {10, 30}

# 5、判断元素是否出现在集合中
if 10 in set1:
    print('10 exist in the set1')
else:
    print('10 not exist in the set1')