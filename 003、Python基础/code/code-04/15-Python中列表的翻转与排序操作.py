'''
reverse() ：字符串的翻转操作，相当于切片中的[::-1]
sort(reverse=False) ：把列表中的元素从小到大排序，也可以通过更改参数让其从大到小排序
'''
list1 = [5, 3, 2, 7, 1, 9]
list2 = ['刘备', '关羽', '张飞']

# 列表翻转
list2.reverse()
print(list2)#['张飞', '关羽', '刘备']

# 列表翻转
print(list2[::-1])#['刘备', '关羽', '张飞']

# 列表排序
list1.sort(reverse=True)
print(list1)#[9, 7, 5, 3, 2, 1]