import time
# 第一步：导入多任务包
import multiprocessing

# 定义一个music()函数，用于实现听音乐功能
# 参数n代表循环次数
def music(n):
    for i in range(n):
        print('正在听音乐...')
        time.sleep(0.2)

# 定义一个coding()函数，用于实现写代码功能
# 参数t代表休眠时间
def coding(t):
    for i in range(3):
        print('正在写代码...')
        time.sleep(t)

# 定义一个程序的执行入口
if __name__ == '__main__':
    # 第二步：创建子进程对象
    music_process = multiprocessing.Process(target=music, args=(3,))
    coding_process = multiprocessing.Process(target=coding, kwargs={'t':0.2})

    # 第三步：启动子进程
    music_process.start()
    coding_process.start()
