'''
在Python代码中，变量的定义我们可以使用:
    变量名称 = 变量的值
特别注意：变量的名称不能随意命名，需要遵循一定的命名规则
变量命名规则：
① 变量名称只能由字母、数字或下划线组成
② 不能以数字开头
③ 严格区分大小写,a和A是两个完全不同的变量
④ 不能使用Python保留关键字 => if/while/for/list/tuple/dict/set等等都属于保留关键字 => help('keywords')

具备技能：看到一个变量，一定要第一时间能识别它是否是一个合法的变量名称！
建议：在实际定义过程中，可以使用英文单词或者拼音来表示！
'''
# help('keywords')
# 定义几个变量，用于保存一个人的信息
name = '刘国晓'  # ''/""引号引起来的内容都称之为“字符串”
age = 23
address = '广州市天河区'

print(name)
print(age)
print(address)

# 在Python代码中，print()也可以同时输出多个变量
print(name, age, address)