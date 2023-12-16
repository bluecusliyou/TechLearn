# 需求：请封装一个函数，用于接收list1与dict1的值，然后对其进行求和操作，函数最终返回结果为1+2+3+4+5
# 在Python中，*args还可以专门用于接收列表类型或者元组类型的数据
#            **kwargs还可以专门用于接收字典类型的数据
def func(*args, **kwargs):
    sum = 0
    for i in args:
        sum += i
    for value in kwargs.values():
        sum += value
    print(sum)

list1 = [1, 2, 3]
dict1 = {'a':4, 'b':5}

func(*list1, **dict1)# 15
