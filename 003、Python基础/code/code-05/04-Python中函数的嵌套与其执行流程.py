'''
所谓函数嵌套调用指的是一个函数里面又调用了另外一个函数。
学习重点：① 函数嵌套的基本语法
        ② 掌握函数嵌套的执行流程
'''
# 1、定义一个testB函数
def testB():
    print('----- testB start -----')
    print('testB函数体代码...')
    print('----- testB end -----')

# 2、定义testA函数
def testA():
    print('----- testA start -----')
    # 所谓的嵌套就是在一个函数的内部又调用了另外一个函数
    testB()
    print('----- testA end -----')

# 3、执行testA函数
testA()