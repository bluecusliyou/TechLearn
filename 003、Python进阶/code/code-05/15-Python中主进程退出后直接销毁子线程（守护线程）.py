import time
import threading

def work():
    for i in range(10):
        print('working...')
        time.sleep(0.2)

if __name__ == '__main__':
    # 创建一个子线程
    # 方案一：守护主线程
    # sub_thread = threading.Thread(target=work, daemon=True)
    # 方案二：通过方法设置守护主线程
    sub_thread = threading.Thread(target=work)
    sub_thread.setDaemon(True)

    # 启动子线程
    sub_thread.start()

    time.sleep(1)
    print('主线程代码执行结束！')