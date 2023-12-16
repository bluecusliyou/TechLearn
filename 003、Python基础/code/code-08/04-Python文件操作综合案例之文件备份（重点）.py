'''
需求：用户输入当前目录下任意文件名，完成对该文件的备份功能(备份文件名为xx[备份]后缀，例如：(test[备份].txt)。
① 命名变化：test.txt => 备份 => test[备份].txt
② 内容变化：需要把旧文件中的内容完全拷贝到新文件中
分析：命名变化如何实现
test.txt => test[备份].txt？
☆ 提示用户输入要备份的文件名称
☆ 分别获取文件的名称以及文件的后缀 => (文件名 => test 后缀 => .txt)
☆ 重新拼接新文件 test + [备份] + .txt
新方法：rfind()方法，从左向右查找，返回这个关键词在最后一次出现的位置
test.abc.txt

分析：文件内容变化
旧文件 => 读取操作
新文件 => 写入操作
把旧文件的内容全部读取出来写入到新文件中，但是文件如果比较大，考虑使用read或readline
'''
oldname = input('请输入您要备份的文件名称：')
# oldname = 'test.txt'，拆解文件名与文件的后缀
index = oldname.rfind('.')
# 获取文件名称
filename = oldname[:index]  # test
postfix = oldname[index:]   # .txt
# 拼接新文件名称
newname = filename + '[备份]' + postfix

# 创建old_f文件句柄与new_f文件句柄
old_f = open(oldname, 'rb')
new_f = open(newname, 'wb')
while True:
    content = old_f.read(1024)  # r模式size代表字符长度，rb模式size代表字节大小 => 1KB
    if not content:
        break
    new_f.write(content)
# 操作完成后，关闭文件
old_f.close()
new_f.close()