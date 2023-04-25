using System;

namespace MyExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //一、Expression是什么
                //1、如何定义
                //Expression<Func<TSource, bool>>就是表达式目录树
                //Expression不能带有大括号，只能有一行代码
                //2、和委托的区别
                //在委托外面包裹一层Expression<>就是表达式目录树
                //表达式目录树可以通过Compile()转换成一个委托
                //3、Expression本质
                //表达式目录树是一个类的封装，描述了一个结构，有身体部分和参数部分
                //身体部分分为左边和右边，内部描述了左边和右边之间的关系，可以不断的往下拆分，类似于二叉树
                //表达式目录树展开后的每一个节点也是一个表达式目录树
                ExpressionDefinition.Show();

                //二、Expression动态拼装
                //1、最基础版本
                //2、带参数版本
                //3、带有多个参数
                //4、对象字段值比较
                //类似于这种比较复杂的，建议大家可以反编译看看
                //5、多条件
                //如果遇到很长的表达式目录树，拼装建议从右往左拼装
                ExpressionLambda.Show();

                //三、Expression应用之Mapper映射
                //需求：需要把People字段值映射到PeopleCopy字段
                //1、硬编码
                //性能好，不灵活；不能共用                
                //2、反射
                //灵活，但是性能不好
                //3、序列化
                //灵活，但是性能不好
                //4、Expression动态拼接+普通缓存
                //把People变成PeopleCopy的过程封装在一个委托中，这个委托通过表达式目录树Compile出来，过程动态拼装适应不同的类型
                //第一次生成的时候，保存一个委托在缓存中，如果第二次来，委托就可以直接从缓存中获取到，直接运行委托，效率高
                //5、Expression动态拼接+泛型缓存
                //泛型缓存，就是为为每一组类型的组合，生成一个副本，性能最高
                //6、性能比较
                //Expression动态拼接+泛型缓存性能高，而且灵活
                ExpressionApplication.Show();

                //四、ExpressionVisitor解析Expression
                //1、Expression解析
                //Expression是通过访问者模式进行解析的，官方提供了ExpressionVisitor抽象类
                //ExpressionVisitor的Visit方法是解析表达式目录树的一个入口，Visit方法判断Expression是一个什么表达式目录树，走不同的细分方法进行进一步解析
                //ExpressionVisitor的VisitBinary方法是对二员表达式的解析，所有复杂的表达式都会拆解成二员表达式进行解析
                //2、Expression修改
                //自定义一个OperationsVisitor，继承自ExpressionVisitor，复写父类的VisitBinary方法，修改Expression的解析
                //可以自定义解析的过程，对动态解析的过程进行编程
                //3、封装多条件连接扩展方法
                ExpressionVisitorTest.Show();

                //五、ExpressionVisitor应用
                //需求：实现ORM框架Expression映射成sql
                //自定义一个ConditionBuilderVisitor
                //继承自ExpressionVisitor，复写父类的方法，Expression解析过程中实现sql的拼接
                //ConstantSqlString泛型缓存缓存生成的sql
                //（1）普通多条件
                //（2）外部参数变量
                //（3）内部常量多条件
                ExpressionVisitorApplication.Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
