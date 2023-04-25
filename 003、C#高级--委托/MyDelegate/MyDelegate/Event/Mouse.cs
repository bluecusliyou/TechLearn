using System;

namespace MyDelegate.Event
{
    public class Mouse : IObject
    {
        public void Invoke()
        {
            this.Run();
        }
        public void Run()
        {
            Console.WriteLine("{0} Run", this.GetType().Name);
        }
    }
}
