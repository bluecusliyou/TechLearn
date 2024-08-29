'''
在Python中，除了可以使用(推导式)方式来创建生成器对象以外，我们还可以通过函数 + yield方式来创建一个生成器。
这种创建方式是Python3中比较推荐的一种使用方式。
基本语法：
def 函数名称():
    ...
    yield 值
    ...
'''
def generator(n):
    for i in range(n):
        print('开始生成数据')
        yield i  # 暂时可以把yield关键字理解为return，相当于返回数据的含义 => return 0
        print('数据生成完成')

result = generator(5)
print(result)

print(next(result))
# 以上next(result)，先执行了print('开始生成数据')，然后通过yield关键字返回了第一个数据0，然后函数中止执行，但是要特别注意，这里只是暂停在yield i这个位置，当我们下一次执行生成器的时候，程序会在此结束位置开始继续执行
print('-' * 40)
print(next(result))
print('-' * 40)
print(next(result))