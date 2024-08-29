try:
    # 第一步：打开文件
    f = open('python.txt', 'r', encoding='utf-8')
    # 第二步：写入内容
    f.write('人生苦短，我学Python！')
except:
    # 第一步：打开文件
    f = open('python.txt', 'w', encoding='utf-8')
    # 第二步：写入内容
    f.write('人生苦短，我学Python！')
finally:
    f.close()