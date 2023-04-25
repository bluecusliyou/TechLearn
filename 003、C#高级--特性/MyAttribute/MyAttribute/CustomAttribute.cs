using System;

namespace MyAttribute
{

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class CustomAttribute : Attribute
    {
        public CustomAttribute()
        {
            Console.WriteLine($"{this.GetType().Name} 无参数构造函数执行");
        }
        public CustomAttribute(int id)
        {
            Console.WriteLine($"{this.GetType().Name} int参数构造函数执行");
            this._Id = id;
        }
        public CustomAttribute(string name)
        {
            Console.WriteLine($"{this.GetType().Name} string参数构造函数执行");
            this._Name = name;
        }

        private int _Id = 0;
        private string _Name = null;

        public string Remark;
        public string Description { get; set; }

        public void Show()
        {
            Console.WriteLine($"{this._Id}_{this._Name}_{this.Remark} _ {this.Description}");
        }
    }

    public class CustomAttributeChild : CustomAttribute
    {
        public CustomAttributeChild() : base(123)
        { }
    }
}
