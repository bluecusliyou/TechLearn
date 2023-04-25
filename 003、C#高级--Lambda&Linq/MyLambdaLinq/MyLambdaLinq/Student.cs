using System;

namespace MyLambdaLinq
{
    /// <summary>
    /// 学生实体
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// 学习
        /// </summary>
        public void Study()
        {
            Console.WriteLine("Study...");
        }

        /// <summary>
        /// 方案1：类直接新增一个方法
        /// </summary>
        public void StudyFramework()
        {
            Console.WriteLine($"{Id} {Name}类内部方法。。。。");
        }
    }

    /// <summary>
    /// 班级实体
    /// </summary>
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}
