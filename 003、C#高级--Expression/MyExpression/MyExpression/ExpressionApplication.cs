using MyExpression.MappingExtend;
using System;
using System.Diagnostics;

namespace MyExpression
{
    public class ExpressionApplication
    {
        public static void Show()
        {
            //三、Expression应用
            //需求：需要把People字段值映射到PeopleCopy字段
            People people = new People()
            {
                Id = 11,
                Name = "剑锋",
                Age = 31
            };

            //1、硬编码
            //性能好，不灵活；不能共用
            PeopleCopy peopleCopy0 = new PeopleCopy()
            {
                Id = people.Id,
                Name = people.Name,
                Age = people.Age
            };

            //2、反射
            //灵活，但是性能不好
            PeopleCopy peopleCopy1 = ReflectionMapper.Trans<People, PeopleCopy>(people);

            //3、序列化
            //灵活，但是性能不好
            PeopleCopy peopleCopy2 = SerializeMapper.Trans<People, PeopleCopy>(people);

            //4、Expression动态拼接+普通缓存
            //把People变成PeopleCopy的过程封装在一个委托中，这个委托通过表达式目录树Compile出来，过程动态拼装适应不同的类型
            //第一次生成的时候，保存一个委托在缓存中，如果第二次来，委托就可以直接从缓存中获取到，直接运行委托，效率高
            PeopleCopy peopleCopy3 = ExpressionMapper.Trans<People, PeopleCopy>(people);

            //5、Expression动态拼接+泛型缓存
            //泛型缓存，就是为为每一组类型的组合，生成一个副本，性能最高
            PeopleCopy peopleCopy4 = ExpressionGenericMapper<People, PeopleCopy>.Trans(people);

            //6、性能比较
            //Expression动态拼接+泛型缓存性能高，而且灵活
            long common = 0;
            long generic = 0;
            long cache = 0;
            long reflection = 0;
            long serialize = 0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = new PeopleCopy()
                    {
                        Id = people.Id,
                        Name = people.Name,
                        Age = people.Age
                    };
                }
                watch.Stop();
                common = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = ReflectionMapper.Trans<People, PeopleCopy>(people);
                }
                watch.Stop();
                reflection = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = SerializeMapper.Trans<People, PeopleCopy>(people);
                }
                watch.Stop();
                serialize = watch.ElapsedMilliseconds;
            }
            {

                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = ExpressionMapper.Trans<People, PeopleCopy>(people);
                }
                watch.Stop();
                cache = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = ExpressionGenericMapper<People, PeopleCopy>.Trans(people);
                }
                watch.Stop();
                generic = watch.ElapsedMilliseconds;
            }

            Console.WriteLine($"common = { common} ms");
            Console.WriteLine($"reflection = { reflection} ms");
            Console.WriteLine($"serialize = { serialize} ms");
            Console.WriteLine($"cache = { cache} ms");
            Console.WriteLine($"generic = { generic} ms");
        }
    }
}
