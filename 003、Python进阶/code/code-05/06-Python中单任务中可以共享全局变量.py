'''
在单任务中，多个函数之间是可以共享全局变量的。
'''
import time

my_list = []

def write_data():
    for i in range(3):
        my_list.append(i)
        print('add：', i)
    print(my_list)

def read_data():
    print(my_list)

if __name__ == '__main__':
    write_data()# [0, 1, 2]
    time.sleep(1)
    read_data()# [0, 1, 2]
