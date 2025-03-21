'''
问题：for循环也是循环，能不能实现固定循环多少次，比如循环10次
答：默认情况下，for循环只能用于遍历数据容器。但是如果一定想要达到这个效果，可以使用range()方法

range(5) 等价于 range(0, 5, 1)，从0开始，到5结束（不包含5），每次前进1步
range(1, 11, 2) 生成一个容器，从1开始，每次前进2步，1 3 5 7 9
'''
# 使用for循环 + range()生成从0到4
for i in range(5):  # range(0, 5, 1)
    print(i)