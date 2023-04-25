using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLambdaLinq
{
    /// <summary>
    /// 静态类
    /// </summary>
    public static class MethodExtension3
    {
        /// <summary>
        /// 泛型扩展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldlist"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static List<T> CustomWhere<T>(this List<T> oldlist, Func<T, bool> func)
        {
            List<T> newlist = new List<T>();
            foreach (var item in oldlist)
            {                
                if (func.Invoke(item))
                {
                    newlist.Add(item);
                }
            }
            return newlist;
        }        

        ////来自于Linq的Where实现
        //public static IEnumerable<TSource> Where<TSource>(IEnumerable<TSource> source, Func<TSource, bool> predicate)
        //{
        //    if (source == null)
        //    {
        //        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
        //    }
        //    if (predicate == null)
        //    {
        //        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.predicate);
        //    }
        //    Iterator<TSource> iterator = source as Iterator<TSource>;
        //    if (iterator != null)
        //    {
        //        return iterator.Where(predicate);
        //    }
        //    TSource[] array = source as TSource[];
        //    if (array != null)
        //    {
        //        if (array.Length != 0)
        //        {
        //            return new WhereArrayIterator<TSource>(array, predicate);
        //        }
        //        return Empty<TSource>();
        //    }
        //    List<TSource> list = source as List<TSource>;
        //    if (list != null)
        //    {
        //        return new WhereListIterator<TSource>(list, predicate);
        //    }
        //    return new WhereEnumerableIterator<TSource>(source, predicate);
        //}
    }

    public class LinqShow
    {
        #region Data Init
        private List<Student> GetStudentList()
        {
            #region 初始化数据
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="赵亮",
                    ClassId=2,
                    Age=35
                },
                new Student()
                {
                    Id=1,
                    Name="再努力一点",
                    ClassId=2,
                    Age=23
                },
                 new Student()
                {
                    Id=1,
                    Name="王炸",
                    ClassId=2,
                    Age=27
                },
                 new Student()
                {
                    Id=1,
                    Name="疯子科学家",
                    ClassId=2,
                    Age=26
                },
                new Student()
                {
                    Id=1,
                    Name="灭",
                    ClassId=2,
                    Age=25
                },
                new Student()
                {
                    Id=1,
                    Name="黑骑士",
                    ClassId=2,
                    Age=24
                },
                new Student()
                {
                    Id=1,
                    Name="故乡的风",
                    ClassId=2,
                    Age=21
                },
                 new Student()
                {
                    Id=1,
                    Name="晴天",
                    ClassId=2,
                    Age=22
                },
                 new Student()
                {
                    Id=1,
                    Name="旭光",
                    ClassId=2,
                    Age=34
                },
                 new Student()
                {
                    Id=1,
                    Name="oldkwok",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="乐儿",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="暴风轻语",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="一个人的孤单",
                    ClassId=2,
                    Age=28
                },
                new Student()
                {
                    Id=1,
                    Name="小张",
                    ClassId=2,
                    Age=30
                },
                 new Student()
                {
                    Id=3,
                    Name="阿亮",
                    ClassId=3,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="37度",
                    ClassId=4,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="关耳",
                    ClassId=4,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="耳机侠",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="Wheat",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="Heaven",
                    ClassId=4,
                    Age=22
                },
                  new Student()
                {
                    Id=4,
                    Name="等待你的微笑",
                    ClassId=4,
                    Age=23
                },
                  new Student()
                {
                    Id=4,
                    Name="畅",
                    ClassId=4,
                    Age=25
                },
                  new Student()
                {
                    Id=4,
                    Name="混无痕",
                    ClassId=4,
                    Age=26
                },
                  new Student()
                {
                    Id=4,
                    Name="37度",
                    ClassId=4,
                    Age=28
                },
                  new Student()
                {
                    Id=4,
                    Name="新的世界",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="Rui",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="帆",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="肩膀",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="孤独的根号三",
                    ClassId=4,
                    Age=30
                }
            };
            #endregion

            return studentList;
        }
        #endregion

        public void Show()
        {
            //2、Linq的原理
            //需求：存在一个集合，要过滤其中的数据
            //（1）方案1：循环+判断
            {
                Console.WriteLine("************************方案1：循环+判断*************************");
                //要求查询Student中年龄小于30的； 
                List<Student> studentList = this.GetStudentList();
                List<Student> list = new List<Student>();
                foreach (var item in studentList)
                {
                    if (item.Age < 30)
                    {
                        list.Add(item);
                    }
                }
                //要求Student名称长度大于2
                List<Student> list2 = new List<Student>();
                foreach (var item in studentList)
                {
                    if (item.Name.Length > 2)
                    {
                        list2.Add(item);
                    }
                }
                //N个条件叠加
                List<Student> list3 = new List<Student>();
                foreach (var item in studentList)
                {
                    if (item.Id > 1
                        && item.Name != null
                        && item.ClassId == 1
                        && item.Age > 20)
                    {
                        list.Add(item);
                    }
                }
                Console.WriteLine("************************方案1：循环+判断*************************");
            }

            //（2）方案2：扩展方法 + Lambda
            //可以把不变的业务逻辑保留，把可变的，不固定的业务逻辑转移出去，就可以用委托包装一个方法传递过来，简化重复代码
            {
                Console.WriteLine("************************方案2：扩展方法+判断作为参数传入*************************");
                //要求查询Student中年龄小于30的； 
                List<Student> studentList = this.GetStudentList();
                List<Student> list = studentList.CustomWhere(item => item.Age < 30);
                //要求Student名称长度大于2
                List<Student> list2 = studentList.CustomWhere(item => item.Name.Length > 2);
                //N个条件叠加
                List<Student> list3 = studentList.CustomWhere(item => item.Id > 1
                        && item.Name != null
                        && item.ClassId == 1
                        && item.Age > 20);
                Console.WriteLine("************************方案2：扩展方法+判断作为参数传入*************************");
            }

            //（3）方案3：Linq中的Where
            //Linq的底层都是通过迭代器来实现就是支持循环，实现原理和我们自己写的扩展方法类似
            //Linq的底层使用IEnumerable来承接数据
            {
                Console.WriteLine("************************方案3：Linq中的Where*************************");
                //要求查询Student中年龄小于30的； 
                List<Student> studentList = this.GetStudentList();
                List<Student> list = studentList.Where(item => item.Age < 30).ToList();
                //要求Student名称长度大于2
                List<Student> list2 = studentList.Where(item => item.Name.Length > 2).ToList();
                //N个条件叠加
                List<Student> list3 = studentList.Where(item => item.Id > 1
                        && item.Name != null
                        && item.ClassId == 1
                        && item.Age > 20).ToList();
                Console.WriteLine("************************方案3：Linq中的Where*************************");
            }
        }
    }
}
