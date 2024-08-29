'''
多进程实现多任务：无法共享全局变量
多线程实现多任务：因为所有线程都位于同一个进程中，所以不仅资源共享，而且全局变量也是共享的
'''
import time
import threading

my_list = []

# 定义一个write_data()任务
def write_data():
    for i in range(3):
        my_list.append(i)
        print('add：', i)
    print(my_list)

# 定义一个read_data()任务
def read_data():
    print(my_list)

if __name__ == '__main__':
    # 创建两个子线程
    write_thread = threading.Thread(target=write_data)
    read_thread = threading.Thread(target=read_data)

    write_thread.start() # [0, 1, 2]
    time.sleep(1)
    read_thread.start()  # [0, 1, 2]