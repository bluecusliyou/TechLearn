'''
定义获取程序的执行时间装饰器 => 闭包（① 有嵌套 ② 有引用 ③ 有返回）
'''
import time

def get_time(fn):
    def inner():
        # ① 添加装饰器修饰功能（获取程序的执行时间）
        begin = time.time()
        # ② 调用fn函数，执行原函数代码
        fn()
        end = time.time()
        print(f'这个函数的执行时间：{end - begin}')
    return inner


@get_time
def demo():
    for i in range(1000000):
        print(i)

demo()