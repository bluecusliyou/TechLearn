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
    # 第一种解决方案：守护进程
    sub_process.daemon = True
    sub_process.start()

    # 休眠1s
    time.sleep(1)
    print('主进程代码已经执行结束！')