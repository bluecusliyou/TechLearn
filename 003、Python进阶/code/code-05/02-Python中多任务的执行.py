import time
# 第一步：导入多进程包
import multiprocessing

# 定义一个music()函数，用于实现听音乐功能
def music():
    for i in range(3):
        print('正在听音乐...')
        time.sleep(0.2)

# 定义一个coding()函数，用于实现写代码功能
def coding():
    for i in range(3):
        print('正在写代码...')
        time.sleep(0.2)

# 定义一个程序的执行入口
if __name__ == '__main__':
    # ... 主进程
    # 第二步：在主进程中创建两个子进程
    music_process = multiprocessing.Process(target=music)
    coding_process = multiprocessing.Process(target=coding)
    # 第三步：启动刚才创建的子进程
    music_process.start()
    coding_process.start()