using System;

namespace MyDelegate.Event
{    
    public class Baby : IObject
    {
        public void Invoke()
        {
            this.Cry();
        }

        public void Cry()
        {
            Console.WriteLine("{0} Cry", this.GetType().Name);
        }
    }
}
