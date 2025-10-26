namespace MyIO
{
    public class FileHepler
    {
        /// <summary>
        /// 获取路径下的所有文件夹
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public static List<DirectoryInfo> GetAllDirectorys(string rootPath)
        {
            if (!Directory.Exists(rootPath))
                return new List<DirectoryInfo>();

            List<DirectoryInfo> directoryList = new List<DirectoryInfo>();//容器
            DirectoryInfo directory = new DirectoryInfo(rootPath);//root文件夹
            directoryList.Add(directory);

            return GetChildDirectorys(directoryList, directory);
        }

        /// <summary>
        /// 递归获取子文件夹
        /// </summary>
        /// <param name="directoryList"></param>
        /// <param name="directoryCurrent"></param>
        /// <returns></returns>
        private static List<DirectoryInfo> GetChildDirectorys(List<DirectoryInfo> directoryList, DirectoryInfo directoryCurrent)
        {
            var childDirectorys = directoryCurrent.GetDirectories();
            if (childDirectorys != null && childDirectorys.Length > 0)
            {
                directoryList.AddRange(childDirectorys);
                foreach (var child in childDirectorys)
                {
                    GetChildDirectorys(directoryList, child);
                }
            }
            return directoryList;
        }

        /// <summary>
        /// 获取路径下的所有文件
        /// </summary>
        /// <param name="rootPath"></param>
        /// <returns></returns>
        public static List<FileInfo> GetAllFiles(string rootPath)
        {
            if (!Directory.Exists(rootPath))
                return new List<FileInfo>();

            List<FileInfo> fileList = new List<FileInfo>();//容器
            DirectoryInfo directory = new DirectoryInfo(rootPath);//root文件夹

            return GetChildFiles(fileList, directory);
        }

        /// <summary>
        /// 递归获取子文件夹的文件
        /// </summary>
        /// <param name="fileList"></param>
        /// <param name="directoryCurrent"></param>
        /// <returns></returns>
        private static List<FileInfo> GetChildFiles(List<FileInfo> fileList, DirectoryInfo directoryCurrent)
        {
            //添加文件
            var childFiles= directoryCurrent.GetFiles();
            if (childFiles != null && childFiles.Length > 0)
            {
                fileList.AddRange(childFiles);
            }

            //递归遍历文件夹
            var childDirectorys = directoryCurrent.GetDirectories();
            if (childDirectorys != null && childDirectorys.Length > 0)
            {
                foreach (var child in childDirectorys)
                {
                    GetChildFiles(fileList, child);
                }
            }
            return fileList;
        }
    }
}
