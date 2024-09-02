'''
FastAPI使用四步走：① 导入模块 ② 创建FastAPI对象 ③ 使用装饰器收发信息 ④ 启动服务器开始监听
'''
# ① 导入模块
from fastapi import FastAPI
from fastapi import Response
import logging

import uvicorn

# ② 创建FastAPI对象
app = FastAPI()

# 配置logging日志的输出信息（输出格式、输出到哪个文件）
f = open('fastapi.log', 'a', encoding='utf-8')
logging.basicConfig(level=logging.DEBUG,
                    format='%(asctime)s - %(filename)s[line:%(lineno)d] - %(levelname)s: %(message)s',
                    stream=f)

# ③ 使用装饰器收发信息
@app.get('/')  # 首页
def main():
    with open('source/html/index.html', 'rb') as f:
        data = f.read()
    logging.info('访问了/首页')
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='text/html')

# 添加一个小图标接收请求与处理返回
@app.get('/favicon.ico')
def get_ico():
    with open(f'source/html/favicon.ico', 'rb') as f:
        data = f.read()
    logging.info('访问了favicon.ico小图标')
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='image/x-icon')

# 使用装饰器处理图片请求
@app.get('/images/{path}')  # /images/0.jpg
def get_pic(path: str):  # 在Python函数中，可以这么写def 函数名称(参数: 建议的参数类型，可以不遵守)
    with open(f'source/images/{path}', 'rb') as f:
        data = f.read()
    logging.info(f'访问了/images/{path}图片')
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')

# 会用装饰器处理html请求
@app.get('/{path}')
def get_html(path: str):
    with open(f'source/html/{path}', 'rb') as f:
        data = f.read()
    logging.info(f'访问了/{path}文件')
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='text/html')

# ④ 启动服务器开始监听
uvicorn.run(app, host='127.0.0.1', port=8000)