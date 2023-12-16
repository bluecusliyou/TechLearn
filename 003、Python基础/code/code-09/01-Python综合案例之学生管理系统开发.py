# 5、定义一个大列表，将来用于保存所有同学的信息 []
students = []  # 将来数据结构[{}, {}, {}]

# 6、封装一个add_student()方法，用于实现向students中添加学员
def add_student():
    # 提示用户输入要添加的学员信息
    student = {}
    # 字典[键] = 值 => {name:xxx, age:23, mobile:10086}
    student['name'] = input('请输入要添加学员的姓名：')
    student['age'] = int(input('请输入要添加学员的年龄：'))
    student['mobile'] = input('请输入要添加学员的电话：')
    # 把这个字典追加到全局的students列表中
    students.append(student)  # [{}, {}, {}]
    print('恭喜您，学员信息已录入成功！')
    print(students)

# 7、封装一个del_student()方法，用于实现从students列表中删除同学信息
# ① 提示用户输入要删除同学的名字 ② 然后在students列表中，进行循环遍历，找是否有删除的同学，找到了就删除，找不到弹出提示没有这个同学信息
def del_student():
    name = input('请输入要删除同学的姓名：')
    for i in students:  # 从students列表中取出每一个字典，然后放入变量i中
        if i['name'] == name:  # 相等就代表找到了这个同学
            # 把这个字典从列表中整体删除
            students.remove(i)
            print('恭喜您，学员信息已成功删除！')
            print(students)
            break
    else:
        print('很抱歉，您要删除的同学信息暂不存在！')

# 8、封装一个edit_student()方法，用于实现编辑students中的同学信息
def edit_student():
    # 提示用户输入要修改学员的姓名
    name = input('请输入您要修改学员的姓名：')
    # 对整个列表students进行遍历
    for i in students:
        if i['name'] == name:
            i['name'] = input('请输入修改后的同学姓名：')
            i['age'] = int(input('请输入修改后的同学年龄：'))
            i['mobile'] = input('请输入修改后的同学电话：')
            print('恭喜您，学员信息已更新成功！')
            print(students)
            break
    else:
        print('很抱歉，您要修改的同学信息暂不存在！')

# 9、定义一个find_student()函数，用于查找同学的信息
def find_student():
    # 提示用户输入要查找的同学名称
    name = input('请输入您要查找的同学姓名：')
    for i in students:
        if i['name'] == name:
            print(i)
            break
    else:
        print('很抱歉，您要查找的同学信息暂不存在！')

# 10、定义一个show_students()函数，用于显示所有学员信息
def show_students():
    for i in students:
        print(i)

# 11、定义一个save_data_to_file()函数，用于保存数据到文件
def save_data_to_file():
    # ① 打开文件
    f = open('students.txt', 'w', encoding='utf-8')
    # ② 读写文件
    f.write(str(students))  # 只能把字符串写入到文件 => [{}, {}, {}] => '[{}, {}, {}]'
    # ③ 关闭文件
    f.close()
    print('恭喜您，信息已成功保存！')

# 2、封装一个menu()函数，专门用于实现打印学生管理系统的菜单
def menu():
    print('-' * 40)
    print('欢迎使用学生管理系统V1.0')
    print('【1】添加学员信息')
    print('【2】删除学员信息')
    print('【3】修改学员信息')
    print('【4】查询学员信息')
    print('【5】遍历所有学员信息')
    print('【6】保存数据到文件')
    print('【7】退出系统')
    print('-' * 40)


def load_data():
    # 打开文件
    f = open('students.txt', 'r', encoding='utf-8')
    # 读取数据
    content = f.read()  # str字符串类型
    # 判断文件内容是否为空
    if not content:
        return  # 终止此函数，不需要在继续加载了
    else:
        # 如果代码继续向下执行，代表content不为空，则进行类型转换
        global students  # 声明我们接下来要使用的students是全局变量
        students = eval(content)


# 12、加载students.txt中的数据到students列表中
load_data()

# 1、定义一个死循环结构，让代码一直执行下去，直到用户手工退出
while True:
    menu()
    # 3、提示用户输入要执行的功能编号
    user_num = int(input('请输入您要执行的功能编号：'))
    # 4、使用if多分支结构进行条件判断
    if user_num == 1:
        add_student()
    elif user_num == 2:
        del_student()
    elif user_num == 3:
        edit_student()
    elif user_num == 4:
        find_student()
    elif user_num == 5:
        show_students()
    elif user_num == 6:
        save_data_to_file()
    elif user_num == 7:
        print('退出系统成功，感谢您使用学生管理系统V1.0！')
        break
    else:
        print('很抱歉，您的输入有误，请重新输入！')
