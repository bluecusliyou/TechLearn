'''
文件读取也要分为三步走：
① 打开文件 f = open()
② 读取文件
③ 关闭文件 f.close()
在Python代码中，文件读取一共有3种方法：
read() : 读取文件的所有内容，可以添加一个参数size，代表读取字符长度
readlines() : 一次性读取文件的所有内容，返回结果是一个列表，列表中的每一个元素都是文件中的一行
readline() : 一次读取文件的一行，读取一次向后移动一次，直到文件读取完毕，很少自己使用，通常要配合while True
'''
# 1、第一种方法
# f = open('python.txt', 'r', encoding='utf-8')
# # content = f.read()  # 读取文件所有内容
# content = f.read(1)   # 代表只读取文件中的一个字符
# print(content)
# f.close()

# 2、第二种写法
# f = open('python.txt', 'r', encoding='utf-8')
# content = f.readlines()
# print(content)
# f.close()

# 3、第三种写法
f = open('python.txt', 'r', encoding='utf-8')
while True:
    content = f.readline()
    # 判断，如果读取不到任何内容，则结束循环
    if not content:
        break
    # 反之，如果没有执行break，则代表文件中还有内容
    print(content, end='')

print(content)
f.close()