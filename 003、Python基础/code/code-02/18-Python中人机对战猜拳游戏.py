'''
游戏名称：猜拳游戏，石头剪刀布
游戏角色：① 玩家 ② 电脑 （人机对战）
游戏要求：玩家手工出拳，可以从剪刀、石头、布中选择一个进行出拳，电脑随机出拳
游戏规则：两两比较，石头  管 剪刀，布   管 石头，剪刀 管 布
游戏情况：① 玩家获胜② 两者平局③ 电脑获胜
关键点：只需要判断什么情况下，玩家可以获胜即可
'''
# 导入random随机模块
import random
# 1、定义一个变量player代表玩家角色，用于存储玩家的出拳信息
player = int(input('请输入您的出拳信息（0-石头，1-剪刀，2-布）：'))
# 2、定义一个变量computer代表电脑角色，用于存储电脑的随机（遗留问题：如何随机出拳）出拳信息
computer = random.randint(0, 2)

# 3、根据游戏规则，判断谁输谁赢！
# player == 0 必须要求 computer == 1
# player == 1 必须要求 computer == 2
# player == 2 必须要求 computer == 0
if (player == 0 and computer == 1) or (player == 1 and computer == 2) or (player == 2 and computer == 0):
    print('玩家获胜')
elif player == computer:
    print('平局')
else:
    print('电脑获胜')