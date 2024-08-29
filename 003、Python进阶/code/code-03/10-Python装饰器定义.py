'''
装饰器：本质就是一个闭包 ① 有嵌套 ② 有引用 ③ 有返回
'''
def check(fn):

    def inner():
        # 开发登录验证功能
        print('验证登录')
        # 执行原有函数
        fn()
    return inner

@check
def comment():
    print('发表评论')

comment()