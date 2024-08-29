'''
^ ：托字节，^代表匹配以某个字符开头
$ ：dollar美元符号，$代表匹配以某个字符结尾
注意：如果^托字节出现在[]字符簇中，则代表取反。如果单独出现，代表匹配以某个字符开头
案例：使用正则表达式匹配国内手机号码
手机号码 => 11位 => \d{11}，不能这么写，因为手机号码要满足一定的规则
第1位必须是1
第2位必须是13、14、15、16、17、18、19，第2位必须是3或4或5或6或7或8或9
第3位开始~第11位，什么样的数字都有
手机验证：
1[3-9]\d{9}
'''
import re

# 选择匹配符
print('***************选择匹配符****************')
result = re.finditer(r'hello(java|python)', 'hellojava, hellopython')
if result:
    for i in result:
        print(i.group())
else:
    print('未匹配到任何数据')

# 子表达式
print('***************子表达式****************')
result = re.search(r'\d(\d)(\d)', 'abcdef123ghijklmn')
print(result.group())  #123
print(result.group(1)) #2
print(result.group(2)) #3

# 反向引用（后向引用）
print('***************反向引用****************')
# 四个数字
result =re.search(r'\d\d\d\d', 'abcdef1234ghijklmn7894')
print(result.group()) # 1234

# 四个数字叠字 1111  2222  3333  4444
result =re.search(r'(\d)\1\1\1', 'abcdef1234ghijklmn33aaaa4444sese')
print(result.group()) #4444

# 分组别名
print('***************分组别名****************')
result = re.search(r'<(?P<mark>\w+)></(?P=mark)>', '<book></book>')
print(result.group()) #'<book></book>'