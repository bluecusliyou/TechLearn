using System;
using System.Linq.Expressions;

namespace MyExpression
{
    /// <summary>
    /// 展示表达式树，反编译用
    /// </summary>
    public class ExpressionTreeVisualizer
    {
        public static void Show()
        {
            Expression<Func<People, bool>> predicate = c => c.Id.ToString() == "10" && c.Name.Equals("张三") && c.Age > 35;
        }
    }
}
