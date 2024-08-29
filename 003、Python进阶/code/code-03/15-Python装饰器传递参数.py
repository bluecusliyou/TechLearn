'''
通用装饰器：① 有嵌套 ② 有引用 ③ 有返回 ④ 有不定长参数 ⑤ 有return返回值
真正问题：通过装饰器传递参数，我们应该如何接收这个参数呢？
答：在logging方法的外侧在添加一个函数，专门用于接收传递过来的参数
'''

def logging(flag):
    # flag = + 或 flag = -
    def decorator(fn):
        def inner(*args, **kwargs):
            if flag == '+':
                print('-- 日志信息：正在努力进行加法运算 --')
            elif flag == '-':
                print('-- 日志信息：正在努力进行减法运算 --')
            return fn(*args, **kwargs)
        return inner
    return decorator

@logging('+')
def sum_num(a, b):
    result = a + b
    return result

@logging('-')
def sub_num(a, b):
    result = a - b
    return result

print(sum_num(10, 20))
print(sub_num(100, 80))