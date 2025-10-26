using Business.Common.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyExpression
{
    public class ExpressionVisitorTest
    {
        public static void Show()
        {
            //四、ExpressionVisitor解析Expression
            //1、Expression解析
            //Expression是通过访问者模式进行解析的，官方提供了ExpressionVisitor抽象类
            //ExpressionVisitor的Visit方法是解析表达式目录树的一个入口，Visit方法判断Expression是一个什么表达式目录树，走不同的细分方法进行进一步解析
            //ExpressionVisitor的VisitBinary方法是对二员表达式的解析，所有复杂的表达式都会拆解成二员表达式进行解析
            //2、Expression修改
            //自定义一个OperationsVisitor，继承自ExpressionVisitor，复写父类的VisitBinary方法，修改Expression的解析
            //可以自定义解析的过程，对动态解析的过程进行编程
            Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;
            Console.WriteLine(exp.ToString());
            OperationsVisitor visitor = new OperationsVisitor();
            Expression expNew = visitor.Visit(exp);
            Console.WriteLine(expNew.ToString());
            //3、封装多条件连接扩展方法
            Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
            Expression<Func<People, bool>> lambda2 = x => x.Id > 5;
            Expression<Func<People, bool>> lambda3 = lambda1.And(lambda2);//且
            Expression<Func<People, bool>> lambda4 = lambda1.Or(lambda2);//或
            Expression<Func<People, bool>> lambda5 = lambda1.Not();//非
            Do(lambda3);
            Do(lambda4);
            Do(lambda5);
        }

        /// <summary>
        /// 筛选数据执行
        /// </summary>
        /// <param name="func"></param>
        private static void Do(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id=4,Name="123",Age=4},
                new People(){Id=5,Name="234",Age=5},
                new People(){Id=6,Name="345",Age=6},
            };

            List<People> peopleList = people.Where(func.Compile()).ToList();
        }
    }
}
