'''
局部变量：在局部作用域（函数的内部）中定义的变量就被称之为局部变量。
探讨一下局部变量访问范围：
① 局部变量是可以在局部作用域中访问的
② 局部变量是否可以在全局作用域中访问呢？答：不能，因为计算机的垃圾回收机制
综上所述：局部变量不是万能的，只能在局部作用域中访问，无法在全局作用域中访问，因为当函数执行完毕后，其局部变量会自动被计算机的内存所回收！

扩展：内存的垃圾回收机制
因为函数执行完毕后，其内部的局部变量与程序都要被计算机的内存所回收！
早期计算机内存只有2MB，所以需要即用即清，所以的计算机程序，都需要先加载数据到内存，局部变量也会占用一段内存空间。
又由于局部变量一般只在函数调用时被使用，当函数调用结束，其变量就变得没有价值。所以计算机的内存会自动执行清理操作把局部变量占用的空间及时回收，所以会导致，在全局作用域中无法直接访问局部变量！
'''

# 定义一个函数
def func():
    # 在函数内部定义一个局部变量
    num = 10
    print(f'在局部作用域中调用num局部变量：{num}')

# 调用func函数
func()
# 在全局作用域中调用num局部变量
print(f'在全局作用域中调用num局部变量：{num}') # 报错