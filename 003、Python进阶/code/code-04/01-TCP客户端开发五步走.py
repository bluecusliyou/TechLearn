'''
TCP客户端开发五步走：① 创建客户端套接字对象 ② 建立连接 ③ 发送数据 ④ 接收数据 ⑤ 关闭套接字对象
第一个知识点：
socket.socket(socket.AF_INET, socket.SOCK_STREAM)
socket.AF_INET ：IP v4
socket.SOCK_STREAM ：TCP协议
第二个知识点：
tcp_client_socket.connect() => 连接服务器端（IP地址和端口号） => 参数是一个元组(IP地址，端口号)
第三个知识点：发送send()、接收数据recv()，注意事项：无论信息的发送还是接收都必须使用二进制流数据
encode() : 把字符串转二进制流数据
decode() : 把二进制流数据转换为字符串
'''
import socket

# 第一步：创建客户端套接字对象
tcp_client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
# 第二步：创建连接
tcp_client_socket.connect(('127.0.0.1', 8000))
# 第三步：发送数据到服务器端
tcp_client_socket.send('I Love Python!'.encode('gbk'))
# 第四步：接收服务器端返回的应答数据
content = tcp_client_socket.recv(1024).decode('gbk')
print(f'服务器端返回的内容：{content}')
# 第五步：关闭套接字对象
tcp_client_socket.close()
