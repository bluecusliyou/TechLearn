'''
FastAPI使用四步走：① 导入模块 ② 创建FastAPI对象 ③ 使用装饰器收发信息 ④ 启动服务器开始监听
'''
# ① 导入模块
from fastapi import FastAPI
from fastapi import Response

import uvicorn

# ② 创建FastAPI对象
app = FastAPI()

# ③ 使用装饰器收发信息
@app.get('/')  # 首页
def main():
    with open('source/html/index.html', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='text/html')

# 使用装饰器处理图片请求
@app.get('/images/{path}')  # /images/0.jpg
def get_pic(path: str):  # 在Python函数中，可以这么写def 函数名称(参数: 建议的参数类型，可以不遵守)
    with open(f'source/images/{path}', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')

# 会用装饰器处理html请求
@app.get('/{path}')
def get_html(path: str):
    with open(f'source/html/{path}', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='text/html')

# 添加一个小图标接收请求与处理返回
@app.get('/favicon.ico')
def get_ico():
    with open(f'source/html/favicon.ico', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='image/x-icon')

# ④ 启动服务器开始监听
uvicorn.run(app, host='127.0.0.1', port=8000)