import time
import threading

def work():
    for i in range(10):
        print('working...')
        time.sleep(0.2)

if __name__ == '__main__':
    # 创建一个子线程
    sub_thread = threading.Thread(target=work)
    # 启动子线程
    sub_thread.start()

    time.sleep(1)
    print('主线程代码执行结束！')