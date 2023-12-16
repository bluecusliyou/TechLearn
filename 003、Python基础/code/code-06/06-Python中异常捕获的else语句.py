'''
try:
    可能出现异常的代码
except:
    捕获异常
else:
    当try语句中的代码没有出现异常，则执行else语句中的代码，反之，则不执行
'''
try:
    f = open('python.txt', 'r')
except:
    f = open('python.txt', 'w')
else:
    content = f.read()
    print(content)