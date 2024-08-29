import os
import time
import multiprocessing

# 定义一个任务working，专门用于实现某个任务
def working():
    print(f'获取当前子进程编号：{os.getpid()}')
    print(f'获取当前进程的主进程编号：{os.getppid()}')
    for i in range(3):
        print('working...')
        time.sleep(0.2)

# 定义程序的执行入口
if __name__ == '__main__':
    # 第一步：获取主进程的编号
    print(f'主进程编号：{os.getpid()}')

    # 第二步：创建一个子进程
    sub_process = multiprocessing.Process(target=working)
    sub_process.start()