using System;

namespace MyDelegate.Event
{
    public class Dog : IObject
    {
        public void Invoke()
        {
            this.Wang();
        }
        public void Wang()
        {
            Console.WriteLine("{0} Wang", this.GetType().Name);
        }
    }
}
