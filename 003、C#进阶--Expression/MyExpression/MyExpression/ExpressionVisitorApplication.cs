using System;
using System.Linq.Expressions;

namespace MyExpression
{
    public class ExpressionVisitorApplication
    {
        public static void Show()
        {
            //五、ExpressionVisitor应用
            //需求：实现ORM框架Expression映射成sql
            //自定义一个ConditionBuilderVisitor，继承自ExpressionVisitor，复写父类的方法，Expression解析过程中实现sql的拼接
            //ConstantSqlString泛型缓存缓存生成的sql
            {
                //普通多条件
                Expression<Func<People, bool>> lambda = x => x.Age > 5
                                                             && x.Id > 5
                                                             && x.Name.StartsWith("1") //  like '1%'
                                                             && x.Name.EndsWith("1") //  like '%1'
                                                             && x.Name.Contains("1");//  like '%1%' 
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                string sql = ConstantSqlString<People>.GetQuerySql(vistor.Condition());
                Console.WriteLine(sql);
            }
            {
                //外部参数变量
                string name = "AAA";
                Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Name == name || x.Id > 5;
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                string sql = ConstantSqlString<People>.GetQuerySql(vistor.Condition());
                Console.WriteLine(sql);
            }
            {
                //内部常量多条件
                Expression<Func<People, bool>> lambda = x => x.Age > 5 || (x.Name == "A" && x.Id > 5);
                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                string sql = ConstantSqlString<People>.GetQuerySql(vistor.Condition());
                Console.WriteLine(sql);
            }
        }
    }
}
