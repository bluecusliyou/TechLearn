'''
with语句：上下文管理器 => with语句通常有两部分操作（上文、下文）
如果是文件操作 => 上文管理器负责打开文件，下文管理器负责关闭文件，而且关闭操作是自动的，即使遇到了异常也会自动关闭
with open('python.txt', 'w') as f:
    content = f.read()
    print(content)
    # 当文件执行结束，with语句会自动关闭刚才产生的f文件对象
'''
with open('python.txt', 'r', encoding='utf-8') as f:
    content = f.read()
    print(content)