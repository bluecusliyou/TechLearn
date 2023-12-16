'''
在Python中，通过\字符表示的特殊形式就称之为转义字符。转义字符常见的有这样两种形式：
① \t ：制表符，等价于一个Tab键或者4个空格
② \n ：换行符，一旦在字符串中遇到了\n，则后面的内容自动另起一行

扩展：print()完整写法print(变量名称, end='\n')代表在输出变量以后，会自动在变量的后面追加一个\n
'''
print('hello\npython')
print('*')
print('*\t*')
print('*\t*\t*')
print('*\t*\t*\t*')
print('*\t*\t*\t*\t*')

# 扩展：思考一个问题，为什么每次使用print()打印变量以后都会自动换行呢？
name = '张三'
age = 23
print(name, end='')
print(age, end='')