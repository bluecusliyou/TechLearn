using System;

namespace MyAutofac
{
    public class Student : IStudent
    {
        public IPhone phone;

        public Student(IPhone phone)
        {
            this.phone = phone;
        }

        public void PlayPhone()
        {
            Console.WriteLine($"i play {phone.ShowName()}");
        }
    }
}
