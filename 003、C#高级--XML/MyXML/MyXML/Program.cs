using System.Reflection.Metadata;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace MyXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //文件存在删除
            if (File.Exists("test.xml"))
            {
                File.Delete("test.xml");
            }

            Console.WriteLine("test.xml文件开始创建");
            Console.WriteLine();

            //创建xml文档
            {
                //创建xml文档
                XmlDocument xmldoc = new XmlDocument();

                //加入XML声明
                XmlDeclaration xmldecl = xmldoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmldoc.AppendChild(xmldecl);

                // 创建一个注释节点  
                XmlNode comment = xmldoc.CreateComment("这是一个注释");
                xmldoc.AppendChild(comment);

                //加入一个根元素
                XmlElement employees = xmldoc.CreateElement("Employees");
                xmldoc.AppendChild(employees);

                //根元素加入一些子元素
                for (int i = 1; i < 5; i++)
                {
                    // 创建一个注释节点  
                    XmlNode comment1 = xmldoc.CreateComment("Employee" + i);
                    employees.AppendChild(comment1);

                    XmlElement employee = xmldoc.CreateElement("Employee"+i);//创建一个子节点
                    employee.SetAttribute("name", "人员" + i);//设置该节点属性

                    XmlElement age = xmldoc.CreateElement("Age");//创建一个孙节点
                    age.InnerText = (18+i).ToString();//设置文本
                    employee.AppendChild(age);//添加到子节点中

                    XmlElement sex = xmldoc.CreateElement("Sex");//创建一个孙节点
                    sex.InnerText = i % 2 == 0 ? "男" : "女";//设置文本
                    employee.AppendChild(sex);//添加到子节点中

                    XmlElement salary = xmldoc.CreateElement("Salary");
                    salary.InnerText = (10000 + i * 100).ToString();
                    employee.AppendChild(salary);

                    employees.AppendChild(employee);//将子节点添加到根节点中 
                }
                //保存创建好的XML文档
                xmldoc.Save("test.xml");
            }

            Console.WriteLine("test.xml文件创建完成");
            Console.WriteLine();
            Console.WriteLine(File.ReadAllText("test.xml"));
            Console.WriteLine();
            Console.WriteLine("test.xml文件开始读取");
            Console.WriteLine();

            //读取xml内容
            {
                //创建xml文档
                XmlDocument xmldoc = new XmlDocument();

                //导入指定xml文件
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.IgnoreComments = true;//忽略文档里面的注释，注释也是节点，但是无法转换成XmlElement，所以这里不忽略，下面转换就报错
                //需要using包起来，读完释放资源，防止占用
                using (XmlReader reader = XmlReader.Create("test.xml", settings))
                {
                    xmldoc.Load(reader);
                }

                //获取根节点
                XmlElement employees=xmldoc.DocumentElement;

                //遍历根节点的子节点
                foreach (XmlElement employee in employees.ChildNodes)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{employee.Name}--{employee.GetAttribute("name")}");
                    foreach (XmlElement child in employee.ChildNodes)
                    {
                        sb.Append($"--{child.Name}：{child.InnerText}");
                    }
                    Console.WriteLine(sb.ToString());
                }
            }

            Console.WriteLine();
            Console.WriteLine("test.xml文件读取完成");
            Console.WriteLine();
            Console.WriteLine("test.xml文件开始修改");
            Console.WriteLine();

            //修改xml内容
            {
                //创建xml文档
                XmlDocument xmldoc = new XmlDocument();

                //导入指定xml文件
                xmldoc.Load("test.xml");

                //获取根节点
                XmlElement employees = xmldoc.DocumentElement;

                //添加节点
                XmlElement newemployee = xmldoc.CreateElement("Employee4");//创建一个子节点
                newemployee.SetAttribute("name", "新的人员4");//设置该节点属性
                XmlElement age = xmldoc.CreateElement("Age");//创建一个孙节点
                age.InnerText = "88";//设置文本
                newemployee.AppendChild(age);//添加到子节点中
                XmlElement sex = xmldoc.CreateElement("Sex");//创建一个孙节点
                sex.InnerText ="女博士";//设置文本
                newemployee.AppendChild(sex);//添加到子节点中
                XmlElement salary = xmldoc.CreateElement("Salary");
                salary.InnerText = "20000";
                newemployee.AppendChild(salary);
                employees.InsertAfter(newemployee, employees.ChildNodes[1]);//将子节点添加到第1个节点后

                //删除节点
                XmlNode nodeDelete=employees.SelectSingleNode("//Employee1");//筛选匹配的第一个节点
                employees.RemoveChild(nodeDelete);//删除筛选出来的节点

                //修改节点
                XmlElement nodeUpdate = employees.SelectSingleNode("//Employee2") as XmlElement;//筛选匹配的第一个节点
                nodeUpdate.SetAttribute("name", "新的人员2");
                nodeUpdate["Age"].InnerText = "99";
                nodeUpdate["Sex"].InnerText = "男博士";
                nodeUpdate["Salary"].InnerText = "18888";

                //筛选多个节点
                XmlNodeList nodes= employees.SelectNodes("//Employee4");
                Console.WriteLine("打印筛选出的节点信息");
                foreach (XmlElement employee in nodes)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{employee.Name}--{employee.GetAttribute("name")}");
                    foreach (XmlElement child in employee.ChildNodes)
                    {
                        sb.Append($"--{child.Name}：{child.InnerText}");
                    }
                    Console.WriteLine(sb.ToString());
                }

                //保存创建好的XML文档
                xmldoc.Save("test.xml");
                Console.WriteLine();
                Console.WriteLine("打印修改后的结果");
                Console.WriteLine(File.ReadAllText("test.xml"));
            }

            //文件存在删除
            if (File.Exists("namespace.xml"))
            {
                File.Delete("namespace.xml");
            }

            //多个命名空间
            {
                //创建xml文档
                XmlDocument xmldoc = new XmlDocument();

                //加入一个根元素
                XmlElement root = xmldoc.CreateElement("root");

                //根元素添加命名空间属性
                root.SetAttribute("xmlns:ns1", "http://www.example.com/namespace1");
                root.SetAttribute("xmlns:ns2", "http://www.example.com/namespace2");

                //添加子节点
                XmlElement element1 = xmldoc.CreateElement("ns1:element1");
                element1.InnerText = "Value 1";
                root.AppendChild(element1);

                //添加子节点
                XmlElement element2 = xmldoc.CreateElement("ns2:element2");
                element2.InnerText = "Value 2";
                root.AppendChild(element2);

                //添加子节点
                XmlElement element3 = xmldoc.CreateElement("element3");
                element3.SetAttribute("xmlns", "http://example.com/child");
                element3.InnerText = "Value 3";
                root.AppendChild(element3);

                xmldoc.AppendChild(root);

                //保存创建好的XML文档
                xmldoc.Save("namespace.xml");
                Console.WriteLine();
                Console.WriteLine("多个命名空间");
                Console.WriteLine();
                Console.WriteLine(File.ReadAllText("namespace.xml"));
            }

            Console.WriteLine();
            Console.WriteLine("XPath节点筛选");

            //XPath节点筛选
            {
                //创建xml文档
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load("test2.xml");

                Console.WriteLine("选择节点");
                XPathNodeIterator iterator1 = xmldoc.CreateNavigator().Select("//root/*");
                while (iterator1.MoveNext())
                {
                    XPathNavigator navigator = iterator1.Current;
                    Console.WriteLine(navigator.OuterXml);
                }

                Console.WriteLine("选择节点+条件");
                XPathNodeIterator iterator2 = xmldoc.CreateNavigator().Select("//root/*[age>10 and age<30]");
                while (iterator2.MoveNext())
                {
                    XPathNavigator navigator = iterator2.Current;
                    Console.WriteLine(navigator.OuterXml);
                }

                Console.WriteLine("筛选包含命名空间前缀节点");
                //筛选包含命名空间前缀节点，需要定义好命名空间，作为参数传入筛选器，否则筛选器无法识别命名空间
                XmlNamespaceManager company = new XmlNamespaceManager(xmldoc.NameTable);
                company.AddNamespace("companya", "http://www.example.com/companya");
                company.AddNamespace("companyb", "http://www.example.com/companyb");
                XPathNodeIterator iterator3 = xmldoc.CreateNavigator().Select("//companya:customer1", company);
                while (iterator3.MoveNext())
                {
                    XPathNavigator navigator = iterator3.Current;
                    Console.WriteLine(navigator.OuterXml);
                }

                Console.WriteLine("筛选包含命名空间前缀节点+条件");
                XPathNodeIterator iterator4 = xmldoc.CreateNavigator().Select("//companya:customer1[contains(name,'o')]", company);
                while (iterator4.MoveNext())
                {
                    XPathNavigator navigator = iterator4.Current;
                    Console.WriteLine(navigator.OuterXml);
                }
            }

            //XML配置文件读写
            {
                Console.WriteLine("读取配置");
                Console.WriteLine($"Color:{XmlConfigHelper.GetValue("config.xml", "Color")}");//Red

                Console.WriteLine("设置配置");
                XmlConfigHelper.SetValue("config.xml", "Color","Green");
                Console.WriteLine($"Color:{XmlConfigHelper.GetValue("config.xml", "Color")}");//Green
                XmlConfigHelper.SetValue("config.xml", "Color", "Red");

                Console.WriteLine("添加配置");
                Console.WriteLine($"Has NewColor:{XmlConfigHelper.HasKey("config.xml", "NewColor")}");//False
                XmlConfigHelper.SetValue("config.xml", "NewColor", "Green");
                Console.WriteLine($"NewColor:{XmlConfigHelper.GetValue("config.xml", "NewColor")}");//Green

                Console.WriteLine("删除配置");
                Console.WriteLine($"Has NewColor:{XmlConfigHelper.HasKey("config.xml", "NewColor")}");//True
                XmlConfigHelper.DeleteKey("config.xml", "NewColor");
                Console.WriteLine($"Has NewColor:{XmlConfigHelper.HasKey("config.xml", "NewColor")}");//False
            }
        }
    }
}