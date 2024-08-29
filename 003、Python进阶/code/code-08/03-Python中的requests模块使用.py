# 第一步：导入模块
import requests

# 第二步：发起请求
res = requests.get('https://www.baidu.com/')

# 第三步：获取爬取的内容
content = res.content.decode('utf-8')
print(content)

# 特别说明：以上代码不一定每一次都能爬取到数据，因为BAT这种大站都存在反爬机制，如果爬取过于频繁，会被禁止IP