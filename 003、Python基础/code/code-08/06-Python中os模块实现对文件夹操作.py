'''
import os模块

os.mkdir() 创建一个文件夹
os.getcwd() 获取当前程序工作目录
os.chdir()  =>  change directory，切换目录
os.listdir() => list directory，以列表形式展现一个目录下的所有文件信息
os.rmdir()  =>  remove directory，移除目录（删除文件夹，缺点：只能删除空文件夹）

案例：准备一个static文件夹以及file1.txt、file2.txt、file3.txt三个文件
① 在程序中，将当前目录切换到static文件夹
② 创建一个新images文件夹以及test文件夹
③ 获取目录下的所有文件
④ 移除test文件夹
'''
import os

# 1、我目前在什么位置
print(os.getcwd())
# 2、把当前工作目录切换到static文件夹
os.chdir('static')
# 3、创建images与test文件夹
if not os.path.exists('images'):
    os.mkdir('images')
if not os.path.exists('test'):
    os.mkdir('test')
# 4、获取一个目录下的所有文件
files = os.listdir()
print(files)
# 5、删除目录
if os.path.exists('test'):
    os.rmdir('test')