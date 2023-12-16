'''
break和continue是循环中满足一定条件退出循环的两种不同方式
记住：
break：满足一定条件，则终止整个循环结构
continue：满足一定条件，则中止本次循环，继而进入下一次循环
'''
# 1、定义一个字符串
str1 = 'mynameisly'
# 2、需求：遇到字符e则终止整个循环结构
for i in str1:
    # 添加一个判断条件，判断i是否等于字符'e'
    if i == 'e':
        print('遇到字符e则终止整个循环结构')
        break
    print(i)