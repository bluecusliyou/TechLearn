using System;
using System.Collections.Generic;

namespace MyDelegate.Event
{
    /// <summary>
    /// 需求：猫叫之后引发一系列的动作
    /// </summary>
    public class Cat
    {
        /// <summary>
        /// 方案1：封装一个方法，调用一系列动作
        ///        职责不单一，依赖于其他的类太多，代码不稳定，任何一个类的修改，都有可能会影响到这只猫
        /// </summary>
        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);
            new Dog().Wang(); //狗叫了
            new Mouse().Run();//老鼠跑了
            new Baby().Cry(); // 小孩哭了
        }

        public Action MiaoDelegateHandler = null;
        /// <summary>
        /// 方案2：引发的动作注册到多播委托中去
        ///        职责单一，猫只是执行委托的方法链，方法链注册交个第三方，不在猫内部
        ///        使用委托的方式来实现观察者模式
        /// </summary>
        public void MiaoDelegate()
        {
            Console.WriteLine("{0} MiaoDelegate", this.GetType().Name);
            MiaoDelegateHandler?.Invoke();//?. 如果不为null ，就执行后面的动作 
        }
         
        public List<IObject> observerlist = new List<IObject>();
        /// <summary>
        /// 方案3：引发的动作注册到方法列表中去
        ///        职责单一，猫只是执行方法列表，方法列表的注册交给第三方，不在猫的内部
        ///        完全使用面向对象的方式来实现观察者模式
        /// </summary>
        public void MiaoObsever()
        {
            Console.WriteLine("{0} MiaoObsever", this.GetType().Name);
            if (observerlist.Count>0)
            {
                foreach (var item in observerlist)
                {
                    item.Invoke();
                }
            }
        }

        public event Action MiaoEventHandler = null;
        /// <summary>
        /// 方案4：引发的动作注册到事件中去
        ///        复制方案2，加上关键字event
        /// </summary>
        public void MiaoEnvent()
        {            
            Console.WriteLine("{0} MiaoEnvent", this.GetType().Name);
            MiaoEventHandler?.Invoke();//?. 如果不为null ，就执行后面的动作 
        }
    }
}
