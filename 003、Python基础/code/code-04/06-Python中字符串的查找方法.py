'''
find()方法：主要功能就是查找关键词在字符串中出现的位置，找到了就返回开始的索引下标，没有找到，返回-1
'''
str1 = 'hello python'
# 查找python关键字在字符串中出现的位置
print(str1.find('python'))  # 6（关键字所在位置）
print(str1.find('bigdata'))  # -1（未找到对应的内容）