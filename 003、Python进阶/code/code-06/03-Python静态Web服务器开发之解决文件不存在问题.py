'''
基本Web服务器：
编写一个TCP服务端程序（七步走）
获取浏览器发送的HTTP请求报文数据
读取固定页面数据，把页面数据组装成HTTP响应报文数据发送给浏览器。
HTTP响应报文数据发送完成以后，关闭服务于客户端的套接字。
要想返回指定页面：
获取用户请求资源的路径
根据请求资源的路径，读取指定文件的数据
组装指定文件数据的响应报文，发送给浏览器
'''
import socket

if __name__ == '__main__':
    # 第一步：创建套接字对象
    tcp_server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    # 第二步：绑定IP和端口，设置端口复用
    tcp_server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, True)
    tcp_server_socket.bind(('', 9000))
    # 第三步：设置监听
    tcp_server_socket.listen(128)
    # 第四步：接收客户端连接
    while True:
        new_socket, ip_port = tcp_server_socket.accept()
        # 第五步：接收客户端传递过来的数据
        client_request_data = new_socket.recv(4096)
        # 判断（易错点）=> 新版的很多浏览器都带了一个自动刷新功能（每隔一段时间不操作，浏览器会自动刷新1次）=> 发送了一个空数据包过来
        if client_request_data:
            # 如果浏览器发送过来了数据，则我们对HTTP请求数据进行解析
            client_request_data = client_request_data.decode('utf-8')
            # print(client_request_data)
            # 获取用户请求的资源页面
            request_data = client_request_data.split(' ', maxsplit=2)
            request_path = request_data[1]  # /index.html
            # 解决域名直接访问首页问题
            if request_path == '/':  # 代表用户期望访问首页
                request_path = '/index.html'
            # 第六步：返回数据给浏览器客户端
            try:
                with open('html' + request_path, 'rb') as f:  # html/index.html
                    file_data = f.read()
            except:
                # 如果以上文件不存在，则返回404，返回错误信息
                response_line = 'HTTP/1.1 404 Not Found\r\n'
                response_header = 'Server:PWB/1.1\r\nContent-Type:text/html; charset=utf-8\r\n'
                response_body = '很抱歉，您要访问的页面不存在！'
                response_data = (response_line + response_header + '\r\n' + response_body).encode('utf-8')
                new_socket.send(response_data)
            else:
                # 拼接HTTP响应报文 => 响应行、响应头、空行、响应体
                response_line = 'HTTP/1.1 200 OK\r\n'
                response_header = 'Server:PWB/1.1\r\n'
                # 空行\r\n
                response_body = file_data
                response_data = (response_line + response_header + '\r\n').encode('utf-8') + response_body
                new_socket.send(response_data)
            finally:
                # 第七步：关闭新产生的套接字对象
                new_socket.close()