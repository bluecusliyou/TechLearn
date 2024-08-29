'''
要用到的知识点：获取进程的信息
# 通过current_thread方法获取线程对象
current_thread = threading.current_thread()
# 通过current_thread对象可以知道线程的相关信息，例如被创建的顺序
print(current_thread)
'''
import time
import threading

def get_info():
    time.sleep(0.2)
    current_thread = threading.current_thread()
    print(current_thread)


if __name__ == '__main__':
    # 创建10个子线程 => 按顺序创建
    for i in range(10):  # 0 1 2 3 4 5 6 7 8 9
        sub_thread = threading.Thread(target=get_info)
        sub_thread.start()