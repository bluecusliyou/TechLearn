'''
TCP服务器端开发七步走 => ① 创建套接字对象 ② 绑定IP和端口 ③ 设置监听 ④ 接收客户端连接请求 ⑤ 接收消息
⑥ 发送消息 ⑦ 关闭套接字对象
'''
import socket
import threading

class WebServer(object):
    # 3、定义一个__init__()魔术方法
    def __init__(self):
        self.tcp_server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        # 设置端口复用（让服务器端占用的端口在执行结束可以立即释放，不影响后续程序的使用）
        self.tcp_server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, True)
        self.tcp_server_socket.bind(('', 9000))  # 注意：参数必须是一个元组
        self.tcp_server_socket.listen(128)

    # 5、定义一个handle_request()方法，用于接收消息与发送消息
    def handle_request(self, new_socket, ip_port):
        # 接收某个客户端发送过来的消息
        content = new_socket.recv(1024).decode('gbk')  # 1024代表什么意思 => 1024字节 => 1kb = 实际工作中，一条数据大小在1~1.5k之间
        print(f'{ip_port}客户端发送消息：{content}')
        # 返回数据给客户端
        new_socket.send('信息已收到,over!'.encode('gbk'))
        # 关闭套接字对象
        # new_socket.close()

    # 4、定义一个start()方法
    def start(self):
        while True:
            new_socket, ip_port = self.tcp_server_socket.accept()
            # 来一个客户，我们就为其创建一个线程，调用自身的handle_request()方法，用于接收消息与发送消息
            sub_thread = threading.Thread(target=self.handle_request, args = (new_socket, ip_port))
            # 启动线程
            sub_thread.start()

# 定义一个程序的执行入口
if __name__ == '__main__':
    # 1、实例化对象
    ws = WebServer()
    # 2、调用对象中的相关方法 => 启动TCP服务
    ws.start()