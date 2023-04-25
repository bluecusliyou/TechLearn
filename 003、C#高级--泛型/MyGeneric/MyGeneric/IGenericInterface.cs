namespace MyGeneric
{
    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericInterface<T>
    {
        //泛型类型的返回值
        T GetT(T t);
    }
}
