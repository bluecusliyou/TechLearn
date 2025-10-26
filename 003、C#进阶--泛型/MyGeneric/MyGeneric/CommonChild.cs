using System;

namespace MyGeneric
{
    /// <summary>
    /// 可以不知道具体类型，但是子类也必须是泛型的
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonChild<T> : IGenericInterface<T>
    {
        public T GetT(T t)
        {
            throw new NotImplementedException();
        }
    }
}
