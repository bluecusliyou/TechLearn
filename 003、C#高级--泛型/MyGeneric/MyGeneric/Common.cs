namespace MyGeneric
{
    /// <summary>
    /// 必须指定具体类型
    /// </summary>
    public class Common : IGenericInterface<string>
    {
        public string GetT(string t)
        {
            throw new System.NotImplementedException();
        }
    }
}
