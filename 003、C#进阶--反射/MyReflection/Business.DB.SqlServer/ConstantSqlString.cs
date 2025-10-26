using System;
using System.Linq;

namespace Business.DB.SqlServer
{
    public class ConstantSqlString<T>
    {
        private static string FindSql = null;

        static ConstantSqlString()
        {
            Type type = typeof(T);
            FindSql = $"Select {string.Join(',', type.GetProperties().Select(c => $"[{c.Name}]").ToList())} from {type.Name} where id=";
        }

        /// <summary>
        /// GetSql语句
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string GetFindSql(int id)
        {
            return $"{FindSql}{id}";
        }
    }
}
