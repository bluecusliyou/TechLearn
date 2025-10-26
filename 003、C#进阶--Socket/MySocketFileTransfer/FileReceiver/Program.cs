using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace FileReceiver
{
    internal class Program
    {
        private const int BufferSize = 64 * 1024; // 64KB 分片大小
        private const int Port = 4000;
        private static readonly string SavePath = @"D:\ReceivedFiles\";

        static void Main()
        {
            Directory.CreateDirectory(SavePath);

            // 创建监听Socket
            TcpListener listener = new TcpListener(IPAddress.Any, Port);
            listener.Start();
            Console.WriteLine($"文件接收服务已启动，监听端口: {Port}");

            while (true)
            {
                // 接受客户端连接 
                using (TcpClient client = listener.AcceptTcpClient())
                using (NetworkStream stream = client.GetStream())
                {
                    Console.WriteLine($"客户端已连接: {client.Client.RemoteEndPoint}");

                    // 传输速度优化
                    client.NoDelay = true; // 禁用Nagle算法
                    client.ReceiveBufferSize = 64 * 1024; // 64KB缓冲区

                    // 接收文件头信息（文件名+文件大小）
                    byte[] headerBuffer = new byte[512];
                    int headerSize = stream.Read(headerBuffer, 0, headerBuffer.Length);
                    string header = Encoding.UTF8.GetString(headerBuffer, 0, headerSize);

                    // 解析文件元数据
                    string[] headerParts = header.Split('|');
                    if (headerParts.Length < 3)
                    {
                        Console.WriteLine("无效文件头格式");
                        continue;
                    }

                    string fileName = headerParts[1];
                    long fileSize = long.Parse(headerParts[2]);
                    string filePath = Path.Combine(SavePath, fileName);

                    // 处理断点续传请求
                    bool isResume = false;
                    long resumePosition = 0;

                    if (headerParts[0] == "RESUME")
                    {
                        isResume = true;
                        resumePosition = long.Parse(headerParts[3]);
                        Console.WriteLine($"收到断点续传请求: {fileName}，从 {resumePosition} 字节处继续接收");

                        // 检查文件是否存在且大小正确
                        if (File.Exists(filePath))
                        {
                            FileInfo fileInfo = new FileInfo(filePath);
                            if (fileInfo.Length == resumePosition)
                            {
                                // 发送确认消息
                                byte[] confirmBytes = Encoding.UTF8.GetBytes("OK");
                                stream.Write(confirmBytes, 0, confirmBytes.Length);
                                Console.WriteLine($"开始接收: {fileName} ({fileSize}字节)，继续从 {resumePosition} 字节处接收");
                            }
                            else
                            {
                                // 文件大小不匹配，重新开始传输
                                byte[] rejectBytes = Encoding.UTF8.GetBytes("REJECT");
                                stream.Write(rejectBytes, 0, rejectBytes.Length);
                                Console.WriteLine("文件大小不匹配，将重新开始传输");
                                isResume = false;
                            }
                        }
                        else
                        {
                            // 文件不存在，重新开始传输
                            byte[] rejectBytes = Encoding.UTF8.GetBytes("REJECT");
                            stream.Write(rejectBytes, 0, rejectBytes.Length);
                            Console.WriteLine("文件不存在，将重新开始传输");
                            isResume = false;
                        }
                    }
                    else if (headerParts[0] == "FILE")
                    {
                        Console.WriteLine($"开始接收: {fileName} ({fileSize}字节)");
                    }
                    else
                    {
                        Console.WriteLine("无效的文件头类型");
                        continue;
                    }

                    // 分片接收文件内容
                    FileMode fileMode = isResume ? FileMode.Append : FileMode.Create;
                    using (FileStream fs = new FileStream(filePath, fileMode))
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] buffer = new byte[BufferSize];
                        long totalReceived = isResume ? resumePosition : 0;

                        // 如果是断点续传，记录当前文件大小作为起始接收位置
                        if (isResume)
                        {
                            fs.Seek(0, SeekOrigin.End);
                        }

                        while (totalReceived < fileSize)
                        {
                            // 读取校验和长度
                            byte[] checksumLengthBytes = new byte[sizeof(int)];
                            int checksumLengthRead = stream.Read(checksumLengthBytes, 0, sizeof(int));
                            if (checksumLengthRead != sizeof(int))
                            {
                                Console.WriteLine("接收校验和长度失败");
                                break;
                            }
                            int checksumLength = BitConverter.ToInt32(checksumLengthBytes, 0);

                            // 读取校验和
                            byte[] receivedChecksum = new byte[checksumLength];
                            int checksumRead = stream.Read(receivedChecksum, 0, checksumLength);
                            if (checksumRead != checksumLength)
                            {
                                Console.WriteLine("接收校验和失败");
                                break;
                            }

                            // 读取数据长度
                            byte[] dataLengthBytes = new byte[sizeof(int)];
                            int dataLengthRead = stream.Read(dataLengthBytes, 0, sizeof(int));
                            if (dataLengthRead != sizeof(int))
                            {
                                Console.WriteLine("接收数据长度失败");
                                break;
                            }
                            int dataLength = BitConverter.ToInt32(dataLengthBytes, 0);

                            // 读取实际数据
                            int bytesRead = stream.Read(buffer, 0, dataLength);
                            if (bytesRead != dataLength)
                            {
                                Console.WriteLine("接收数据失败");
                                break;
                            }

                            // 验证校验和
                            byte[] computedChecksum = sha256.ComputeHash(buffer, 0, bytesRead);
                            bool checksumMatch = receivedChecksum.SequenceEqual(computedChecksum);
                            if (!checksumMatch)
                            {
                                Console.WriteLine("校验和不匹配，传输错误");
                                break;
                            }

                            // 写入文件
                            fs.Write(buffer, 0, bytesRead);
                            totalReceived += bytesRead;

                            // 显示进度 
                            Console.Write($"\r进度: {totalReceived * 100 / fileSize}%");
                        }
                        fs.Flush();
                    }
                    Console.WriteLine($"\n文件接收完成: {filePath}");
                }
            }
        }
    }
}
