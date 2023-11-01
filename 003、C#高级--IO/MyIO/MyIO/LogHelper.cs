namespace MyIO
{
    public class LogHelper
    {
        private static readonly int maxFileSize = 1024  * 5; // 文件最大大小为5KB

        public static void Log(string message)
        {
            string logFilePath = $"{DateTime.Now.ToString("yyyyMMdd")}.log"; // 日志文件路径 按照日期命名

            // 判断日志文件是否存在，不存在则创建  
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Dispose();
            }

            // 计算当前日志文件的大小
            FileInfo fileInfo = new FileInfo(logFilePath);
            long fileSize = fileInfo.Length;

            // 如果日志文件大小超过最大值，则切割文件  
            if (fileSize > maxFileSize)
            {
                string[] files = Directory.GetFiles(".\\", DateTime.Now.ToString("yyyyMMdd") + "*");

                // 构造新文件名  
                string newFileName = string.Format("{0}_{1}.log", DateTime.Now.ToString("yyyyMMdd"), files.Length+1);

                // 移动当前日志文件到新文件名  
                File.Move(logFilePath, newFileName);

                // 重新创建空日志文件  
                File.Create(logFilePath).Dispose();
            }

            // 写入日志信息  
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + "：" + message);
            }
        }
    }
}
