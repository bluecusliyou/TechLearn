using System;

namespace MyDelegate
{
    /// <summary>
    /// 定义一个抽象特性
    /// </summary>
    public abstract class AbstractMethodAttribute : Attribute
    {
        /// <summary>
        /// 在xxx 执行之前执行的点业务落
        /// </summary>
        public abstract ShowDelegate Do(ShowDelegate action);
    }

    /// <summary>
    /// Log
    /// </summary>
    public class DelegateLogAttribute : AbstractMethodAttribute
    {
        /// <summary>
        /// 前后业务
        /// </summary>
        public override ShowDelegate Do(ShowDelegate action)
        {
            ShowDelegate actionResult = new ShowDelegate(() =>
            {
                Console.WriteLine("在执行之前LOG");
                action.Invoke();
                Console.WriteLine("在执行之后LOG");
            });
            return actionResult;
        }
    }

    /// <summary>
    /// Error
    /// </summary>
    public class DelegateErrorAttribute : AbstractMethodAttribute
    {
        /// <summary>
        /// 前后业务
        /// </summary>
        public override ShowDelegate Do(ShowDelegate action)
        {
            ShowDelegate actionResult = new ShowDelegate(() =>
            {
                Console.WriteLine("在执行之前ERROR");
                action.Invoke();
                Console.WriteLine("在执行之后ERROR");
            });
            return actionResult;
        }
    }

    /// <summary>
    /// Auth
    /// </summary>
    public class DelegateAuthAttribute : AbstractMethodAttribute
    {
        /// <summary>
        /// 前后业务
        /// </summary>
        public override ShowDelegate Do(ShowDelegate action)
        {
            ShowDelegate actionResult = new ShowDelegate(() =>
            {
                Console.WriteLine("在执行之前AUTH");
                action.Invoke();
                Console.WriteLine("在执行之后AUTH");
            });
            return actionResult;
        }
    }
}
