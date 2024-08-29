def generator(n):
    for i in range(n):
        yield i

result = generator(5)
print(result)

# for i in result:
#     print(i)

# print(next(result))
# print(next(result))
# print(next(result))
# print(next(result))
# print(next(result))
#
# print(next(result))  # 报异常：StopIteration

while True:  # 不推荐
    try:
        print(next(result))
    except StopIteration:
        break