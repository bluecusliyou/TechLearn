using Business.DB.Interface;
using System;

namespace Business.DB.MySql
{
    public class MySqlHelper : IDBHelper
    {
        public MySqlHelper()
        {
            Console.WriteLine($"{this.GetType().Name}被构造");
        }


        public void Query()
        {
            Console.WriteLine("{0}.Query", this.GetType().Name);
        }
    }
}
