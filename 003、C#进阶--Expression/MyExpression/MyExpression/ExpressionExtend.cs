using System;
using System.Linq.Expressions;

namespace Business.Common.Extend
{
    internal class NewExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression _NewParameter { get; private set; }
        public NewExpressionVisitor(ParameterExpression param)
        {
            this._NewParameter = param;
        }
        
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this._NewParameter;
        }
    }

    /// <summary>
    /// 合并表达式 And Or Not扩展方法
    /// </summary>
    public static class ExpressionExtend
    {
        /// <summary>
        /// 合并表达式 expr1 AND expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null || expr2 == null)
            {
                throw new Exception("null不能处理");
            }
            ParameterExpression newParameter = Expression.Parameter(typeof(T), "x");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);
            Expression left = visitor.Visit(expr1.Body);
            Expression right = visitor.Visit(expr2.Body);
            BinaryExpression body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }

        /// <summary>
        /// 合并表达式 expr1 or expr2
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr1"></param>
        /// <param name="expr2"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null || expr2 == null)
            {
                throw new Exception("null不能处理");
            }
            ParameterExpression newParameter = Expression.Parameter(typeof(T), "x");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);
            Expression left = visitor.Visit(expr1.Body);
            Expression right = visitor.Visit(expr2.Body);
            BinaryExpression body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }

        /// <summary>
        /// 表达式取非
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expr)
        {
            if (expr == null)
            {
                throw new Exception("null不能处理");
            }
            ParameterExpression newParameter = expr.Parameters[0];
            UnaryExpression body = Expression.Not(expr.Body);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }
    }
}
