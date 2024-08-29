'''
有一个函数，比如叫def outer():
到底print(outer)和打印print(outer())到底有什么区别？
'''
def outer():
    return 100

print(outer())  # outer()真正含义：找到outer函数在内存中的地址并立即执行其内部的代码
print(outer)    # 只返回outer指向的内存地址，但是其内部的代码并没有执行