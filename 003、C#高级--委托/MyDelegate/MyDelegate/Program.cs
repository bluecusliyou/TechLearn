using MyDelegate.Event;
using System;
using System.Reflection;

namespace MyDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ////一、委托是什么
                ////1、委托是什么
                ////（1）委托和类一样是一种用户自定义类型，它存储的就是一系列具有相同签名和返回类型的方法的地址，调用委托的时候，它所包含的所有方法都会被执行。
                ////（2）委托使得可以将方法当作另一个方法的参数来进行传递，这种将方法动态地赋给参数的做法，使得程序具有更好的可扩展性。
                ////2、委托声明   CustomDelegate
                ////（1）委托可以声明在类外部，也可以在类内部
                ////（2）跟方法有点类似，有参数，返回值，访问修饰符，比方法声明多一个关键字delegate
                ////3、委托的本质
                ////（1）委托是一个类，继承自MulticastDelegate
                //// MulticastDelegate这个类我们自己定义的类是无法继承的
                ////（2）委托的构造函数，需要传递一个方法作为参数
                ////（3）委托的内部有三个方法Invoke，BeginInvoke，EndInvoke

                ////二、委托实例化和委托
                ////1、委托实例化
                ////（1）通过New来实例化，要求传递一个和这个委托的参数和返回值完全匹配的方法
                ////（2）直接=一个方法，要求方法和这个委托的参数和返回值完全匹配，这个是编译器提供的语法糖
                ////（3）直接=一个匿名委托，要求和这个委托的参数和返回值完全匹配
                ////（4）直接=一个Lambda，要求和这个委托的参数和返回值完全匹配                
                ////2、委托执行
                ////（1）Inovke执行方法，如果委托定义没有参数，则Inovke也没有参数；委托没有返回值，则Inovke也没有返回值
                ////（2）BeginInvoke开启一个新的线程去执行委托
                ////NetCore不支持，NetFamework支持  NetCore有更好的多线程功能来支持实现类似功能
                ////（3）EndInvoke等待BeginInvoke方法执行完成后再执行EndInvoke后面的代码
                ////NetCore不支持，NetFamework支持  NetCore有更好的多线程功能来支持实现类似功能
                //CustomDelegateShow.Show();

                {
                    ////三、委托的作用和意义
                    ////1、需求：不同的学生实现不同打招呼方式
                    ////（1）方案1：定义枚举，不同枚举值调用不同代码
                    //Student student = new Student()
                    //{
                    //    Id = 1234,
                    //    Name = "张三",
                    //    Age = 25,
                    //    ClassId = UserType.Shanghai
                    //};
                    //student.SayHi();
                    ////（2）方案2：根据不同的类型的人，调用不同方法
                    //student.SayHiWuhHan();
                    //student.SayHiShangHai();
                    //student.SayHiGuangDong();
                    ////（3）方案3：使用委托将方法传递进去执行
                    //student.SayHiPerfect(student.SayHiWuhHan);
                    //student.SayHiPerfect(student.SayHiShangHai);
                    //student.SayHiPerfect(student.SayHiGuangDong);

                    ////2、需求变更：如果增加一个类型的人 
                    ////（1）方案1：SayHi里面增加一个分支，SayHi不稳定。
                    ////（2）方案2：每个方法都式独立的，只需要增加一个方法。
                    ////（3）方案3：也只需要增加一个方法，然后传进去执行。

                    ////3、需求再变更：每个人打招呼之前，需要先招手
                    ////（1）方案1：SayHi在所有逻辑之前加招手逻辑。
                    ////（2）方案2：每个方法都式独立的，每个方法都需要增加招手逻辑，要修改所有方法。
                    ////（3）方案3：SayHiPerfect里面委托执行前加招手逻辑。

                    ////4、方案比较下来，方案3更加灵活，扩展性更好。

                    ////5、什么情况下，可以考虑使用委托？
                    ////（1）方法内部业务逻辑耦合严重
                    ////（2）如果多个方法，有很多重复代码，逻辑重用
                }

                {
                    ////四、委托实现嵌套中间件
                    ////1、委托朴素嵌套实现
                    //CustomDelegateExtension.Show();
                    ////2、委托花式嵌套实现
                    //CustomDelegateExtension.Show2();
                }

                {
                    ////五、框架内置委托
                    ////.NET Framework3.0时代--Action/Func
                    //new FrameworkeDelegate().Show();
                }

                {
                    ////六、多播委托
                    ////1、多播委托
                    ////（1）委托都是继承自MulticastDelegate(多播委托)，定义的所有的委托都是多播委托
                    ////（2）可以通过+=把多个方法添加到这个委托中，形成一个方法的执行链，执行委托的时候，按照添加方法的顺序，依次去执行方法
                    ////（3）action.BeginInvoke();会开启一个新的线程 去执行委托，注册有多个方法的委托，不能使用BeginInvoke
                    ////（4）注册有多个方法的委托想要开启新线程去执行委托，可以通过action.GetInvocationList()获取到所有的委托，然后循环，每个方法执行的时候可以BeginInvoke
                    //new CustomMulticastDelegation().Show();
                    ////（5）可以通过-=移除方法，是从后往前，逐个匹配，如果匹配不到，就不做任何操作，如果匹配到，就把当前这个移除，且停止去继续往后匹配
                    ////（6）在移除的方法的时候，必须是同一个实例的同一个方法才能移除，每个lambda表达式在底层会生成不同的方法名的，看起来一样实际不同
                    //new CustomMulticastDelegation().Show2();

                    ////2、观察者模式
                    ////（1）需求：猫叫之后引发一系列的动作
                    ////方案1：封装一个方法，调用一系列动作
                    ////       职责不单一，依赖于其他的类太多，代码不稳定，任何一个类的修改，都有可能会影响到这只猫
                    //Console.WriteLine("************************this is  function****************************");
                    //Cat cat = new Cat();
                    //cat.Miao();
                    ////方案2：引发的动作注册到多播委托中去
                    ////       职责单一，猫只是执行委托的方法链，方法链注册交个第三方，不在猫内部
                    ////       使用委托的方式来实现观察者模式
                    //Console.WriteLine("************************this is  delegate****************************");
                    //cat.MiaoDelegateHandler += new Dog().Wang; //狗叫了
                    //cat.MiaoDelegateHandler += new Mouse().Run;//老鼠跑了
                    //cat.MiaoDelegateHandler += new Baby().Cry; // 小孩哭了
                    //cat.MiaoDelegate();//执行
                    ////方案3：引发的动作注册到方法列表中去
                    ////       职责单一，猫只是执行方法列表，方法列表的注册交给第三方，不在猫的内部
                    ////       完全使用面向对象的方式来实现观察者模式
                    //Console.WriteLine("************************this is  Obeserver****************************");
                    //cat.observerlist.Add(new Dog()); //狗叫了
                    //cat.observerlist.Add(new Mouse());//老鼠跑了
                    //cat.observerlist.Add(new Baby()); // 小孩哭了
                    //cat.MiaoObsever();//执行
                    ////方案4：引发的动作注册到事件中去
                    ////       复制方案2，加上关键字event
                    //Console.WriteLine("************************this is  MiaoEnvent****************************");
                    //cat.MiaoEventHandler += new Mouse().Run;//老鼠跑了
                    //cat.MiaoEventHandler += new Dog().Wang; //狗叫了
                    //cat.MiaoEventHandler += new Baby().Cry; // 小孩哭了
                    //cat.MiaoEnvent();
                    ////cat.MiaoEventHanlder.Invoke();//类外部无法执行到类中的事件方法
                    ///////（2）观察者模式的几大要素
                    ////发布者
                    ////订阅者
                    ////订阅
                    ////触发事件
                }

                {
                    //七、什么是事件
                    //1、什么是事件
                    //（1）事件是委托实例，增加一个关键字Event，是特殊的委托
                    //（2）事件只能在当前类被访问，子类和类外部均不能执行类中的事件方法（安全）
                    //（3）委托和事件从本质上来说没啥区别
                    //2、WinForm中按钮点击事件解析
                    //页面上添加登录按钮双击生成了一个方法，运行起来，点击按钮，触发这个方法，这个过程是怎么完成的？
                    //（1）按钮其实是一个Button类，继承Control类，Control有一个Click事件，( EventHandler(object? sender, EventArgs e)) 
                    //（2）MyWinForm构造函数函数中有一个InitializeComponent方法，在InitializeComponent方法中初始化Button按钮实例，Button的实例中的Click事件+=一个动作btnLogin_Click方法
                    //（3）点击按钮，触发事件，执行注册事件的方法，也就是btnLogin_Click方法
                    //（4）更具体一些：程序运行，句柄被监听，监听鼠标的点击的动作，触发操作系统去找这个句柄是在哪个应用程序中，找到控件，执行这个控件中的事件，触发了方法
                    //（5）在按钮点击触发方法的设计中，有很多相同的逻辑，就把不变的业务逻辑封装代码重用，可变的业务逻辑对外发布一个事件，由外部给事件注册动作；框架设计的时候，是非常需要这种设计的，ASP.NET MVC5管道处理模型就是通过19大事件来完成的；
                    //3、标准事件的定义
                    //（1）发布者发布事件
                    //（2）订阅者订阅事件
                    //（3）触发事件
                    EventStandard.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
