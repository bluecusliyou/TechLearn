using System;

namespace MyHangfire
{
    public class SyncUserDataSchedule
    {
        public void SyncUserData()
        {
            Console.WriteLine($"同步用户数据--{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}
