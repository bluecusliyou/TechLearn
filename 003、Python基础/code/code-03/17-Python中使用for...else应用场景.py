'''
案例：用for循环实现用户登录
① 输入账号和密码
② 判断账号和密码是否正确（username='admin'，password='admin888'），必须要同时匹配
③ 登录仅有三次机会，超过3次会报错
'''
# 第一步：编写一个循环，只能循环3次
for i in range(3):  # 0 1 2
    # 第二步：提示用户输入要登录的账号与密码
    username = input('请输入您的账号：')
    password = input('请输入您的密码：')

    # 第三步：对账号与密码进行判断，判断账号是否等于admin且密码是否等于admin888
    if username == 'admin' and password == 'admin888':
        print('恭喜您，登录成功!')
        break
    else:
        print('很抱歉，您的账号或密码输入有误，请重新输入！')
else:
    print('很抱歉，您的3次登录机会已用完，请10分钟以后再试！')