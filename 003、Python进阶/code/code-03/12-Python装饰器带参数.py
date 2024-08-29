'''
带有参数的装饰器：① 有嵌套 ② 有引用 ③ 有返回
'''
def logging(fn):
    def inner(*args, **kwargs):
        # 添加装饰器代码（输出日志信息）
        print('-- 日志信息：正在努力计算机 --')
        # 执行要修饰的函数
        fn(*args, **kwargs)  # sum_num(a, b)
    return inner

@logging
def sum_num(*args, **kwargs):
    result = 0
    # *args代表不定长元组参数，args = (10, 20)
    for i in args:
        result += i
    # **kwargs代表不定长字典参数， kwargs = {a:30, b:40}
    for i in kwargs.values():
        result += i
    print(result)

# sum_num带4个参数，而且类型不同，10和20以元组形式传递，a=30，b=40以字典形式传递
sum_num(10, 20, a=30, b=40)