'''
append() : 在列表的尾部追加元素，append()方法本身不返回任何内容，所以我们追加完毕后，要打印原列表
+ 加号 : 可以把两个列表进行合并操作
'''
list1 = ['刘备', '曹操']
# 希望向列表中追加一个元素
list1.append('孙权')
# 打印list1
print(list1) #['刘备', '曹操', '孙权']

list2 = ['贾宝玉', '薛宝钗']
list3 = ['林黛玉', '刘姥姥']
print(list2 + list3)#['贾宝玉', '薛宝钗', '林黛玉', '刘姥姥']
