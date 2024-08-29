'''
基本语法：
生成器对象 = (推导式代码 => 列表推导式怎么写的，生成器里面的代码也可以同样书写)
举个栗子：创建一个生成器对象，同时保存0-9一共10个元素
注意：虽然生成器的语法和元组推导式感觉很像，但是要特别注意Python中并没有元组推导式，其返回的结果一个generator生成器对象
在生成器中有一个方法，叫做next()方法，其主要功能就是获取生成器中的下一个元素
还有一个特别注意点：生成器中存储的和列表推导式存储的结果有所不同
列表推导式存储的是具体的数据0-9
生成器中存储的并不是具体的数据，而是数据的生成规则，每次next()方法，系统会自动根据生成器的生成规则生成一个元素
这样做的好处就是可以节省大量的空间（真正做到随用随取）
'''
generator = (i for i in range(10))   # (生成元素的规则，第一次打印生成一个0，第二次打印生成一个1)
print(generator)  # generator object

# 如何获取生成器中的元素，我们可以基于next()方法调用生成器中的规则，打印元素
result = next(generator)
print(result)

result = next(generator)
print(result)

result = next(generator)
print(result)

# 还可以基于for循环遍历generator生成器对象，获取生成器中的所有数据
for i in generator:
    print(i)