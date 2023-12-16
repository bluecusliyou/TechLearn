'''
在Python中，字典的新增与修改使用的是相同的语法：
字典名称[key] = value值

① 如果字典中没有这个key，以上就是一个新增操作
② 如果字典中有这个key，以上就是修改操作
'''
# 1、定义一个空字典
person = {}

# 2、添加数据 => key:value键值对
person['name'] = 'Tom'
person['age'] = 20
person['gender'] = 'male'
print(person) # {'name': 'Tom', 'age': 20, 'gender': 'male'}

# 3、修改数据 => 字典名称[已存在的key] = value值
person['age'] = 21
print(person) # {'name': 'Tom', 'age': 21, 'gender': 'male'}