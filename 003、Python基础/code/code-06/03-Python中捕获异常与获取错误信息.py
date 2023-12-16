'''
在实际工作中，不仅需要对异常进行捕获，还需要把异常信息写入到日志文件（具体是什么错误找到）
try:
    可能出现异常的代码
except Exception as e:
    print(e)  # 代表出错的异常信息 => 实际工作以后，写入日志文件中
'''
try:
    f = open('python.txt', 'r')
except Exception as e:
    print(f'-- 日志: {e} --')
    print('找到错误的同时，执行B方案！')