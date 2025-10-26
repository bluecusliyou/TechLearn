using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MyIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 文件和目录操作
            Console.WriteLine("File*********************************************************************");
            #region File
            {
                Console.WriteLine("创建新文件,文件默认是打开的，需要手工关闭，否则写入会报占用异常");
                FileStream fs = File.Create("example.txt");
                fs.Close();

                Console.WriteLine("写入文本到文件中");
                File.WriteAllText("example.txt", "Hello, World!");

                Console.WriteLine("读取文件内容");
                Console.WriteLine(File.ReadAllText("example.txt"));

                Console.WriteLine("追加文件内容");
                File.AppendAllText("example.txt", "This is append content.");
                Console.WriteLine(File.ReadAllText("example.txt"));

                Console.WriteLine("检查文件是否存在");
                Console.WriteLine("File exists: " + File.Exists("example.txt"));

                Console.WriteLine("获取文件的最后写入时间");
                Console.WriteLine("Last write time: " + File.GetLastWriteTime("example.txt"));

                Console.WriteLine("移动文件");
                File.Move("example.txt", "newexample.txt");

                Console.WriteLine("复制文件");
                File.Copy("newexample.txt", "example.txt");

                Console.WriteLine("删除文件");
                File.Delete("example.txt");
                File.Delete("newexample.txt");
            }
            #endregion

            Console.WriteLine("Path*********************************************************************");
            #region Path
            {
                Console.WriteLine("输入相对路径，返回完整路径");
                Console.WriteLine(Path.GetFullPath("example.txt"));

                Console.WriteLine("生成临时文件，返回完成路径");
                Console.WriteLine(Path.GetTempFileName());//C:\Users\Administrator\AppData\Local\Temp\tmpBBC9.tmp

                Console.WriteLine("返回随机的文件名");
                Console.WriteLine(Path.GetRandomFileName());//iknagpqs.wrx

                Console.WriteLine("组合路径");
                string combinedPath = Path.Combine("C:\\", "Documents");
                Console.WriteLine(combinedPath); //C:\Documents

                Console.WriteLine("返回指定路径的目录信息");
                Console.WriteLine(Path.GetDirectoryName(Path.GetFullPath("example.txt")));

                Console.WriteLine("获取文件扩展名");
                Console.WriteLine(Path.GetExtension("example.txt"));//.txt

                Console.WriteLine("获取文件名");
                Console.WriteLine(Path.GetFileName("example.txt"));//example.txt

                Console.WriteLine("获取文件名（不包括扩展名）");
                Console.WriteLine(Path.GetFileNameWithoutExtension("example.txt"));//example

                Console.WriteLine("获取根目录");
                Console.WriteLine(Path.GetPathRoot(Path.GetFullPath("example.txt")));//E:\
            }
            #endregion

            Console.WriteLine("Directory*********************************************************************");
            #region Directory
            {
                Console.WriteLine("获取当前完整目录");
                Console.WriteLine(Directory.GetCurrentDirectory());

                Console.WriteLine("创建目录，存在的就跳过");
                Console.WriteLine(Directory.CreateDirectory("D:\\path\\directory"));

                Console.WriteLine("判断目录是否存在");
                Console.WriteLine(Directory.Exists("D:\\path\\directory"));

                Console.WriteLine("获取目录最后修改时间");
                Console.WriteLine(Directory.GetLastWriteTime("D:\\path\\directory"));

                Console.WriteLine("获取目录下的所有文件");
                string[] files = Directory.GetFiles("D:\\");
                foreach (string file in files)
                {
                    Console.WriteLine(file);
                }

                Console.WriteLine("获取目录下的所有文件，匹配查找");
                string[] files2 = Directory.GetFiles("D:\\", "*.txt");
                foreach (string file in files2)
                {
                    Console.WriteLine(file);
                }

                Console.WriteLine("获取目录下的所有目录");
                string[] directories = Directory.GetDirectories("D:\\");
                foreach (string directory in directories)
                {
                    Console.WriteLine(directory);
                }

                Console.WriteLine("获取目录下的所有目录，匹配查找");
                string[] directories2 = Directory.GetDirectories("D:\\", "*360*");
                foreach (string directory in directories2)
                {
                    Console.WriteLine(directory);
                }

                Console.WriteLine("移动目录");
                Directory.CreateDirectory("D:\\A");
                Directory.Move("D:\\A", "D:\\B");

                Console.WriteLine("空目录直接删除");
                Directory.Delete("D:\\B");

                Console.WriteLine("非空目录递归删除");
                Directory.Delete("D:\\path", true);
            }
            #endregion

            Console.WriteLine("FileInfo*********************************************************************");
            #region FileInfo:FileSystemInfo
            {
                Console.WriteLine("创建文件");
                Directory.CreateDirectory("D:\\path\\");//创建了文件夹才能创建里面的文件
                FileInfo fileInfo = new FileInfo("D:\\path\\test.txt");
                FileStream fs = fileInfo.Create();
                fs.Close();

                //继承自FileSystemInfo
                Console.WriteLine("文件属性");
                Console.WriteLine("快捷方式或者符号链接指向的地址：" + fileInfo.LinkTarget);
                Console.WriteLine("创建时间：" + fileInfo.CreationTime);
                Console.WriteLine("最后访问时间：" + fileInfo.LastAccessTime);
                Console.WriteLine("最后修改时间：" + fileInfo.LastWriteTime);
                Console.WriteLine("完整名称：" + fileInfo.FullName);
                Console.WriteLine("名称：" + fileInfo.Name);
                Console.WriteLine("扩展名：" + fileInfo.Extension);
                Console.WriteLine("属性：" + fileInfo.Attributes);
                Console.WriteLine("是否存在：" + fileInfo.Exists);

                //FileInfo特有
                Console.WriteLine("是否只读：" + fileInfo.IsReadOnly);
                Console.WriteLine("大小（以字节为单位）：" + fileInfo.Length);
                Console.WriteLine("目录名称：" + fileInfo.DirectoryName);
                Console.WriteLine("目录对象：" + fileInfo.Directory);

                Console.WriteLine("打开文件");
                using (FileStream fileStream = fileInfo.Open(FileMode.Open))
                {
                    // 在这里执行对文件的读取或其他操作
                    // 当 using 块结束时，FileStream 对象会自动关闭并释放资源。
                }
                using (FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                {
                    // 在这里执行对文件的读取或其他操作
                    // 当 using 块结束时，FileStream 对象会自动关闭并释放资源。
                }
                using (FileStream fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    // 在这里执行对文件的读取或其他操作
                    // 当 using 块结束时，FileStream 对象会自动关闭并释放资源。
                }
                FileStreamOptions ops = new FileStreamOptions();
                ops.Mode = FileMode.Open;
                ops.Access = FileAccess.Read;
                ops.Share = FileShare.Read;
                using (FileStream fileStream = fileInfo.Open(ops))
                {
                    // 在这里执行对文件的读取或其他操作
                    // 当 using 块结束时，FileStream 对象会自动关闭并释放资源。
                }

                Console.WriteLine("打开一个文件将文本追加到文件的末尾");
                using (StreamWriter writer = fileInfo.AppendText())
                {
                    writer.WriteLine("打开一个文件将文本追加到文件的末尾");
                }

                Console.WriteLine("创建或打开一个文本文件");
                FileInfo fileInfo2 = new FileInfo("D:\\path\\test2.txt");
                using (StreamWriter writer = fileInfo2.CreateText())
                {
                    writer.WriteLine("创建或打开一个文本文件");
                }

                Console.WriteLine("打开一个文本文件");
                using (StreamReader reader = fileInfo.OpenText())
                {
                    // 在这里执行对文本文件的读取或写入操作  
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine("加密文件");
                fileInfo.Encrypt();

                Console.WriteLine("解密文件");
                fileInfo.Decrypt();

                Console.WriteLine("将文件从一个位置复制到另一个位置");
                fileInfo.CopyTo("D:\\path\\test3.txt");//test test2 test3

                Console.WriteLine("将文件从一个位置复制到另一个位置，可以覆盖");
                fileInfo.CopyTo("D:\\path\\test2.txt", true);//test test2 test3

                Console.WriteLine("将文件从一个位置移动到另一个位置");
                fileInfo.MoveTo("D:\\path\\test4.txt");//test2 test3 test4

                Console.WriteLine("将文件从一个位置移动到另一个位置，可以覆盖");
                FileInfo fileInfo3 = new FileInfo("D:\\path\\test3.txt");
                fileInfo3.MoveTo("D:\\path\\test4.txt", true);//test2 test4

                Console.WriteLine("替换文件");
                FileInfo fileInfo4 = new FileInfo("D:\\path\\test4.txt");
                fileInfo4.Replace("D:\\path\\test2.txt", null, true);//test2

                Console.WriteLine("删除文件");
                FileInfo fileInfo5 = new FileInfo("D:\\path\\test2.txt");
                fileInfo5.Delete();
                Directory.Delete("D:\\path\\");
            }
            #endregion

            Console.WriteLine("DirectoryInfo*********************************************************************");
            #region DirectoryInfo:FileSystemInfo
            {
                Console.WriteLine("创建目录");
                DirectoryInfo directoryInfo = new DirectoryInfo("D:\\path\\");
                directoryInfo.Create();

                //继承自FileSystemInfo
                Console.WriteLine("目录属性");
                Console.WriteLine("快捷方式或者符号链接指向的地址：" + directoryInfo.LinkTarget);
                Console.WriteLine("创建时间：" + directoryInfo.CreationTime);
                Console.WriteLine("最后访问时间：" + directoryInfo.LastAccessTime);
                Console.WriteLine("最后修改时间：" + directoryInfo.LastWriteTime);
                Console.WriteLine("完整名称：" + directoryInfo.FullName);
                Console.WriteLine("名称：" + directoryInfo.Name);
                Console.WriteLine("扩展名：" + directoryInfo.Extension);
                Console.WriteLine("属性：" + directoryInfo.Attributes);
                Console.WriteLine("是否存在：" + directoryInfo.Exists);

                //DirectoryInfo特有
                Console.WriteLine("父目录：" + directoryInfo.Parent);
                Console.WriteLine("根目录：" + directoryInfo.Root);

                Console.WriteLine("在目录基础上创建子目录");
                directoryInfo.CreateSubdirectory("subpath");
                directoryInfo.CreateSubdirectory("subpath2");
                directoryInfo.CreateSubdirectory("subpath3");
                directoryInfo.CreateSubdirectory("sub3");

                Console.WriteLine("遍历匹配的子路径，一边遍历一边加载");
                DirectoryInfo directoryInfo2 = new DirectoryInfo("D:\\");
                foreach (var d in directoryInfo2.EnumerateDirectories("*360*"))
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine("遍历匹配的子文件，一边遍历一边加载");
                foreach (var d in directoryInfo2.EnumerateFiles())
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine("遍历匹配的子文件或路径，一边遍历一边加载");
                foreach (var d in directoryInfo2.EnumerateFileSystemInfos())
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine("遍历匹配的子路径，加载完开始遍历");
                foreach (var d in directoryInfo2.GetDirectories("*360*"))
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine("遍历匹配的子文件，加载完开始遍历");
                foreach (var d in directoryInfo2.GetFiles())
                {
                    Console.WriteLine(d);
                }
                Console.WriteLine("遍历匹配的子文件或路径，加载完开始遍历");
                foreach (var d in directoryInfo2.GetFileSystemInfos())
                {
                    Console.WriteLine(d);
                }

                Console.WriteLine("递归删除目录");
                directoryInfo.Delete(true);
            }
            #endregion

            Console.WriteLine("DriveInfo*********************************************************************");
            #region DriveInfo
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine("驱动器的名称：" + drive.Name + "***********************************************");
                    Console.WriteLine("可用空闲空间：" + drive.AvailableFreeSpace);
                    Console.WriteLine("驱动器格式：" + drive.DriveFormat);
                    Console.WriteLine("驱动器类型：" + drive.DriveType + " bytes");
                    Console.WriteLine("检查驱动器是否已经准备好进行读/写操作: " + drive.IsReady);
                    Console.WriteLine("驱动器的根目录：" + drive.RootDirectory);
                    Console.WriteLine("驱动器上的可用总字节数：" + drive.TotalFreeSpace);
                    Console.WriteLine("驱动器上的总字节数：" + drive.TotalSize);
                    Console.WriteLine("卷标签：" + drive.VolumeLabel);
                }
            }
            #endregion

            Console.WriteLine("FileSystemWatcher*********************************************************************");
            if (!Directory.Exists(@"D:\Directory"))
            {
                Directory.CreateDirectory(@"D:\Directory");
            }
            if (!Directory.Exists(@"D:\Directory1"))
            {
                Directory.CreateDirectory(@"D:\Directory1");
            }
            if (!Directory.Exists(@"D:\Directory2"))
            {
                Directory.CreateDirectory(@"D:\Directory2");
            }
            if (!Directory.Exists(@"D:\Directory3"))
            {
                Directory.CreateDirectory(@"D:\Directory3");
            }
            #region FileSystemWatcher
            //监控单个文件夹
            {
                // 创建一个新的 FileSystemWatcher  
                FileSystemWatcher watcher = new FileSystemWatcher();

                // 指定要监视的目录  
                watcher.Path = @"D:\Directory";

                // 订阅触发事件  
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;

                // 默认 监控所有文件
                watcher.Filter = "*.*";

                //绑定处理函数
                watcher.Changed += OnChanged;//文件或目录变化
                watcher.Created += OnChanged;//文件或目录创建
                watcher.Deleted += OnChanged;//文件或目录删除
                watcher.Renamed += OnRenamed;//文件或目录重命名

                // 开始监视  
                watcher.EnableRaisingEvents = true;
            }
            //监控多个文件夹
            {
                string[] directoriesToWatch = { @"D:\Directory1", @"D:\Directory2", @"D:\Directory3" };
                FileSystemWatcher[] watchers = new FileSystemWatcher[directoriesToWatch.Length];
                for (int i = 0; i < directoriesToWatch.Length; i++)
                {
                    watchers[i] = new FileSystemWatcher();
                    watchers[i].Path = directoriesToWatch[i];
                    watchers[i].NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    watchers[i].Filter = "*.*";
                    watchers[i].Changed += OnChanged;
                    watchers[i].Created += OnChanged;
                    watchers[i].Deleted += OnChanged;
                    watchers[i].Renamed += OnRenamed;
                    watchers[i].EnableRaisingEvents = true;
                }
            }
            Console.ReadKey();
            Directory.Delete(@"D:\Directory");
            Directory.Delete(@"D:\Directory1");
            Directory.Delete(@"D:\Directory2");
            Directory.Delete(@"D:\Directory3");
            #endregion
            #endregion

            #region 文件读写
            {
                Console.WriteLine("FileStream写入文件");
                using (FileStream fsr = File.Create("input.txt"))//不存在创建，存在覆盖
                {
                    byte[] bytes = Encoding.UTF8.GetBytes("1234567890");
                    fsr.Write(bytes, 0, bytes.Length);
                    fsr.Flush();//写入磁盘
                }
                using (FileStream fileStream = File.Create("input.txt"))//不存在创建，存在覆盖
                {
                    StreamWriter sw = new StreamWriter(fileStream);
                    sw.WriteLine("12345678");
                    sw.Flush();
                }

                Console.WriteLine("StreamWriter写入文件");
                using (StreamWriter sw = File.AppendText("input.txt"))//追加文本
                {
                    sw.WriteLine("1234567");
                    sw.Flush();
                }
                using (StreamWriter sw = File.AppendText("input.txt"))//追加文本
                {
                    byte[] bytes = Encoding.Default.GetBytes("123456");
                    sw.BaseStream.Write(bytes, 0, bytes.Length);
                    sw.Flush();
                }

                Console.WriteLine("StreamWriter和StreamReader读写FileStream");
                using (FileStream fsInput = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fsInput))
                using (FileStream fsOutput = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fsOutput))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 在这里进行数据处理，例如将文本转换为大写  
                        string processedLine = line.ToUpper();
                        sw.WriteLine(processedLine);
                    }
                }

                Console.WriteLine("StreamWriter和StreamReader读写FileStream，简化写法");
                using (StreamReader sr = new StreamReader("input.txt", new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.Read }))
                using (StreamWriter sw = new StreamWriter("output.txt", new FileStreamOptions() { Mode = FileMode.OpenOrCreate, Access = FileAccess.Write }))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 在这里进行数据处理，例如将文本转换为大写  
                        string processedLine = line.ToUpper();
                        sw.WriteLine(processedLine);
                    }
                }

                Console.WriteLine("StreamWriter和StreamReader读写BufferedStream");
                using (BufferedStream bsInput = new BufferedStream(new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.Read)))
                using (StreamReader sr = new StreamReader(bsInput))
                using (BufferedStream bsOutput = new BufferedStream(new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.Write)))
                using (StreamWriter sw = new StreamWriter(bsOutput))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // 在这里进行数据处理，例如将文本转换为大写
                        string processedLine = line.ToUpper();
                        sw.WriteLine(processedLine);
                    }
                }

                Console.WriteLine("StreamWriter和StreamReader读写MemoryStream");
                List<string> lines = new List<string>() { "First line", "Second line", "Third line" };
                using (MemoryStream ms = new MemoryStream())
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    //写入MemoryStream
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line);
                    }
                }
                using (MemoryStream ms = new MemoryStream())
                using (StreamReader sr = new StreamReader(ms))
                {
                    //读取MemoryStream
                    ms.Position = 0;//设置读取位置从0开始
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine("StringWriter和StringReader读写字符串");
                using (StringWriter sw = new StringWriter())
                {
                    sw.Write("Hello, world!");
                    string output = sw.ToString();
                }
                string input = "This is a test string";
                using (StringReader sr = new StringReader(input))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                Console.WriteLine("BinaryWriter和BinaryReader读写二进制");
                if (File.Exists("data.bin")) File.Delete("data.bin");
                using (FileStream stream = new FileStream("data.bin", FileMode.Create))
                {
                    // 创建一个BinaryWriter对象  
                    BinaryWriter writer = new BinaryWriter(stream);

                    // 写入两个整数和一个字符串到文件中  
                    writer.Write(123);
                    writer.Write(456);
                    writer.Write("Hello, world!");

                    // 关闭Writer对象  
                    writer.Close();
                }
                using (FileStream stream = new FileStream("data.bin", FileMode.Open))
                {
                    // 创建一个BinaryReader对象  
                    BinaryReader reader = new BinaryReader(stream);

                    // 读取文件中的数据  
                    int num1 = reader.ReadInt32();
                    int num2 = reader.ReadInt32();
                    string str = reader.ReadString();

                    // 输出读取到的数据  
                    Console.WriteLine(num1);
                    Console.WriteLine(num2);
                    Console.WriteLine(str);

                    // 关闭Reader对象  
                    reader.Close();
                }

                if (File.Exists("largefile.txt")) File.Delete("largefile.txt");
                using (FileStream fs = File.Create("largefile.txt"))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        sw.WriteLine(Guid.NewGuid().ToString());
                    }
                }

                Console.WriteLine("大文件读写优化-1.使用BufferedStream类");
                using (FileStream fs = new FileStream("largefile.txt", FileMode.Open))
                {
                    using (BufferedStream bs = new BufferedStream(fs))
                    {
                        byte[] buffer = new byte[10]; // 块大小
                        int bytesRead;
                        while ((bytesRead = bs.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            // 处理读入的数据，例如输出到控制台  
                            Console.Write(Encoding.UTF8.GetString(buffer));
                        }
                    }
                }

                Console.WriteLine("大文件读写优化-2.分块读取文件");
                using (FileStream fs = new FileStream("largefile.txt", FileMode.Open))
                {
                    byte[] buffer = new byte[10]; //块大小
                    int bytesRead;
                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        // 处理读入的数据，例如输出到控制台  
                        Console.Write(Encoding.UTF8.GetString(buffer));
                    }
                }

                Console.WriteLine("大文件读写优化-3.使用StreamReader和StreamWriter类进行文本文件的读写");
                using (FileStream fs = new FileStream("largefile.txt", FileMode.Open))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("Hello World!"); // 写入一行文本  
                        sw.Flush(); // 刷新缓冲区，将数据写入文件  
                    }
                }
                using (FileStream fs = new FileStream("largefile.txt", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            // 处理读取的文本行，例如输出到控制台  
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            #endregion

            #region 递归遍历所有文件夹、文件
            {
                Console.WriteLine("递归遍历所有文件夹、文件");
                var files = FileHepler.GetAllFiles("D:\\");
                Console.WriteLine("文件数量：" + files.Count);
                var directorys = FileHepler.GetAllDirectorys("D:\\");
                Console.WriteLine("文件夹数量：" + directorys.Count);
            }
            #endregion

            #region 日志帮助类
            {
                foreach (var file in Directory.GetFiles(".\\", "*.log"))
                {
                    File.Delete(file);
                }
                Console.WriteLine("打印日志测试");
                for (int i = 0; i < 100; i++)
                {
                    LogHelper.Log(Guid.NewGuid().ToString());
                }
            }
            #endregion

            Console.ReadKey();
        }

        private static void OnChanged(object source, FileSystemEventArgs e) => Console.WriteLine($"File or directory {e.FullPath} was {e.ChangeType}");

        private static void OnRenamed(object source, RenamedEventArgs e) => Console.WriteLine($"File: {e.OldName} renamed to {e.Name}");
    }
}