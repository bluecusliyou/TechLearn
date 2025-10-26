using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace FileSender
{
    internal class Program
    {
        private const int BufferSize = 64 * 1024; // 64KB 分片大小
        private const int Port = 4000;
        private const string ServerIP = "127.0.0.1";

        static void Main()
        {
            string filePath = "test_file.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine("文件不存在");
                return;
            }
            Console.WriteLine($"使用测试文件: {filePath}");

            FileInfo fileInfo = new FileInfo(filePath);
            string fileName = fileInfo.Name;
            long fileSize = fileInfo.Length;

            // 计算分片数量
            int totalChunks = (int)Math.Ceiling((double)fileSize / BufferSize);

            try
            {
                using (TcpClient client = new TcpClient(ServerIP, Port))
                using (NetworkStream stream = client.GetStream())
                {
                    // 传输速度优化
                    client.NoDelay = true; // 禁用Nagle算法
                    client.SendBufferSize = 64 * 1024; // 64KB缓冲区

                    // 检查是否需要断点续传
                    string tempFilePath = Path.Combine(Path.GetTempPath(), $"{fileName}.temp");
                    long startPosition = 0;

                    if (File.Exists(tempFilePath))
                    {
                        // 读取上次传输的位置
                        using (BinaryReader reader = new BinaryReader(File.OpenRead(tempFilePath)))
                        {
                            startPosition = reader.ReadInt64();
                        }

                        if (startPosition < fileSize)
                        {
                            Console.WriteLine($"检测到未完成的传输，将从 {startPosition} 字节处继续传输");
                            // 发送断点续传请求
                            string resumeHeader = $"RESUME|{fileName}|{fileSize}|{startPosition}";
                            byte[] resumeHeaderBytes = Encoding.UTF8.GetBytes(resumeHeader);
                            stream.Write(resumeHeaderBytes, 0, resumeHeaderBytes.Length);

                            // 等待服务器确认
                            byte[] confirmBuffer = new byte[10];
                            stream.Read(confirmBuffer, 0, confirmBuffer.Length);
                            string confirm = Encoding.UTF8.GetString(confirmBuffer).Trim();
                            if (confirm != "OK")
                            {
                                Console.WriteLine("服务器不支持断点续传，将重新开始传输");
                                startPosition = 0;
                            }
                        }
                        else
                        {
                            Console.WriteLine("文件已传输完成，无需再次传输");
                            return;
                        }
                    }

                    // 如果不是断点续传，则发送完整的文件头
                    if (startPosition == 0)
                    {
                        string header = $"FILE|{fileName}|{fileSize}";
                        byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                        stream.Write(headerBytes, 0, headerBytes.Length);
                    }

                    Console.WriteLine($"开始发送: {fileName} ({fileSize}字节)");

                    // 分片发送文件内容
                    using (FileStream fs = File.OpenRead(filePath))
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        // 如果是断点续传，跳转到上次传输的位置
                        if (startPosition > 0)
                        {
                            fs.Seek(startPosition, SeekOrigin.Begin);
                        }

                        byte[] buffer = new byte[BufferSize];
                        int bytesRead;
                        long totalSent = startPosition;

                        // 创建临时文件记录传输进度
                        using (BinaryWriter progressWriter = new BinaryWriter(File.Open(tempFilePath, FileMode.Create)))
                        {
                            while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                // 增加分片校验机制
                                byte[] checksum = sha256.ComputeHash(buffer, 0, bytesRead);
                                stream.Write(BitConverter.GetBytes(checksum.Length), 0, sizeof(int));
                                stream.Write(checksum, 0, checksum.Length);
                                stream.Write(BitConverter.GetBytes(bytesRead), 0, sizeof(int));
                                stream.Write(buffer, 0, bytesRead);

                                totalSent += bytesRead;

                                // 保存传输进度
                                progressWriter.Seek(0, SeekOrigin.Begin);
                                progressWriter.Write(totalSent);
                                progressWriter.Flush();

                                // 显示进度 
                                Console.Write($"\r进度: {totalSent * 100 / fileSize}%");
                            }
                            stream.Flush();
                        }

                        // 传输完成后删除临时文件
                        if (totalSent == fileSize && File.Exists(tempFilePath))
                        {
                            File.Delete(tempFilePath);
                        }
                    }
                    Console.WriteLine("\n文件发送完成");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"传输错误: {ex.Message}");
            }
        }
    }
}
