using System;

namespace MyReflecttion
{
    /// <summary>
    /// 单例模式：类，能保证在整个进程中只有一个实例
    /// </summary>
    public sealed class Singleton
    {
        private static Singleton _Singleton = null;
        /// <summary>
        /// 创建对象的时候执行
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Singleton被构造");
        }

        /// <summary>
        /// 被CLR 调用 整个进程中 执行且只执行一次
        /// </summary>
        static Singleton()
        {
            _Singleton = new Singleton();
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}
