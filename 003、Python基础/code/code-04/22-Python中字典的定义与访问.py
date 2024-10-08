'''
在Python中，有一种比较特殊的数据类型叫做字典类型，其特别适合保存一个事物的信息。如一个人的信息、一本书的信息、一个商品的信息等等。
一个人：姓名、性别、年龄
一本书：标题、价格、出版社
一个商品：标题、描述、价格、库存...
字典是如何定义的？基本语法：
字典名称 = {key1:value1, key2:value2, key3:value3}
注意事项：字典中是没有索引下标的，其是通过key:value键值对来体现键（等价于索引下标）与值的关系
key：键名，必须是唯一的且没有顺序要求，其可以是（字符串类型、数字化类型）或者元组类型
value：代表的字典中具体的元素值

常见问题答疑：
① 字典是没有切片的，不被允许的，因为字典没有索引下标
② 创建有数据的字典，只能通过{}大括号，不能通过dict()方法
③ 无论key还是value，遵循一个原则：如果是字符串类型，则添加引号。如果是数值类型，则不需要添加引号
'''
# 1、定义一个空字典
dict1 = {}
dict2 = dict()

print(type(dict1))
print(type(dict2))

# 2、定义一个有数据的字典
dict3 = {'name':'Tom', 'gender':'male', 'age':20}

# 3、输出字典
print(dict3)

# 4、访问字典中具体某个value值 => 字典名称[key]
print(dict3['name'])
print(dict3['gender'])
print(dict3['age'])