namespace MyGeneric
{
    /// <summary>
    /// 子类也是泛型的，继承的时候可以不指定具体类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CommonClassChild<T> : GenericClass<T>
    {
    }
}
