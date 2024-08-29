# 要求：把登录功能封装起来（比如封装成一个函数，添加这个登录不能影响现有功能函数）
'''
装饰器：本质是一个闭包，有嵌套、有引用、有返回（返回的是函数的内存地址）
参数fn在check中也是一个局部变量
参数fn：就是要装饰的函数的函数名，如comment，如download
'''
def check(fn):
    def inner():
        # 开发登录功能
        print('登录功能')
        # 调用原函数
        fn()
    return inner

# 评论功能（前提：登录）
def comment():
    print('评论功能')

comment = check(comment)
comment()

# 下载功能（前提：登录）
def download():
    print('下载功能')

download = check(download)
download()