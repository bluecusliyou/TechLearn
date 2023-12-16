'''
isdigit() ：判断一个字符串是否全部由纯数字组成，全部为纯数字True，反之就返回为False
'''
password = input('请输入您的6位银行卡密码：')

# 输入的密码是否合理
if password.isdigit():
    print(f'您的银行卡密码为{password}')
else:
    print('您输入的银行卡有误，请重新输入！')