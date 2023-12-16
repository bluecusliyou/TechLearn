'''
字典的删除操作主要删除字典中满足条件的key:value键值对！
基本语法：
del 字典名称[key]
解析：根据字典中的key，删除满足条件的key:value键值对
'''
# 1、定义一个有数据的字典
student = {'name':'陈城', 'age':23, 'gender':'male'}

# 2、删除字典中的age:23
del student['age']
print(student) # {'name': '陈城', 'gender': 'male'}