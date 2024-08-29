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
tcp_server_socket.bind(('127.0.0.1', 8000))
# 第三步：设置监听
tcp_server_socket.listen(128)
# 第四步：接收客户端连接
new_socket, ip_port = tcp_server_socket.accept()
print(tcp_server_socket)

print(new_socket)  # 新问题：新套接字对象到底用来做什么？
print(ip_port)  # 客户端IP + 端口

# (<socket.socket fd=432, family=AddressFamily.AF_INET, type=SocketKind.SOCK_STREAM, proto=0, laddr=('127.0.0.1', 8000), raddr=('127.0.0.1', 60925)>, ('127.0.0.1', 60925))
# ① 本质是一个元组，元组内部理论上可以存放多个元素，元素与元素之间通过逗号隔开
# ② 这个元组中第一个参数是一个socket套接字对象（思考一下，是否与tcp_server_socket相同）
# ③ 这个元组中第二个参数也是一个元组，元组中有两个值（IP地址 + 端口号），通过查看内容可知，这代表客户端IP + 端口