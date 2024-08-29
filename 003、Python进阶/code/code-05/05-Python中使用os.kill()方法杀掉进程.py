'''
import os

os.kill(进程PID编号, 传递的信号)
信号：
9 ： 强制杀掉PID进程
15 ：通知PID进程，正常结束
'''
import os

os.kill(12752, 9)