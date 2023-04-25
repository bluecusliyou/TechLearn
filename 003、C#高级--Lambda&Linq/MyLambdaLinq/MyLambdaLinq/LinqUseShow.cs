using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLambdaLinq
{
    public class LinqUseShow
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

        private List<Class> GetClassList()
        {
            #region 初始化数据
            List<Class> classList = new List<Class>()
                {
                    new Class()
                    {
                        Id=1,
                        ClassName="数学"
                    },
                    new Class()
                    {
                        Id=2,
                        ClassName="语文"
                    },
                    new Class()
                    {
                        Id=3,
                        ClassName="英语"
                    },
                };
            #endregion

            return classList;
        }
        #endregion

        /// <summary>
        /// 五、Linq语句使用
        /// </summary>
        public void Show()
        {
            //1、在使用LINQ写查询时可以使用两种形式的语法
            //（1）查询语法
            //使用标准的方法调用，这些方法是一组叫做标准查询运算符的方法
            //（2）方法语法
            //看上去和SQL语句很相似，使用查询表达式形式书写。微软推荐使用查询语法，因为它更易读
            //在编译时，CLR会将查询语法转换为方法语法
            {
                int[] num = { 2, 4, 6, 8, 10 };
                var numQuery = from number in num //查询语法
                               where number < 8
                               select number;
                var numMethod = num.Where(x => x < 8); //方法语法
            }
            //2、Linq的延迟计算
            //一般步骤：获取数据源、创建查询、执行查询。
            //尽管查询在语句中定义，但直到最后的foreach语句请求其结果的时候才会执行
            {
                int[] number = { 2, 4, 6, 8, 10 }; //获取数据源
                IEnumerable<int> lowNum = from n in number //创建并存储查询，不会执行操作
                                          where n < 8
                                          select n;
                foreach (var val in lowNum) //执行查询
                {
                    Console.Write("{0} ", val);
                }
            }
            //3、Linq方法语法详解
            //查询表达式由查询体后的from子句组成，其子句必须按一定的顺序出现，并且from子句和select子句这两部分是必须的。
            //（1）from
            //from子句指定了要作为数据源使用的数据集合

            List<Student> studentList = this.GetStudentList();
            //（2）Select
            //投影：可以做一些自由组装new一个匿名类，也可以new具体类
            //select子句指定所选定的对象哪部分应该被选择。可以指定下面的任意一项a.整个数据项 b.数据项的一个字段c.数据项中几个字段组成的新对象
            {
                Console.WriteLine("*************Select****************");
                {
                    //a.整个数据项
                    var lista = studentList.Where<Student>(s => s.Age < 30)
                                         .Select(s => s);
                    //b.数据项的一个字段
                    var listb = studentList.Where<Student>(s => s.Age < 30)
                                         .Select(s => s.Age);
                    //c.数据项中几个字段组成的新对象
                    var listc = studentList.Where<Student>(s => s.Age < 30)
                                         .Select(s => new
                                         {
                                             Age = s.Age,
                                             ClassId = s.ClassId
                                         });

                    var list = studentList.Where<Student>(s => s.Age < 30)
                                         .Select(s => new
                                         {
                                             IdName = s.Id + s.Name,
                                             ClassName = s.ClassId == 2 ? "数学" : "英语"
                                         });
                    foreach (var item in list)
                    {
                        Console.WriteLine("Name={0}  Age={1}", item.ClassName, item.IdName);
                    }
                }
                Console.WriteLine("*************Select****************");
                {
                    //a.整个数据项
                    var lista = from s in studentList
                                select s;
                    //b.数据项的一个字段
                    var listb = from s in studentList
                                select s.Age;
                    //c.数据项中几个字段组成的新对象
                    var listc = from s in studentList
                                select new
                                {
                                    Age = s.Age,
                                    ClassId = s.ClassId
                                };

                    var list = from s in studentList
                               where s.Age < 30
                               select new
                               {
                                   IdName = s.Id + s.Name,
                                   ClassName = s.ClassId == 2 ? "数学" : "英语"
                               };

                    foreach (var item in list)
                    {
                        Console.WriteLine("Name={0}  Age={1}", item.ClassName, item.IdName);
                    }
                }
                Console.WriteLine("*************Select****************");
            }

            //（3）Where
            //条件筛选，where子句根据之后的运算来除去不符合要求的项，一个查询表达式可以有任意多个where子句，一个项必须满足所有的where条件才能避免被过滤
            {
                Console.WriteLine("*************Where****************");
                {
                    IEnumerable<Student> list = studentList.Where<Student>(s => s.Age < 30 && s.ClassId == 2);
                    foreach (var item in list)
                    {
                        Console.WriteLine("Name={0}  Age={1}", item.Name, item.Age);
                    }
                }
                Console.WriteLine("*************Where****************");
                {
                    IEnumerable<Student> list = from s in studentList
                                                where s.Age < 30
                                                where s.ClassId == 2
                                                select s;
                    foreach (var item in list)
                    {
                        Console.WriteLine("Name={0}  Age={1}", item.Name, item.Age);
                    }
                }
                Console.WriteLine("*************Where****************");
            }

            //（4）OrderBy，ThenBy，OrderByDescending
            //OrderBy排序，ThenBy再排序，OrderByDescending倒序排序
            {
                Console.WriteLine("*************OrderBy，ThenBy，OrderByDescending****************");
                {
                    var list = studentList.Where<Student>(s => s.Age < 30)
                                           .Select(s => new
                                           {
                                               Id = s.Id,
                                               ClassId = s.ClassId,
                                               IdName = s.Id + s.Name,
                                               ClassName = s.ClassId == 2 ? "数学" : "英语"
                                           })
                                           .OrderBy(s => s.Id)//排序 升序
                                           .ThenBy(s => s.ClassName) //多重排序，可以多个字段排序都生效
                                           .OrderByDescending(s => s.ClassId)//倒排
                                           ;
                    foreach (var item in list)
                    {
                        Console.WriteLine($"Id={item.Id}  ClassName={item.ClassName}  ClassId={item.ClassId}");
                    }
                }
                Console.WriteLine("*************OrderBy，ThenBy，OrderByDescending****************");
                {
                    var list = from s in studentList
                               where s.Age < 30
                               orderby s.Id, s.ClassId
                               orderby s.ClassId descending
                               select new
                               {
                                   Id = s.Id,
                                   ClassId = s.ClassId,
                                   IdName = s.Id + s.Name,
                                   ClassName = s.ClassId == 2 ? "数学" : "英语"
                               };
                    foreach (var item in list)
                    {
                        Console.WriteLine($"Id={item.Id}  ClassName={item.ClassName}  ClassId={item.ClassId}");
                    }
                }
                Console.WriteLine("*************OrderBy，ThenBy，OrderByDescending****************");
            }

            //（5）into
            //查询延续：查询延续子句可以接受查询的一部分结构并赋予一个名字，从而可以在查询的另一部分中使用

            //（6）GroupBy
            //分组，和into一起使用，分组数据可以Max，Min，Average，Sum，Count
            //这里，Key其实质是一个类的对象
            //group by 可以一个表达式，返回按照表达式区分的两个组
            {
                Console.WriteLine("*************GroupBy****************");
                {
                    var list = studentList.GroupBy(s => s.ClassId)
                                          .Select(sg => new
                                          {
                                              key = sg.Key,
                                              maxAge = sg.Max(t => t.Age),
                                              minAge = sg.Min(t => t.Age),
                                              avAge = sg.Average(t => t.Age),
                                              sumAge = sg.Sum(t => t.Age),
                                              ct = sg.Count()
                                          });
                    foreach (var item in list)
                    {
                        Console.WriteLine($"key={item.key}  maxAge={item.maxAge}");
                    }
                }
                Console.WriteLine("*************GroupBy****************");
                {
                    var list = from s in studentList
                               group s by s.ClassId into sg
                               //group s by new { xx=s.ClassId >1} into sg//Linq使用Group By返回两个序列。第一个序列包含ClassId >1的。第二个序列包含ClassId<=1的。
                               select new
                               {
                                   key = sg.Key,//key是student对象
                                   maxAge = sg.Max(t => t.Age),
                                   minAge = sg.Min(t => t.Age),
                                   avAge = sg.Average(t => t.Age),
                                   sumAge = sg.Sum(t => t.Age),
                                   ct = sg.Count()
                               };
                    foreach (var item in list)
                    {
                        Console.WriteLine($"key={item.key}  maxAge={item.maxAge}");
                    }
                }
                Console.WriteLine("*************GroupBy****************");
            }

            var classList = GetClassList();
            //（7）Join
            //可以使用join来结合两个或更多集合中的数据，它接受两个集合然后创建一个临时的对象集合
            //连接，相等只能使用equals不能使==
            {
                Console.WriteLine("*************Join****************");
                {
                    var list = studentList.Join(classList, s => s.ClassId, c => c.Id, (s, c) => new
                    {
                        Name = s.Name,
                        CalssName = c.ClassName
                    });
                    foreach (var item in list)
                    {
                        Console.WriteLine($"Name={item.Name},CalssName={item.CalssName}");
                    }
                }
                Console.WriteLine("*************Join****************");
                {
                    var list = from s in studentList
                               join c in classList on s.ClassId equals c.Id
                               select new
                               {
                                   Name = s.Name,
                                   CalssName = c.ClassName
                               };
                    foreach (var item in list)
                    {
                        Console.WriteLine($"Name={item.Name},CalssName={item.CalssName}");
                    }
                }
                Console.WriteLine("*************Join****************");
            }

            //（8）let
            //let子句接受一个表达式的运算并且把它赋值给一个需要在其他运算中使用的标识符,它是from...let...where片段中的一部分
            {
                Console.WriteLine("*************Let****************");
                {
                    var list = from s in studentList
                               join c in classList on s.ClassId equals c.Id
                               let classx= s.ClassId+s.Name
                               where classx.Length>5
                               select new
                               {
                                   Name = s.Name,
                                   CalssName = c.ClassName
                               };
                    foreach (var item in list)
                    {
                        Console.WriteLine($"Name={item.Name},CalssName={item.CalssName}");
                    }
                }
                Console.WriteLine("*************Let****************");
            }
        }
    }
}
