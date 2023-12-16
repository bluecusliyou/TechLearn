# 1、提示用户输入三个数字
num1 = int(input('请输入第一个数：'))
num2 = int(input('请输入第二个数：'))
num3 = int(input('请输入第三个数：'))

# 2、求三个数中的最大值与最小值
list1 = [num1, num2, num3]

max_num = max(list1)
min_num = min(list1)

print(f'最大值：{max_num}，最小值：{min_num}')