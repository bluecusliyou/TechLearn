'''
闭包三步走：① 有嵌套 ② 有引用 ③ 有返回
闭包作用？当函数执行完毕后，让局部变量一直驻留在内存中
'''
def func():
    # 局部变量
    result = 0
    # 嵌套函数
    def inner(num):
        # 访问离它最近的局部变量
        nonlocal result
        # 针对result与num参数相加
        result += num
        print(result)
    return inner

fn = func()
fn(1)  # 1
fn(2)  # 3
fn(3)  # 6