import time

# 定义一个函数，用于实现听音乐
def music():
    for i in range(3):
        print('正在听音乐...')
        time.sleep(0.2)

# 定义一个函数，用于实现写代码
def coding():
    for i in range(3):
        print('正在写代码...')
        time.sleep(0.2)

# 定义一个程序执行的入口
if __name__ == '__main__':
    music()
    coding()