using System;
using System.Linq;

namespace MyExpression
{
    public class ConstantSqlString<T>
    {
        /// <summary>
        /// 泛型缓存，一个类型一个缓存
        /// </summary>
        private static string FindSql = null;

        /// <summary>
        /// 获取查询sql
        /// </summary>
        static ConstantSqlString()
        {
            Type type = typeof(T);
            FindSql = $"Select {string.Join(',', type.GetProperties().Select(c => $"[{c.Name}]").ToList())} from {type.Name}";
        }

        /// <summary>
        /// 获取查询sql+条件筛选
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string GetQuerySql(string exp)
        {
            return $"{FindSql} where {exp}";
        }
    }
}
