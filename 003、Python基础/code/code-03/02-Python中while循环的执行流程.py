'''
举个栗子：循环打印输出1-5
Debug工具有两步：
① 打断点
② 启动调试 => step over工具

使用Debug调试工具，了解while循环执行流程：
第一步：代码都是从上往下一行一行执行，所以先执行i = 1这一行代码
第二步：执行到while i <= 5这一行，对变量i进行判断，判断是否满足循环条件，如果满足，则继续向下执行，如果不满足，则
while循环执行结束，继续向下执行；由于 1 <= 5，所以执行到循环体的内部，输出i = 1，然后进行i += 1操作，此时i = 2
第三步：执行了i += 1以后，返回到while i <= 5位置，判断i是否小于5,2 <= 5，条件成立，继续往循环内部执行
....
直到i = 6时，条件不成立，则循环结束
'''
# 1、定义一个计数器
i = 1
# 2、编写一个循环条件
while i <= 5:
    # 编写要循环输出的代码
    print(i)
    # 3、在循环体内部（缩进）更新计数器的值
    i += 1