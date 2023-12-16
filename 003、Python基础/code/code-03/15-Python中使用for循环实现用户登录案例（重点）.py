'''
案例：用for循环实现用户登录
① 输入账号和密码
② 判断账号和密码是否正确（username='admin'，password='admin888'），必须要同时匹配
③ 登录仅有三次机会，超过3次会报错
④ 如果用户登录失败，则提示用户名错误还是密码错误
⑤ 获取剩余的登录次数
'''
# 第五步：添加一个变量
trycount = 0
# 第一步：编写一个循环，只能循环3次
for i in range(3):
    # 第六步：手工更新登录次数
    trycount += 1
    # 第二步：接收账号与密码
    username = input('请输入您的账号：')
    password = input('请输入您的密码：')

    # 第三步：判断账号是否正确
    if username == 'admin':
        # 第四步：在账号正确的基础上，在判断密码是否正确
        if password == 'admin888':
            print('恭喜您，登录成功')
            break
        else:
            print('很抱歉，您的密码输入有误，请重新输入！')
            print(f'您还剩余{3-trycount}次登录机会！')

    else:
        print('很抱歉，您的账号输入有误，请重新输入！')
        print(f'您还剩余{3 - trycount}次登录机会！')