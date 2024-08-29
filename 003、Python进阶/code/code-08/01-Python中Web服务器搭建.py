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
@app.get('/images/0.jpg')
def func0():
    with open('source/images/0.jpg', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')

@app.get('/images/1.jpg')
def func0():
    with open('source/images/1.jpg', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')

@app.get('/images/2.jpg')
def func0():
    with open('source/images/2.jpg', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')

@app.get('/images/3.jpg')
def func0():
    with open('source/images/3.jpg', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')

@app.get('/images/4.jpg')
def func0():
    with open('source/images/4.jpg', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')

@app.get('/images/5.jpg')
def func0():
    with open('source/images/5.jpg', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')


@app.get('/images/6.jpg')
def func0():
    with open('source/images/6.jpg', 'rb') as f:
        data = f.read()
    # 返回数据给客户端浏览器
    return Response(content=data, media_type='jpg')


# ④ 启动服务器开始监听
uvicorn.run(app, host='127.0.0.1', port=8000)