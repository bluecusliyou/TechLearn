'''
replace(old, new) ： 把字符串中的关键词进行替换
split(分隔符号) ：使用分割符号对字符串进行切割，返回一个列表，列表中的每一个元素就是分隔符两边的数据
join(列表容器) ：把一个列表在拼接为字符串
'''
str1 = 'hello python'
print(str1.replace('python', 'bigdata'))  # hello bigdata

str2 = 'apple-banana-orange'
list2 = str2.split('-')
print(list2)  # ['apple', 'banana', 'orange']

list3 = ['apple', 'banana', 'orange']
print('-'.join(list3)) #apple-banana-orange