try:
	print(1/0)
except (NameError, ZeroDivisionError):
	print('ZeroDivision错误...')