'''
观察偶数特点：
① 能被2整除
② 相邻的偶数与偶数之间，差2位，2 4 6 8 10 12 14 ...
'''
# 第一种解法
# sum = 0
# for i in range(1, 101):
#     if i % 2 == 0:
#         sum += i
# print(sum)

# 第二种解法
sum = 0
for i in range(2, 101, 2):  # 2 4 6 8
    sum += i
print(sum)