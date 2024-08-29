'''
在Python代码中，我们可以在多任务中使用args或kwargs进行传参
args：以元组方式传递参数
kwargs：以字典方式传递参数
'''
import time
# 第一步：导入多线程模块
import threading

# 参数n代表循环次数
def music(n):
    for i in range(n):
        print('正在听音乐...')
        time.sleep(0.2)

# 参数t代表休眠时间
def coding(t):
    for i in range(3):
        print('正在写代码...')
        time.sleep(t)

if __name__ == '__main__':
    # 第二步：创建多线程对象
    music_thread = threading.Thread(target=music, args=(3,))
    coding_thread = threading.Thread(target=coding, kwargs={'t':0.2})

    # 第三步：启动多线程
    music_thread.start()
    coding_thread.start()