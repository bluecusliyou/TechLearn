'''
TCP服务器端开发七步走：① 创建服务器端套接字对象 ② 绑定IP和端口 ③ 开始监听 ④ 接收客户端连接请求 ⑤ 接收数据 ⑥ 发送数据 ⑦ 关闭套接字对象
通过面向对象开发 => 分析有哪些对象 => 创建类 => 属性和方法
服务器端对象 => 服务器端类
'''
import socket

# 第一步：创建WebServer类
class WebServer(object):
    # 第四步：定义魔术方法__init__()
    def __init__(self):
        # ① 创建服务器端套接字对象
        self.tcp_server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        # ② 绑定IP和端口号
        self.tcp_server_socket.bind(('', 8000))  # 192.168.89.68
        # ③ 设置监听
        self.tcp_server_socket.listen(128)

    # 第五步：定义一个start()方法 => 接收客户端连接
    def start(self):
        # ④ 接收客户端连接（允许多个客户端同时连接）
        while True:
            new_socket, ip_port = self.tcp_server_socket.accept()
            # ⑤ 接收客户端发送过来的信息
            content = new_socket.recv(1024).decode('gbk')
            print(f'{ip_port}客户端发送过来的数据：{content}')
            # ⑥ 返回数据给客户端（响应数据）
            data = input('请输入您要回复的内容：')
            new_socket.send(data.encode('gbk'))
            new_socket.close()


# 第二步：实例化对象，调用__init__()初始化方法
ws = WebServer()
# 第三步：启动服务，接收客户端连接
ws.start()

# 遗留问题：整个程序其实目前位置只能接收一个客户端，接收其他客户端，必须等待上一个连接结束，才可以继续连接发送接收数据，因为我们目前编写的程序都是单进程！一个Python只能处理一个连接请求！
# 如何期望服务器端，可以同时处理多个客户端请求，怎么办呢？答：使用多任务编程 => 明天