from lxml import etree  # 把字符串转换为HTML结构
import requests

# 伪造浏览器的头信息
headers = {
    'User-Agent':'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/101.0.0.0 Safari/537.36'
}
res = requests.get('http://www.splxx.cn/WarticleList.aspx?typeid=opDItqtHf7A=', headers=headers)

# 把数据转换为HTML结构 => 结合XPath读取
data = etree.HTML(res.text)
data = data.xpath('//div[@class="list_body"]//li/a/text()')

for row in data:
    print(row)