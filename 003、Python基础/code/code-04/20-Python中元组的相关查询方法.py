'''
由于元组特性：一旦定义成功以后，就不能进行修改和删除了。所以其方法主要都是查询方法
① 元组名称[索引编号] : 访问元组中的某个元素
② len(元组名称) : 求元组中元素的个数（总长度）
③ if 元素 in 元组 : 判断元素是否出现在元组中，出现返回True，没有出现，则返回False
'''
tuple1 = ('刘备', '关羽', '张飞')
print(tuple1[0])
print(tuple1[1])
print(tuple1[2])

tuple2 = (10, 20, 30, 40, 10)
print(len(tuple2))

if '关羽' in tuple1:
    print('关羽这个元素出现在tuple1元组中')
else:
    print('关羽这个元素没有出现在tuple1元组中')