using System;

namespace MyAutofac
{
    public class Honer : IPhone
    {
        public virtual string ShowName()
        {
            Console.WriteLine("Honer");
            return "Honer";
        }
    }
}
