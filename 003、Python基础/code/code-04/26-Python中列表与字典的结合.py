'''
列表：特别适合保存多个数据
字典：特别适合保存一个事物的信息，如一个人、一本书、一个商品等等
把列表 + 字典结合起来就可以同时保存多个事物的信息，比如多个人、多本书、多个商品
比如开发一个学生管理系统
'''
# 1、定义一个大列表，里面用于保存多个同学的信息
students = []

# 2、定义一个字典，把字典追加到列表中，形成以下结构 => [{}, {}, {}]
student = {'name':'岁鹏', 'age':23, 'mobile': '10086'}
students.append(student)
print(students) # [{'name': '岁鹏', 'age': 23, 'mobile': '10086'}]

# 3、把字典追加到列表中
student = {'name':'小美', 'age':19, 'mobile': '10010'}
students.append(student)
print(students) # [{'name': '岁鹏', 'age': 23, 'mobile': '10086'}, {'name': '小美', 'age': 19, 'mobile': '10010'}]