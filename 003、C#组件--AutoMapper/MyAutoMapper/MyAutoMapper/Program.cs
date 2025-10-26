using AutoMapper;
using MyAutoMapper.Profiles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Reflection;

namespace MyAutoMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1、概念理解
            //AutoMapper是一个可以通过配置就可以实现对象转换的很好的工具，可以大大简化繁琐的对象转化工作。

            //2、快速开始
            {
                ////创建配置对象
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    //这里可以直接添加对象的映射关系
                //    //cfg.CreateMap<Src01, Dest01>();
                //    //或者直接将映射关系添加到Profile，再加载Profile，类似于模块化分割业务，让项目结构更加清晰
                //    cfg.AddProfile<MyFirstProfile>();//或者cfg.AddProfile(new OrganizationProfile());
                //});
                ////创建映射对象
                //var mapper = configuration.CreateMapper();//或者var mapper=new Mapper(configuration);
                ////映射动作，将对象转换成另一个对象
                //var dest = mapper.Map<Dest01>(new Src01() { Name = "zhangsan", Age = 18 });
            }

            //3、常见配置
            //（1）加载Profile配置
            {
                ////加载程序集中的配置信息
                //{
                //    var basePath = AppContext.BaseDirectory;
                //    var assemblys = Assembly.LoadFrom(Path.Combine(basePath, "MyAutoMapper.dll"));
                //    var configuration = new MapperConfiguration(cfg => cfg.AddMaps(assemblys));
                //}
                ////根据程序集名称加载程序集中的配置信息
                //{
                //    var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] { "MyAutoMapper" }));
                //}
                ////根据类型加载配置信息
                //{
                //    var configuration = new MapperConfiguration(cfg => cfg.AddMaps(new[] { typeof(MyFirstProfile) }));
                //    var mapper = configuration.CreateMapper();
                //    var dest = mapper.Map<Dest01>(new Src01() { Name = "zhangsan", Age = 18 });
                //}
            }
            //（2）兼容不同的命名方式 camelCase/PascalCase等
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    //在全局生效
                //    cfg.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                //    cfg.DestinationMemberNamingConvention = new PascalCaseNamingConvention();

                //    cfg.AddProfile<MyFirstProfile>();
                //});
            }
            //（3）映射时替换字符串
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.ReplaceMemberName("Src", "Dest");
                //    cfg.CreateMap<Src02, Dest02>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest02>(new Src02() { NameSrc = "zhangsan" });
            }
            //（4）映射时匹配前缀或后缀
            //RecognizePrefixes匹配前缀，RecognizePostfixes匹配后缀
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.RecognizePrefixes("before");//前缀
                //    cfg.RecognizePostfixes("after");//后缀
                //    cfg.CreateMap<Src03,Dest03>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest03>(new Src03() { Nameafter = "zhangsan", beforeAge = 18 });
            }

            //（5）控制映射字段和属性范围
            {
                //var configuration = new MapperConfiguration(cfg => {
                //    cfg.ShouldMapField = fi => false;
                //    cfg.ShouldMapProperty = pi => pi.GetMethod != null && (pi.GetMethod.IsPublic || pi.GetMethod.IsPrivate);
                //});
            }

            //（6）提前编译
            //默认是调用的时候才编译映射，但是可以要求AutoMapper提前编译，但是可能会花费点时间
            {
                //var configuration = new MapperConfiguration(cfg => { });
                //configuration.CompileMappings();
            }

            //4、映射初级
            //（1）自动映射集合
            //类型映射配置之后，集合的映射就自动完成了
            //（2）字段相同的会自动映射
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Src01,Dest01>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest01>(new Src01() { Name = "zhangsan", Age = 18 });
            }
            //（3）字段不同要手动配置映射
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Src02, Dest02>()
                //    .ForMember(dest => dest.NameDest, opt => opt.MapFrom(src => src.NameSrc));
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest02>(new Src02() { NameSrc = "zhangsan" });
            }
            //（4）内部类嵌套类映射
            {
                //类内部嵌套一个类，需要将嵌套的类也进行映射
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcOuter, DestOuter>();
                //    cfg.CreateMap<SrcInner, DestInner>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestOuter>(new SrcOuter(){OutName = "zhangsan",OutAge = 18,Inner = new SrcInner() { Name = "lisi", Age = 20 }});
            }
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcOuterComplex, DestOuterComplex>()
                //    .ForMember(dest => dest.NameDest, opt => opt.MapFrom(src => src.NameSrc))
                //    .ForMember(dest => dest.AgeDest, opt => opt.MapFrom(src => src.AgeSrc))
                //    //属性类本身作为一个字段需要映射
                //    .ForMember(dest => dest.InnerDest, opt => opt.MapFrom(src => src.InnerSrc))
                //    //不能直接在容器类映射内部类的属性
                //    //.ForMember(dest => dest.InnerDest.NameDest, opt => opt.MapFrom(src => src.InnerSrc.NameSrc))
                //    ;
                //    //属性类的字段映射还是需要在属性类本身配置
                //    cfg.CreateMap<SrcInnerComplex, DestInnerComplex>()
                //    .ForMember(dest => dest.NameDest, opt => opt.MapFrom(src => src.NameSrc))
                //    .ForMember(dest => dest.AgeDest, opt => opt.MapFrom(src => src.AgeSrc));
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestOuterComplex>(new SrcOuterComplex() { NameSrc = "zhangsan", AgeSrc = 18, InnerSrc = new SrcInnerComplex() { NameSrc = "lisi", AgeSrc = 20 } });
            }
            //（5）映射继承与多态
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    ////父类映射包含子类映射Include
                //    //cfg.CreateMap<SrcParent, DestParent>()
                //    // .Include<SrcChild, DestChild>();
                //    //cfg.CreateMap<SrcChild, DestChild>();

                //    ////子类映射包含父类映射IncludeBase
                //    //cfg.CreateMap<SrcParent, DestParent>();
                //    //cfg.CreateMap<SrcChild, DestChild>()
                //    //.IncludeBase<SrcParent, DestParent>();

                //    //子类如果有多个直接包含所有IncludeAllDerived
                //    cfg.CreateMap<SrcParent, DestParent>().IncludeAllDerived();
                //    cfg.CreateMap<SrcChild, DestChild>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestChild>(new SrcChild() { Name = "zhangsan", ChildName = "zhangsanchild", Age = 35, ChildAge = 3 });
            }
            //（6）构造函数映射
            //如果dest构造函数的入参名和src的某个member一致，automapper会自动映射
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcCtor, DestCtor>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestCtor>(new SrcCtor() { Name = "zhangsan" });
            }
            //如果dest构造函数的入参名和src的某个member不一致，需要手动配置映射
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcCtor02, DestCtor02>()
                //    .ForCtorParam("destname", opt => opt.MapFrom(src => src.Name));
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestCtor02>(new SrcCtor02() { Name = "zhangsan" });
            }
            //（7）复杂类映射成扁平类
            //自动映射
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcComplex, DestSimple>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestSimple>(new SrcComplex() { Customer =new Customer() { Name= "zhangsan" }});
            }
            //手工配置映射
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcComplex02, DestSimple02>().IncludeMembers(s => s.InnerSource, s => s.InnerSource02);
                //    cfg.CreateMap<InnerSource, DestSimple02>();
                //    cfg.CreateMap<InnerSource02, DestSimple02>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestSimple02>(new SrcComplex02()
                //{
                //    Name = "name",
                //    InnerSource = new InnerSource { Description = "description" },
                //    InnerSource02 = new InnerSource02 { Title = "title", Description = "descpripiton2" }
                //});
            }
            //（8）映射反转
            //（9）使用特性映射
            //（10）动态类型到普通类型映射
            {
                //var configuration = new MapperConfiguration(cfg => { });
                //var mapper = configuration.CreateMapper();
                //dynamic src = new ExpandoObject();//ExpandoObject对象包含可在运行时动态添加或移除的成员
                //src.Name = "zhangsan";
                //src.Age = 18;
                //var dest = mapper.Map<Dest01>(src);
            }
            //（11）泛型映射
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap(typeof(SrcGeneric<>), typeof(DestGeneric<>));
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestGeneric<int>>(new SrcGeneric<int>() { TValue = 18 });
            }
            //（12）Dictonary到普通类型映射
            //不需要配置映射关系，配置之后反而无法映射成功
            {
                //var configuration = new MapperConfiguration(cfg =>{});
                //var mapper = configuration.CreateMapper();
                //Dictionary<string, object> dic = new Dictionary<string, object>();
                //dic.Add("Name","zhangsan");
                //dic.Add("Age",18);
                //var dest = mapper.Map<Dest01>(dic);
            }
            //5、映射进阶
            //（1）自定义类型转换
            {
                //var configuration = new MapperConfiguration(cfg => {
                //    //可以直接转换
                //    cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
                //    //也可以定义转换器转换
                //    cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
                //    cfg.CreateMap<SrcConverter, DestConverter>();
                //});
                //var src = new SrcConverter
                //{
                //    Age = "5",
                //    Time = "05/12/2022"
                //};
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestConverter>(src);
            }
            //（2）自定义值解析
            //这种与一般的MapFrom()区别是可以添加更加复杂的逻辑
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcResolver, DestResolver>()
                //    //针对的是某一个map的某一个member的两种写法
                //    //.ForMember(dest => dest.Info, opt => opt.MapFrom<CustomResolver>())
                //    .ForMember(dest => dest.Info, opt => opt.MapFrom(new CustomResolver()));
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestResolver>(new SrcResolver() { Name = "zhangsan", Age = 18 });
            }
            //（3）条件映射
            //符合某些条件时才映射
            //Condition方法会在MapFrom方法后判断,PreCondition会在MapFrom前判断
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<SrcCondition, DestCondition>()
                //    //src.Name.Length>=3&&(src.Name+"XXX").Length >= 5 两个条件都满足才映射
                //    .ForMember(dest => dest.Name, opt => opt.PreCondition(src => src.Name.Length >= 3))
                //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name + "XXX"))
                //    .ForMember(dest => dest.Name, opt => opt.Condition(src => src.Name.Length >= 5))
                //    //src.Age <= 15&&src.Age * 3>=30 两个条件都满足才映射
                //    .ForMember(dest => dest.Age, opt => opt.PreCondition(src => src.Age <= 15))
                //    .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age * 3))
                //    .ForMember(dest => dest.Age, opt => opt.Condition(src => src.Age >= 30));
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<DestCondition>(new SrcCondition() { Name = "zhangsan", Age = 18 });
            }
            //（4）空值处理
            //如果src为null的话，就给dest一个默认值
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Src01, Dest01>()
                //    .ForMember(dest => dest.Name, opt => opt.NullSubstitute("XXX"));
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest01>(new Src01() { Age = 18 });
            }
            //（5）类型映射处理
            //针对某种类型做特殊处理，可以应用到全局、某个Profile、某个Map或某个member
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.ValueTransformers.Add<string>(val => "fawaikuangtu " + val + " !!!");
                //    cfg.ValueTransformers.Add<int>(val => val + 2);
                //    cfg.CreateMap<Src01, Dest01>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest01>(new Src01() { Name = "zhangsan", Age = 17 });
            }
            //（6）映射前后干点事
            //映射关系配置时配置
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Src01, Dest01>()
                //    //转换前对dest的处理会被转换结果覆盖
                //    .BeforeMap((src, dest) => { Console.WriteLine($"转换前处理前{src.Name}--{dest.Name}"); src.Name = src.Name + " !!!"; dest.Name = "转换前赋值"; Console.WriteLine($"转换前处理后{src.Name}--{dest.Name}"); })
                //    //转换后对src的处理是没意义的
                //    .AfterMap((src, dest) => { Console.WriteLine($"转换后处理前{src.Name}--{dest.Name}"); dest.Name = "fawaikuangtu " + dest.Name; src.Name = "转换后赋值"; Console.WriteLine($"转换后处理后{src.Name}--{dest.Name}"); });
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest01>(new Src01() { Name = "zhangsan" });
            }
            //映射关系转换时配置
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Src01, Dest01>();                    
                //});
                //var mapper = configuration.CreateMapper();
                //var src = new Src01() { Name = "zhangsan" };
                //var dest = mapper.Map<Src01,Dest01>(src, opt => {
                //    //转换前dest是null
                //    opt.BeforeMap((src, dest) => {src.Name = src.Name + " !!!"; });
                //    //转换后对src的处理是没意义的
                //    opt.AfterMap((src, dest) => {dest.Name = "fawaikuangtu " + dest.Name;});
                //});                   
            }
            //（7）忽略某些字段映射
            //映射时配置忽略字段
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.CreateMap<Src01, Dest01>()
                //    .ForMember(dest => dest.Name, opt => opt.Ignore());
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest01>(new Src01() { Name = "zhangsan", Age = 18 });
            }
            //忽略属性和字段
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{
                //    cfg.ShouldMapField = fi => false;
                //    cfg.ShouldMapProperty = fi => false;
                //    cfg.CreateMap<Src01, Dest01>();
                //});
                //var mapper = configuration.CreateMapper();
                //var dest = mapper.Map<Dest01>(new Src01() { Name = "zhangsan", Age = 18 });
            }
            //（8）多个源映射到一个目标
            {
                //var configuration = new MapperConfiguration(cfg =>
                //{                    
                //    cfg.CreateMap<SrcPartA, DestCombine>()
                //    .ForMember(dest => dest.FiledA, opt => opt.MapFrom(src => src.FiledPartA))
                //    .ForMember(dest => dest.FiledB, opt => opt.MapFrom(src => src.FiledPartB));

                //    cfg.CreateMap<SrcPartB, DestCombine>()
                //    .ForMember(dest => dest.FiledC, opt => opt.MapFrom(src => src.FiledPartC))
                //    .ForMember(dest => dest.FiledD, opt => opt.MapFrom(src => src.FiledPartD));

                //    cfg.CreateMap<SrcPartC, DestCombine>()
                //    .ForMember(dest => dest.FiledE, opt => opt.MapFrom(src => src.FiledPartE))
                //    .ForMember(dest => dest.FiledF, opt => opt.MapFrom(src => src.FiledPartF));
                //});
                //var mapper = configuration.CreateMapper();
                //var srcPartA = new SrcPartA() { FiledPartA="A",FiledPartB="B"};
                //var srcPartB = new SrcPartB() { FiledPartC="C",FiledPartD="D"};
                //var srcPartC = new SrcPartC() { FiledPartE="E",FiledPartF="F"};
                //var dest=new DestCombine();
                //dest=mapper.Map(srcPartA,dest);
                //dest=mapper.Map(srcPartB,dest);
                //dest=mapper.Map(srcPartC,dest);
            }
            //5、性能测试
            {
                //配置映射关系
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SrcPart, DestCombine>()
                    .ForMember(dest => dest.FiledA, opt => opt.MapFrom(src => src.SrcPartA.FiledPartA))
                    .ForMember(dest => dest.FiledB, opt => opt.MapFrom(src => src.SrcPartA.FiledPartB))
                    .ForMember(dest => dest.FiledC, opt => opt.MapFrom(src => src.SrcPartB.FiledPartC))
                    .ForMember(dest => dest.FiledD, opt => opt.MapFrom(src => src.SrcPartB.FiledPartD))
                    .ForMember(dest => dest.FiledE, opt => opt.MapFrom(src => src.SrcPartC.FiledPartE))
                    .ForMember(dest => dest.FiledF, opt => opt.MapFrom(src => src.SrcPartC.FiledPartF));                    
                });
                var mapper = configuration.CreateMapper();
                //创建数据
                List<SrcPart> srcParts = new List<SrcPart>();
                for (int i = 0; i < 1000_000; i++)
                {
                    srcParts.Add(new SrcPart()
                    {
                        SrcPartA = new SrcPartA() { FiledPartA = "FiledPartA" + Guid.NewGuid(), FiledPartB = "FiledPartA" + Guid.NewGuid() },
                        SrcPartB = new SrcPartB() { FiledPartC = "FiledPartC" + Guid.NewGuid(), FiledPartD = "FiledPartD" + Guid.NewGuid() },
                        SrcPartC = new SrcPartC() { FiledPartE = "FiledPartE" + Guid.NewGuid(), FiledPartF = "FiledPartF" + Guid.NewGuid() }
                    });
                }
                //转换数据
                Stopwatch sw = new Stopwatch();
                sw.Start();
                List<DestCombine> dest=mapper.Map<List<DestCombine>>(srcParts);
                sw.Stop();
                Console.WriteLine("耗时：" + sw.ElapsedMilliseconds);
            }
            Console.ReadKey();
        }
    }
}
