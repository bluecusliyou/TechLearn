'''
TCP服务器端开发七步走：① 创建服务器端套接字对象 ② 绑定IP和端口 ③ 开始监听 ④ 接收客户端连接请求 ⑤ 接收数据 ⑥ 发送数据 ⑦ 关闭套接字对象
第一个知识点：创建服务器端套接字对象
socket.socket(socket.AF_INET => IP v4, socket.SOCK_STREAM => TCP协议)
第二个知识点：绑定IP和端口
bind(元组参数) => bind(('IP地址', 端口号 => 建议8000以后))
第三个知识点：设置监听 => 设置允许最大的监听数 => 128
listen(整数参数）代表最大允许连接的总数
第四个知识点：接收客户端连接请求（关键点、难点）
accept()方法：接收客户端连接，accept方法在接收数据的同时，如何识别到底是哪个客户端发起的连接呢？
'''
import socket

# 第一步：创建服务器端套接字对象
tcp_server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
# 第二步：绑定IP和端口
tcp_server_socket.bind(('', 8000))  # 如果是绑定本机，也可以不写IP地址，会自动绑定
# 第三步：设置监听
tcp_server_socket.listen(128)
# 第四步：接收客户端连接
new_socket, ip_port = tcp_server_socket.accept()
# 第五步：接收客户端发送过来的数据
content = new_socket.recv(1024).decode()  # decode不写编码，默认也是gbk
print(f'{ip_port}客户端发送过来的数据：{content}')
# 第六步：响应数据给客户端（应答机制）
new_socket.send('信息已收到，over！'.encode('gbk'))
# 第七步：关闭新套接字对象（不能收发消息了）与服务器端套接字对象（不能接收客户端连接了）
new_socket.close()
tcp_server_socket.close()