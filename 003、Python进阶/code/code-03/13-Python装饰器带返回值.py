'''
带有返回值的装饰器：① 有嵌套 ② 有引用 ③ 有返回
如果一个函数执行完毕后，没有return返回值，则默认返回None
'''
def logging(fn):
    def inner(*args, **kwargs):
        print('-- 日志信息：正在努力计算 --')
        return fn(*args, **kwargs)  # fn() = sub_num(20, 10) = result
    return inner

@logging
def sub_num(a, b):
    result = a - b
    return result

print(sub_num(20, 10))