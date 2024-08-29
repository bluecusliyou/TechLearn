'''
实现步骤:
编写一个TCP服务端程序（七步走）
获取浏览器发送的HTTP请求报文数据
读取固定页面数据，把页面数据组装成HTTP响应报文数据发送给浏览器。
HTTP响应报文数据发送完成以后，关闭服务于客户端的套接字。
'''
import socket

if __name__ == '__main__':
    # 第一步：创建套接字对象
    tcp_server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    # 第二步：绑定IP和端口
    tcp_server_socket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, True)
    tcp_server_socket.bind(('', 8000))
    # 第三步：设置监听
    tcp_server_socket.listen(128)
    # 第四步：接收客户端连接
    while True:
        new_socket, ip_port = tcp_server_socket.accept()
        # 第五步：接收接收客户端发送过来的数据
        content = new_socket.recv(4096).decode('utf-8')
        print(content)
        # 第六步：返回数据给浏览器客户端
        with open('html/index.html', 'rb') as f:
            file_data = f.read()
        # 关键点：我们需要把以上数据拼接为HTTP响应报文（响应行、响应头、空行、响应体）
        response_line = 'HTTP/1.1 200 OK\r\n'
        response_header = 'Server:PWB/1.1\r\nContent-Type:text/html; charset=utf-8\r\n'
        # 空行 => \r\n
        response_body = file_data
        # 组装HTTP响应数据
        response_data = (response_line + response_header + '\r\n').encode('utf-8') + response_body
        new_socket.send(response_data)
        # 关闭套接字对象
        new_socket.close()



