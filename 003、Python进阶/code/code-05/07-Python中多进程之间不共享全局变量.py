'''
在单任务中，多个函数之间是可以共享全局变量的。
在多进程多任务中，多个进程之间无法共享全局变量。
'''
import time
import multiprocessing

my_list = []

def write_data():
    for i in range(3):
        my_list.append(i)
        print('add：', i)
    print(my_list)

def read_data():
    print(my_list)

if __name__ == '__main__':
    # 创建子进程
    write_process = multiprocessing.Process(target=write_data)
    read_process = multiprocessing.Process(target=read_data)

    # 启动子进程
    write_process.start()#[0, 1, 2]
    time.sleep(1)
    read_process.start()#[]
