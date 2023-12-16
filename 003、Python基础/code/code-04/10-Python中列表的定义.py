'''
为什么需要列表？
答：列表是容器的一种，允许我们在一个列表容器中同时保存多个数据信息

列表的定义
列表名称 = [元素1, 元素2, 元素3]

在Python中，列表中的每一个元素也有一个对应的索引下标，默认从0开始，所以我们也可以通过：
列表名称[索引下标]
实现对列表中某个元素的访问！
'''
names = ['张三', '李四', '王五', '赵六']
print(names)
print(type(names))  # list => 列表类型

# 访问李四
print(names[1])
print(names[2])

# 对列表进行遍历操作
i = 0
while i < len(names):
    print(names[i])
    i += 1

for i in names:
    print(i)