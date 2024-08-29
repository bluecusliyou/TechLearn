'''
通用装饰器：① 有嵌套 ② 有引用 ③ 有返回 ④ 有不定长参数 ⑤ 有return返回值
'''
def logging(fn):
    def inner(*args, **kwargs):
        # 输出装饰器功能
        print('-- 正在努力计算 --')
        # 调用fn函数
        return fn(*args, **kwargs)
    return inner


@logging
def sum_num1(a, b):
    result = a + b
    return result

print(sum_num1(20, 10))

@logging
def sum_num2(a, b, c):
    result = a + b + c
    return result

print(sum_num2(10, 20, 30))