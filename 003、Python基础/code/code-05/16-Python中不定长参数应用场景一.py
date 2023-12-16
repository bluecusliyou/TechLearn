'''
在实际Python开发工作中，*args与**kwargs还可以结合在一起使用！
注意事项：*args必须放在左边，**kwargs必须放在右边
'''
def func(*args, **kwargs):
    print(args)
    print(kwargs)

# 当我们调用func函数时为其传递参数，*args用于接收位置参数，**kwargs用于接收关键词参数
func(1, 2, 3, a=4, b=5)