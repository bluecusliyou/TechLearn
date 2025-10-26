using System;

namespace MyAutofac
{
    public class Huawei : IPhone
    {
        public virtual string ShowName()
        {
            Console.WriteLine("Huawei");
            return "Huawei";
        }
    }
}
