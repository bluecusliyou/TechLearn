using System;

namespace MyDelegate
{
    /// <summary>
    /// 标准事件定义
    /// </summary>
    public class EventStandard
    {        
        public static void Show()
        {
            //初始化发布者
            Publisher publisher = new Publisher();
            //初始化订阅者1
            Observer1 observer1 = new Observer1();
            //初始化订阅者2
            Observer2 observer2 = new Observer2();
            //订阅者订阅事件
            publisher.Publish += observer1.Action1;
            publisher.Publish += observer2.Action2;
            //触发事件
            publisher.EventAction();
        }        
    }

    /// <summary>
    /// 发布者：对外发布事件；触发事件；
    /// </summary>
    public class Publisher
    {
        //发布事件
        public event EventHandler Publish;

        //发布者触发事件
        public void EventAction()
        {
            Console.WriteLine("触发事件");
            Publish?.Invoke(null,null);
        }
    }

    /// <summary>
    /// 订阅者：对发布者发布的事情关注
    /// </summary>
    public class Observer1
    {
        /// <summary>
        /// 订阅者1的行为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Action1(object sender, EventArgs e)
        {            
            Console.WriteLine("订阅者1的行为");
        }
    }

    /// <summary>
    /// 订阅者：对发布者发布的事情关注
    /// </summary>
    public class Observer2
    {
        /// <summary>
        /// 订阅者2的行为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Action2(object sender, EventArgs e)
        {
            Console.WriteLine("订阅者2的行为");
        }
    }
}
