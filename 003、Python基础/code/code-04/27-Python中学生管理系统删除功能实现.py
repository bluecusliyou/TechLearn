# 1、定义一个大列表，里面保存了所有同学的信息
students = [{'name': '岁鹏', 'age': 23, 'mobile': '10086'}, {'name': '小美', 'age': 19, 'mobile': '10010'}]

# 2、提示用户输入要删除的同学名称
name = input('请输入您要删除同学的名称：')  # 小明

# 3、对列表进行遍历
for i in students:
    if i['name'] == name:
        # 删除整个字典
        students.remove(i)
        # 弹出提示
        print('删除成功')
        print(students)
        break
else:
    print('很抱歉，您要删除的同学未找到！')