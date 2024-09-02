import re
import requests

country_list = []
gdp_list = []

def get_gdp():
    res = requests.get('http://127.0.0.1:8000/gdp.html')
    data = res.content.decode('utf-8')
    data = data.split('\n')
    for row in data:
        # print(row)  # <td>&nbsp;&nbsp;<a href=""><font>美国</font></a></td>
        result = re.match('.*<a href=""><font>(.*)</font></a>.*', row)
        if result:
            country_list.append(result.group(1))
        # <td class="rank_prev"><font>￥29662.5546亿元</font></td>
        result = re.match('.*￥(.*)亿元.*', row)
        if result:
            gdp_list.append(float(result.group(1)))

    # print(country_list)
    # print(gdp_list)
    # 把以上得到的结果转换为[(), (), ()]
    return list(zip(country_list, gdp_list))

if __name__ == '__main__':
    data = get_gdp()
    print(data)



