# 第一步：打开文件
f = open('python.txt', 'r', encoding='utf-8')
# 第二步：写入内容
f.write('人生苦短，我学Python！')  # 出现了异常，not writable，如果此代码出错，会导致下方代码无法执行
# 第三步：关闭文件
f.close()