'''
在循环中，有这样一个关键字叫做continue，代表中止本次正在执行的循环结构，继而进入下一次循环
'''
# 1、定义一个计数器
i = 1
# 2、编写循环条件
while i <= 5:
    # 4、添加一个判断条件
    if i == 3:
        print('不好，有大虫，这个苹果不吃了！')
        # 特别注意：在while循环中，continue关键字之前一定要手工更新一下计数器，否则就是一个死循环
        i += 1
        continue

    print(f'正在吃第{i}个苹果！')
    # 3、在循环体内部更新计数器的值
    i += 1