using MyAttribute.EnumExtend;
using MyAttribute.ValidateExtend;
using System;

namespace MyAttribute
{
    /// <summary>
    /// 1 特性attribute，和注释有什么区别
    /// 2 声明和使用attribute，AttributeUsage
    /// 3 运行中获取attribute：额外信息 额外操作
    /// 4 Remark封装、attribute验证
    /// 
    /// 特性是无处不在
    /// EF--MVC--WCF--WebService--UnitTest--IOC--AOP--SuperSocket
    /// 特性很厉害，加了特性之后，就有很厉害的功能
    /// [Obsolete]编译时就有提示   影响了编译器
    /// [Serializable]对象就可以序列化 影响了程序运行
    /// 
    /// 特性attribute;就是一个类，直接继承/间接继承自Attribute父类
    ///     约定俗成用Attribute结尾，标记时就可以省略掉
    /// 可以用中括号包裹，然后标记到元素，其实就是调用构造函数
    /// 然后可以指定属性 字段
    /// 
    /// AttributeUsage特性，影响编译器运行，
    /// 指定修饰的对象---能否重复修饰--修饰的特性子类是否生效
    /// 建议是明确约束用在哪些对象的
    /// 
    /// 自定义的特性，好像毫无意义，
    /// 那框架提供的特性究竟是怎么产生价值的呢？！
    /// [Obsolete][AttributeUsage]   影响了编译器,这属于系统内置，我们搞不了
    /// 
    /// 反编译之后，发现特性会在元素内部生成 .custom的东西
    /// 但是这个东西我们C#访问不到------简直可以理解为，特性没有产生任何变化
    /// 
    /// 但是框架究竟是怎么产生功能的呢？
    /// 怎么样在程序运行的时候，能够找到特性，反射！
    /// 可以从类型  属性  方法 都可以获取特性实例，要求先IsDefined检测  再获取(实例化)
    /// 
    /// 程序运行时可以找到特性---那就可以发挥特性的作用--提供额外的信息--提供额外的行为
    /// 需要一个第三方InvokeCenter，在这里去主动检测并且使用特性，才能提供功能
    /// 特性本身是没有用的，
    /// 
    /// 特性是在编译时确定的，构造函数/属性/字段，都不能用变量，
    /// 所以，mvc5-filter是不能注入的，所以在core里面才提供了注入filter的方式
    /// 
    /// 1 特性封装提供额外信息Remark封装
    /// 2 特性封装提供额外行为Validate验证
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region 什么是特性
                {
                    Student student = new Student()
                    {
                        Id = 123,
                        Name = "橙"
                    };
                    student.Study();
                    student.Answer("Eleven");
                }
                {
                    Student student = new StudentVip()
                    {
                        Id = 123,
                        Name = "Alxe"
                    };
                    InvokeCenter.ManagerStudent<Student>(student);
                }
                #endregion

                #region 特性实现枚举展示描述信息
                {
                    UserState userState = UserState.Frozen;                    
                    string reamrk = userState.GetRemark();
                    //有了特性，文字其实是直接固化在枚举上面， 如果修改只用改这里
                    //1 数据展示--不想展示属性名字，而是用一个中文描述
                    //2 想指定哪个是主键 哪个是自增
                    //3 别名--数据库里面叫A 程序叫B，怎么映射起来
                }
                #endregion

                #region 特性实现数据验证，并且可扩展
                {
                    //通过特性去提供额外行为
                    //数据验证--到处都需要验证
                    StudentVip student = new StudentVip()
                    {
                        Id = 123,
                        Name = "无为",
                        QQ = 729220650,
                        Salary = 1010000
                    };                    

                    if (student.Validate())
                    {
                        Console.WriteLine("特性校验成功");
                    }
                    //1 可以校验多个属性
                    //2 支持多重校验
                    //3 支持规则的随意扩展
                }
                #endregion

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
