using System.Linq.Expressions;

namespace MyExpression
{
    /// <summary>
    /// 自定义Visitor
    /// </summary>
    public class OperationsVisitor : ExpressionVisitor
    {
        /// <summary>
        /// 覆写父类方法；//二元表达式的访问
        /// 把表达式目录树中相加改成相减，相乘改成相除
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression b)
        { 
            if (b.NodeType == ExpressionType.Add)//相加
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);
                return Expression.Subtract(left, right);//相减
            }
            else if (b.NodeType==ExpressionType.Multiply) //相乘
            {
                Expression left = this.Visit(b.Left);
                Expression right = this.Visit(b.Right);
                return Expression.Divide(left, right); //相除
            } 
            return base.VisitBinary(b);
        }
    }
}
