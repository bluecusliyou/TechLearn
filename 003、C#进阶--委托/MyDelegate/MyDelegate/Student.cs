using System;

namespace MyDelegate
{
    /// <summary>
    /// 学生类
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserType ClassId { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// 问好
        /// </summary>
        public void SayHi()
        {
            Console.WriteLine("招手。。。");
            switch (ClassId)
            {
                case UserType.Wuhan:
                    Console.WriteLine("吃了么？过早了吗？");
                    break;
                case UserType.Shanghai:
                    Console.WriteLine("侬好!");
                    break;
                case UserType.GuangDong:
                    Console.WriteLine("雷猴！");
                    break;
                default:
                    throw new Exception("NO UserType");
            }
        }

        public void SayHiWuhHan()
        { 
            Console.WriteLine("吃了么？过早了吗？");
        }

        public void SayHiShangHai()
        { 
            Console.WriteLine("侬好!");
        }

        public void SayHiGuangDong()
        { 
            Console.WriteLine("雷猴！");
        }

        public void SayHiBeijing()
        { 
            Console.WriteLine("早上好！");
        }

        /// <summary>
        /// 既没有重复代码
        /// 也相对稳定
        /// </summary>
        public void SayHiPerfect(SayHiDalegate sayHiDalegate)
        {
            Console.WriteLine("招手。。。");
            sayHiDalegate.Invoke();
        }
    }

    public delegate void SayHiDalegate();

    public enum UserType
    {
        Wuhan = 1,
        Shanghai = 2,
        GuangDong = 3,
        BeiJing = 4
    }
}
