using Newtonsoft.Json;

namespace MyExpression.MappingExtend
{
    public class SerializeMapper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            string strJson = JsonConvert.SerializeObject(tIn); 
            return JsonConvert.DeserializeObject<TOut>(strJson);
        }
    }
}
