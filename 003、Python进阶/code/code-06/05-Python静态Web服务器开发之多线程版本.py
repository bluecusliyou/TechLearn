import socket
import threading

def son(get_sock):
    # 接收数据  数据一定要接收
    ret = get_sock.recv(4096)

    # 完善：判断用户是否离开
    if len(ret) == 0:
        print('用户下线')
        get_sock.close()
        return

    # 解析请求报文，得到请求资源中的资源路径
    ret_road = ret.decode().split('\r\n')[0].split(' ')[1]
    # 判断当/时候返回主页面
    if ret_road == '/':
        ret_road = '/index.html'

    try:
        # 响应报文和发送

        # 读取网页资源  rb读取时候本身为二进制，所以在发送数据那块不用再进行编码转换
        file = open('./html' + ret_road, 'rb')
        body_data = file.read()
        file.close()

        # with open写法
        # with open('./html/index.html','rb')as file:
        #     body_data = file.read()
    except Exception as e:
        # 如果以上文件不存在，则返回404，返回错误信息
        response_line = 'HTTP/1.1 404 Not Found\r\n'
        response_header = 'Server:PWB/1.1\r\nContent-Type:text/html; charset=utf-8\r\n'
        response_body = '很抱歉，您要访问的页面不存在！'
        response_data = (response_line + response_header + '\r\n' + response_body).encode('utf-8')
        get_sock.send(response_data)
    else:
        response_line = 'HTTP/1.1 200 OK\r\n'
        response_header = 'Server:PWB2.0\r\n'
        response_body = body_data
        response_data = (response_line + response_header + '\r\n').encode('utf-8') + response_body
        get_sock.send(response_data)
    finally:
        # 关闭
        get_sock.close()

def main():
    web_sock = socket.socket()
    web_sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR,1)
    web_sock.bind(('',9999))
    web_sock.listen(128)
    while True:
        #接收一个新的连接请求
        get_sock, get_adress = web_sock.accept()
        # print('用户%s 进入' % str(get_adress))
        thd = threading.Thread(target=son, args=(get_sock,))
        #设置守护主线程
        thd.setDaemon(True)
        thd.start()

if __name__ == '__main__':
    main()