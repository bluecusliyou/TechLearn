'''
在Python代码中，一个Python文件可以创建一个进程 => 创建多线程
线程包含在进程内部，一个进程理论上最少有一个线程
① 进程资源分配最小单元 => 申请资源
② 线程专门用于执行程序（干活的）
'''
import time
# 第一步：导入多线程模块
import threading

def music():
    for i in range(3):
        print('正在听音乐...')
        time.sleep(0.2)

def coding():
    for i in range(3):
        print('正在写代码...')
        time.sleep(0.2)

if __name__ == '__main__':
    # 第二步：创建多线程对象
    music_thread = threading.Thread(target=music)
    coding_thread = threading.Thread(target=coding)

    # 第三步：启动多线程
    music_thread.start()
    coding_thread.start()