'''
os.rename(旧文件名称, 新文件名称)
os.remove('要删除的文件名称')

案例：把Python项目目录下的python.txt文件，更名为linux.txt，查看效果后，对文件进行删除操作。
'''
# 1、导入os模块
import os

# 2、对python.txt重命名为linux.txt
if os.path.exists('python.txt'):
    os.rename('python.txt', 'linux.txt')

# 3、把linux.txt移除
os.remove('linux.txt')