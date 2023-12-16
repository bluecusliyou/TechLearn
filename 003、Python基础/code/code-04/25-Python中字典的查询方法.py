'''
① 获取字典中的某个元素，字典名称[key]，代表访问指定的元素
② 字典也支持直接打印输出
③ 字典也可以配合for循环进行遍历，但是要特别注意：只有字典中的key可以遍历出来（默认）

其他方法：
keys() ：以列表方式返回字典中所有的key键
values() ：以列表方式返回字典中所有的value值
items() ：以外面是列表，里面每一个元素都是元组的方式获取字典中的key,value键值对 => [(key1, value1), (key2, value2)]
注意：以上三个方法很少单独使用，都要配合for循环进行遍历操作
'''
student = {'name':'Jack', 'age':20, 'address':'广州市天河区'}
# ① 直接获取字典中的某个元素
print(student['name'])
print(student['age'])
print(student['address'])

# ② 直接打印字典
print(student)

# ③ 使用for循环直接对字典进行遍历
for key in student:
    print(key)

# ④ 使用keys方法获取字典中所有的key键与上面的代码等价
for key in student.keys():
    print(key)

# ⑤ 使用values()方法获取字典中所有的value值
for value in student.values():
    print(value)

# ⑥ 使用items()方法获取字典中的key, value键值对
for key, value in student.items():
    print(f'{key}：{value}')