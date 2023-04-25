using Business.DB.Interface;
using Business.DB.Model;
using System;
using System.Data.SqlClient;

namespace Business.DB.SqlServer
{
    public class SqlServerHelper : IDBHelper
    {

        //Nuget:System.Data.SqlClient

        private string ConnectionString = "Data Source=XXX; Database=YYY; User ID=sa; Password=ZZZ; MultipleActiveResultSets=True";

        public SqlServerHelper()
        {
           //Console.WriteLine($"{this.GetType().Name}被构造");
        }
        

        public void Query()
        {
            //Console.WriteLine($"{this.GetType().Name}.Query");
        }

        /// <summary> 
        /// 泛型方法适配查询不同对象数据
        /// </summary>
        public T Find<T>(int id) where T : BaseModel
        {
            //（1）反射创建对象
            Type type = typeof(T);
            object oReulst = Activator.CreateInstance(type);

            //（2）连接数据库,数据库链接字符串ConnectionString 
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //（3）准备SqlConnection，使用数据库链接字符串
                connection.Open();
                
                //（4）准备sql，通过泛型缓存缓存sql
                string sql = ConstantSqlString<T>.GetFindSql(id);
                //（5）准备SqlCommand
                //（6）通过SqlCommand对象执行Sql语句
                SqlCommand sqlCommand = new SqlCommand(sql, connection);
                //（7）开始获取数据
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    foreach (var prop in type.GetProperties())
                    {
                        //（8）反射赋值
                        prop.SetValue(oReulst, reader[prop.Name] is DBNull ? null : reader[prop.Name]);
                    }
                }
            }
            return (T)oReulst;
        }
    }
}
