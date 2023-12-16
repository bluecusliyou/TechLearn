'''
find()：查找关键词在字符串中出现的位置
上传文件：avatar.png
第一个部分：avatar => 文件名称
第二个部分：.png => 文件后缀名
'''
file = input("请上传您的文件：")
# 第一步：查找点号所在的位置
index = file.find('.')
# 第二步：通过点号的索引获取文件名称
filename = file[:index]  # file[0:6:1]
# 第三步：通过点号的索引获取文件的后缀名 => .png这部分
postfix = file[index:]   # file[6::1]

print(f'文件名称：{filename}')
print(f'文件后缀：{postfix}')