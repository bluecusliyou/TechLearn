'''
time模块是一个与日期时间相关的模块，主要拥有这样两个方法
time.sleep(秒数) ：休眠
time.time() ：获取当前时间，返回的是一个数字，我们经常使用time.time()获取程序执行时间
'''
# 1、导入time模块
import time

# 2、程序开始前，获取一个时间点
start = time.time()
# 定义一个列表
list1 = []
for i in range(10000000):
    list1.append(i)
# 3、当程序执行结束，获取一个时间点
end = time.time()

print(f'以上程序执行一共消耗了{end - start}s时间！')