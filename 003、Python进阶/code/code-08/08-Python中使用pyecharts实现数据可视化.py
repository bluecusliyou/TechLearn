import requests
import re
# 导入饼图模块
from pyecharts.charts import Pie
# 导入配置选项模块
import pyecharts.options as opts

# 存储爬取到的国家的名字
country_list = []
# 春初爬取到的国家gdp的数据
gdp_list = []


def get_gdp_data():
    global country_list
    global gdp_list

    # 获取gdp的html数据
    data = requests.get("http://localhost:8000/gdp.html")
    # 对获取数据进行解码
    data = data.content.decode("utf8")
    # 对gdp的html数据进行按行分割
    data_list = data.split("\n")

    for i in data_list:
        # 对html进行解析获取<国家名字>
        country_result = re.match('.*<a href=""><font>(.*)</font></a>', i)
        # 匹配成功就存放到列表中
        if country_result is not None:
            country_list.append(country_result.group(1))
        # 对html进行解析获取<gdp数据>
        gdp_result = re.match(".*￥(.*)亿元", i)
        # 匹配成功就存储到列表中
        if gdp_result is not None:
            gdp_list.append(gdp_result.group(1))


# 创建一个饼状图显示GDP前十的国家
def data_view_pie():
    # 获取前十的过的GDP数据, 同时让数据符合[(),()...]的形式
    data = list(zip(country_list[:10], gdp_list[:10]))
    # 创建饼图
    pie = Pie(init_opts=opts.InitOpts(width="1400px", height="800px"))
    # 给饼图添加数据
    pie.add(
        "GDP",
        data,
        label_opts=opts.LabelOpts(formatter='{b}:{d}%')
    )
    # 给饼图设置标题
    pie.set_global_opts(title_opts=opts.TitleOpts(title="2020年世界GDP排名", subtitle="美元"))
    # 保存结果
    pie.render("pie.html")


if __name__ == '__main__':
    # 获取GDP数据
    get_gdp_data()
    # 生成可视化饼图
    data_view_pie()