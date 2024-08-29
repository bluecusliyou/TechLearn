import time
import multiprocessing

# 定义一个work任务
def work():
    for i in range(10):
        print('working...')
        time.sleep(0.2)

# 定义一个入口程序
if __name__ == '__main__':
    # 创建一个子进程（大约需要2s执行完毕）
    sub_process = multiprocessing.Process(target=work)
    sub_process.start()

    # 休眠1s
    time.sleep(1)
    print('主进程代码已经执行结束！')

# 主进程代码执行结束后，整个程序并不会立即结束，而是等待子进程执行结束，当子进程执行结束后，整个主进程才能真正结束！
# 结论：主进程默认会等待子进程的结束而结束
