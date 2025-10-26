using System;

namespace Business.DB.Model
{
    /// <summary>
    /// 实体---属性是不能保存数据，只有字段才能保存数据
    /// </summary>
    public class People
    {
        public People()
        {
            Console.WriteLine("{0}被创建", this.GetType().FullName);
        }
         
        public int Id { get; set; }//带有Get Set 方法的叫做属性

        public string Name { get; set; }

        public int Age { get; set; }
         
        public string Description;//字段
    }
}
