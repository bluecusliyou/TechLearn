using System;
using System.Linq.Expressions;

namespace MyExpression
{
    public class ExpressionDefinition
    {
        public static void Show()
        {            
            Expression<Func<People, bool>> expression = p => p.Id == 10;
            Func<People, bool> func = expression.Compile();
            bool bResult = func.Invoke(new People()
            {
                Id = 10,
                Name = "张三"
            });
        }
    }
}
