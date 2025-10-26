using Business.Common.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace MyExpression
{
    public class ExpressionLambda
    {
        public static void Show()
        {
            //二、Expression动态拼装
            {
                //1、最基础版本
                Expression<Func<int>> expression = () => 123 + 234;
                //常量表达式
                ConstantExpression expression1 = Expression.Constant(123);
                ConstantExpression expression2 = Expression.Constant(234);
                //二元表达式
                BinaryExpression binaryExpression = Expression.Add(expression1, expression2);
                Expression<Func<int>> expressionReslut = Expression.Lambda<Func<int>>(binaryExpression);
                Func<int> func = expressionReslut.Compile();
                int iResult = func.Invoke();
            }
            {
                //2、带参数版本
                Expression<Func<int, int>> expression1 = m => m + 1;
                Func<int, int> func = expression1.Compile();
                int iResult = func.Invoke(5);
                //参数表达式
                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
                //常量表达式
                ConstantExpression constant = Expression.Constant(1, typeof(int));
                //二元表达式
                BinaryExpression addExpression = Expression.Add(parameterExpression, constant);
                Expression<Func<int, int>> expression = Expression.Lambda<Func<int, int>>(addExpression, new ParameterExpression[1]
                {
                      parameterExpression
                });
                Func<int, int> func1 = expression.Compile();
                int iResult1 = func1.Invoke(5);
            }
            {
                //3、带有多个参数
                Expression<Func<int, int, int>> expression = (m, n) => m * n + 2;
                Func<int, int, int> func = expression.Compile();
                int iResult = func.Invoke(10, 20);
                //参数表达式
                ParameterExpression parameterExpressionM = Expression.Parameter(typeof(int), "m");
                ParameterExpression parameterExpressionN = Expression.Parameter(typeof(int), "n");
                //二元表达式
                BinaryExpression multiply = Expression.Multiply(parameterExpressionM, parameterExpressionN);
                //常量表达式
                ConstantExpression constantExpression = Expression.Constant(2);
                //二元表达式
                BinaryExpression plus = Expression.Add(multiply, constantExpression);
                Expression<Func<int, int, int>> expression1 = Expression.Lambda<Func<int, int, int>>(plus, new ParameterExpression[2]
                {
                      parameterExpressionM,
                      parameterExpressionN
                });
                Func<int, int, int> func1 = expression1.Compile();
                int iResult1 = func1.Invoke(10, 20);
            }
            {
                //4、对象字段值比较
                //类似于这种比较复杂的，建议大家可以反编译看看
                Expression<Func<People, bool>> predicate = c => c.Id == 10;
                Func<People, bool> func = predicate.Compile();
                bool bResult = func.Invoke(new People()
                {
                    Id = 10
                });

                //参数表达式
                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "c");
                //反射获取属性
                FieldInfo fieldId = typeof(People).GetField("Id");
                //通过parameterExpression来获取调用Id
                MemberExpression idExp = Expression.Field(parameterExpression, fieldId);
                //常量表达式
                ConstantExpression constant10 = Expression.Constant(10, typeof(int));
                //二元表达式
                BinaryExpression expressionExp = Expression.Equal(idExp, constant10);
                Expression<Func<People, bool>> predicate1 = Expression.Lambda<Func<People, bool>>(expressionExp, new ParameterExpression[1]
                {
                            parameterExpression
                });

                Func<People, bool> func1 = predicate1.Compile();
                bool bResult1 = func1.Invoke(new People()
                {
                    Id = 10
                });
            }
            {
                //5、多条件
                //如果遇到很长的表达式目录树，拼装建议从右往左拼装
                Expression<Func<People, bool>> predicate = c =>
                    c.Id.ToString() == "10"
                    && c.Name.Equals("张三")
                    && c.Age > 35;
                Func<People, bool> func = predicate.Compile();
                bool bResult = func.Invoke(new People()
                {
                    Id = 10,
                    Name = "张三",
                    Age = 36
                });

                ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "c");
                //c.Age > 35
                ConstantExpression constant35 = Expression.Constant(35);
                PropertyInfo propAge = typeof(People).GetProperty("Age");
                MemberExpression ageExp = Expression.Property(parameterExpression, propAge);
                BinaryExpression cagExp = Expression.GreaterThan(ageExp, constant35);
                //c.Name.Equals("张三")
                ConstantExpression constantrichard = Expression.Constant("张三");
                PropertyInfo propName = typeof(People).GetProperty("Name");
                MemberExpression nameExp = Expression.Property(parameterExpression, propName);
                MethodInfo equals = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });
                MethodCallExpression NameExp = Expression.Call(nameExp, equals, constantrichard);
                //c.Id.ToString() == "10"
                ConstantExpression constantExpression10 = Expression.Constant("10", typeof(string));
                FieldInfo fieldId = typeof(People).GetField("Id");
                var idExp = Expression.Field(parameterExpression, fieldId);
                MethodInfo toString = typeof(int).GetMethod("ToString", new Type[0]);
                var toStringExp = Expression.Call(idExp, toString, Array.Empty<Expression>());
                var EqualExp = Expression.Equal(toStringExp, constantExpression10);
                //c.Id.ToString() == "10"&& c.Name.Equals("张三")&& c.Age > 35
                var plus = Expression.AndAlso(EqualExp, NameExp);
                var exp = Expression.AndAlso(plus, cagExp);
                Expression<Func<People, bool>> predicate1 = Expression.Lambda<Func<People, bool>>(exp, new ParameterExpression[1]
                {
                     parameterExpression
                });
                Func<People, bool> func1 = predicate1.Compile();
                bool bResult1 = func1.Invoke(new People()
                {
                    Id = 10,
                    Name = "张三",
                    Age = 36
                });
            }
        }
    }
}
