'''
HTTP之Web服务器开发 => TCP七步走
'''
import socket

if __name__ == '__main__':
    # 第一步：创建套接字对象
    tcp_server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    tcp_server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, True)
    # 第二步：绑定IP与端口
    tcp_server_socket.bind(('', 8080))
    # 第三步：设置监听
    tcp_server_socket.listen(128)
    # 第四步：接收客户端连接请求
    while True:
        new_socket, ip_port = tcp_server_socket.accept()
        # 第五步：接收客户端发送过来的数据
        client_request_data = new_socket.recv(4096)
        if client_request_data:
            request_data = client_request_data.decode('utf-8')
            # 针对字符串进行切割，获取请求路径
            request_path = request_data.split(' ', maxsplit=2)[1]
            # 如果用户向直接访问首页，不输入资源路径
            if request_path == '/':
                request_path = '/index.html'
            # 判断文件是否存在，存在返回200，不存在就返回404
            try:
                with open('shoping'+request_path, 'rb') as f:
                    file_data = f.read()
            except:
                response_line = 'HTTP/1.1 404 Not Found\r\n'
                response_header = 'Server:PWB2.0\r\nContent-type:text/html; charset=utf-8'
                response_body = '很抱歉，您要访问的商城页面不存在!'
                response_data = (response_line + response_header + '\r\n' + response_body).encode('utf-8')
                new_socket.send(response_data)
            else:
                response_line = 'HTTP/1.1 200 OK\r\n'
                response_header = 'Server:PWB2.0\r\n'
                response_body = file_data
                response_data = (response_line + response_header + '\r\n').encode('utf-8') + response_body
                new_socket.send(response_data)
            finally:
                new_socket.close()