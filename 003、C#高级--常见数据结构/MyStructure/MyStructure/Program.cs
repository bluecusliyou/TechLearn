using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MyStructure
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //一、常见的数据结构
                //1、集合[Set]
                //2、线性结构
                //3、树形结构
                //4、图形结构
                //二、Array/ArrayList/List
                //内存上连续存储，节约空间，可以索引访问，读取快，增删慢            
                {
                    //1、Array
                    //元素类型是一样的，定长
                    Console.WriteLine("***************Array******************");
                    int[] list = new int[3];
                    list[0] = 123;
                    string[] stringArray = new string[] { "123", "234" };
                    for (int i = 0; i < list.Length; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                }
                {
                    //2、ArrayList
                    //元素没有类型限制，任何元素都是当成object处理，如果是值类型，会有装箱操作，不定长
                    Console.WriteLine("***************ArrayList******************");
                    ArrayList list = new ArrayList();
                    //增加元素，增加长度
                    list.Add("张三");
                    list.Add("Is");
                    list.Add(32);
                    //索引赋值，不会增加长度，索引超出长度直接报错
                    list[2] = 26;
                    list.AddRange(new ArrayList() { "李四",135});
                    //删除数据
                    list.RemoveAt(0);
                    list.Remove("张三");
                    list.RemoveRange(0, 1);//index,count
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                    //转换成Arrary
                    object[] list2 = (object[])list.ToArray(typeof(object));
                    object[] list3 = new object[list.Count];
                    list.CopyTo(list3);
                }
                {
                    //3、List
                    //也是Array，泛型，保证类型安全，避免装箱拆箱，性能比Arraylist高，不定长
                    Console.WriteLine("***************List<T>******************");
                    List<int> list = new List<int>();
                    list.Add(123);
                    list.Add(123);
                    //list.Add("123");类型确定，类型安全，不同类型无法添加
                    list[0] = 456;
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                }

                //三、LinkedList/Queue/Stack
                //非连续存储，存储数据和地址，只能顺序查找，读取慢，增删快
                {
                    //1、LinkedList
                    //链表，泛型，保证类型安全，避免装箱拆箱，元素不连续分配，每个元素都记录前后节点，不定长
                    Console.WriteLine("***************LinkedList<T>******************");
                    LinkedList<int> list = new LinkedList<int>();
                    //list[3] //不能索引访问
                    list.AddFirst(123);//在最前面添加
                    list.AddLast(456); //在最后面添加
                    //是否包含元素
                    bool isContain = list.Contains(123);
                    //元素123的位置  从头查找
                    LinkedListNode<int> node123 = list.Find(123);  
                    //某节点前后添加
                    list.AddBefore(node123, 123);
                    list.AddAfter(node123, 9);
                    //移除
                    list.Remove(456);
                    list.Remove(node123);
                    list.RemoveFirst();
                    list.RemoveLast();
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    //清空
                    list.Clear();
                }
                {
                    //2、Queue
                    //队列，就是链表，先进先出
                    Console.WriteLine("***************Queue<T>******************");
                    Queue<string> numbers = new Queue<string>();
                    //入队列
                    numbers.Enqueue("one");
                    numbers.Enqueue("two");
                    numbers.Enqueue("two");
                    numbers.Enqueue("three");
                    numbers.Enqueue("four");
                    foreach (string number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                    //移除并返回队首元素
                    Console.WriteLine($"Dequeue {numbers.Dequeue()}");
                    foreach (string number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                    //不移除返回队首元素
                    Console.WriteLine($"Peek { numbers.Peek()}");
                    foreach (string number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                    //拷贝一个队列
                    Queue<string> queueCopy = new Queue<string>(numbers.ToArray());
                    foreach (string number in queueCopy)
                    {
                        Console.WriteLine(number);
                    }
                    //判断包含元素
                    Console.WriteLine($"queueCopy.Contains(\"four\") = {queueCopy.Contains("four")}");
                    //清空队列
                    queueCopy.Clear();
                    Console.WriteLine($"queueCopy.Count = {queueCopy.Count}");
                }
                {
                    //3、Stack
                    //栈，就是链表，先进后出
                    Console.WriteLine("***************Stack<T>******************");
                    Stack<string> numbers = new Stack<string>();
                    //入栈
                    numbers.Push("one");
                    numbers.Push("two");
                    numbers.Push("two");
                    numbers.Push("three");
                    numbers.Push("four");
                    numbers.Push("five");
                    foreach (string number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                    //获取并出栈
                    Console.WriteLine($"Pop {numbers.Pop()}");
                    foreach (string number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                    //获取不出栈
                    Console.WriteLine($"Peek { numbers.Peek()}");
                    foreach (string number in numbers)
                    {
                        Console.WriteLine(number);
                    }
                    //拷贝一个栈
                    Stack<string> stackCopy = new Stack<string>(numbers.ToArray());
                    foreach (string number in stackCopy)
                    {
                        Console.WriteLine(number);
                    }
                    //判断包含元素
                    Console.WriteLine($"stackCopy.Contains(\"four\") = {stackCopy.Contains("four")}");
                    //清空栈
                    stackCopy.Clear();
                    Console.WriteLine($"stackCopy.Count = {stackCopy.Count}");
                }

                //四、HashSet/SortedSet
                //纯粹的集合，容器，唯一，无序           
                {
                    //1、HashSet
                    //集合，hash分布，动态增加容量，去重数据或者引用类型地址
                    //应用场景：去重可以统计用户IP，计算集合元素的交叉并补，二次好友/间接关注/粉丝合集
                    Console.WriteLine("***************HashSet<string>******************");
                    HashSet<string> hashSetA = new HashSet<string>();
                    hashSetA.Add("123");
                    hashSetA.Add("456");
                    //系统为了提高性能，减少内存占用，字符串是设计成池化的，字符串也是引用类型的，同一个字符串地址是相同的，所以会去重
                    string s1 = "12345";
                    hashSetA.Add(s1);
                    string s2 = "12345";
                    hashSetA.Add(s2);
                    //hashSet[0];//不能使用索引访问                
                    //判断包含元素
                    Console.WriteLine($"hashSetA.Contains(\"12345\") = {hashSetA.Contains("12345")}");
                    //集合的计算：交叉并补
                    Console.WriteLine("集合A******************");
                    foreach (var item in hashSetA)
                    {
                        Console.WriteLine(item);
                    }
                    HashSet<string> hashSetB = new HashSet<string>();
                    hashSetB.Add("123");
                    hashSetB.Add("789");
                    hashSetB.Add("12435");
                    Console.WriteLine("集合B******************");
                    foreach (var item in hashSetB)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("交：属于A且属于B的元素******************");
                    //拷贝一个集合
                    HashSet<string> hashSetCopy4 = new HashSet<string>(hashSetB);
                    hashSetCopy4.IntersectWith(hashSetA);
                    foreach (var item in hashSetCopy4)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("差：属于B，不属于A的元素******************");
                    HashSet<string> hashSetCopy3 = new HashSet<string>(hashSetB);
                    hashSetCopy3.ExceptWith(hashSetA);
                    foreach (var item in hashSetCopy3)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("并：属于A或者属于B的元素******************");
                    HashSet<string> hashSetCopy2 = new HashSet<string>(hashSetB);
                    hashSetCopy2.UnionWith(hashSetA);
                    foreach (var item in hashSetCopy2)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("补：AB的并集去掉AB的交集******************");
                    HashSet<string> hashSetCopy = new HashSet<string>(hashSetB);
                    hashSetCopy.SymmetricExceptWith(hashSetA);
                    foreach (var item in hashSetCopy)
                    {
                        Console.WriteLine(item);
                    }
                    //转换成List集合
                    hashSetA.ToList();
                    //清空集合
                    hashSetA.Clear();
                    //添加对象引用去重
                    HashSet<People> peoples = new HashSet<People>();
                    People people = new People()
                    {
                        Id = 123,
                        Name = "小菜"
                    };
                    People people1 = new People()
                    {
                        Id = 123,
                        Name = "小菜"
                    };
                    peoples.Add(people);
                    peoples.Add(people1);//内容相同也是不同的对象
                    peoples.Add(people1);//同一个对象会去重
                    foreach (var item in peoples)
                    {
                        Console.WriteLine(item);
                    }
                }
                {
                    //2、SortedSet
                    //排序的集合，去重，排序
                    //应用场景：名字排序
                    Console.WriteLine("***************SortedSet<string>******************");
                    SortedSet<string> sortedSet = new SortedSet<string>();
                    sortedSet.Add("123");
                    sortedSet.Add("689");
                    sortedSet.Add("456");
                    sortedSet.Add("12435");
                    sortedSet.Add("12435");
                    sortedSet.Add("12435");
                    //判断包含元素
                    Console.WriteLine($"sortedSet.Contains(\"12435\") = {sortedSet.Contains("12435")}");
                    //转换成List集合
                    sortedSet.ToList();
                    //清空集合
                    sortedSet.Clear();
                }

                //五、Hashtable/Dictionary/SortedDictionary/SortedList
                //读取，增删都快，key-value，一段连续有限空间放value，基于key散列计算得到地址索引，读取增删都快，开辟的空间比用到的多，hash是用空间换性能
                //基于key散列计算得到地址索引，如果Key数量过多，散列计算后，肯定会出现散列冲突（不同的key计算出的索引相同）
                //散列冲突之后，据存储就是在索引的基础上往后找空闲空间存放，读写增删性能就会下降，dictionary在3W条左右性能就开始下降
                {
                    //1、Hashtable
                    //哈希表，元素没有类型限制，任何元素都是当成object处理，存在装箱拆箱
                    Console.WriteLine("***************Hashtable******************");
                    Hashtable table = new Hashtable();
                    table.Add("123", "456");
                    //table.Add("123", "456");//key相同  会报错
                    table[234] = 456;
                    table[234] = 567;
                    table[32] = 4562;
                    foreach (DictionaryEntry item in table)
                    {
                        Console.WriteLine($"Key：{item.Key} Value：{item.Value}");
                    }
                    //移除元素
                    table.Remove("123");
                    //获取key，value集合
                    var keylist = table.Keys;
                    var valuelist = table.Values;
                    //判断包含key,value
                    Console.WriteLine($"table.ContainsKey(\"123\") ={table.ContainsKey("123") }");
                    Console.WriteLine($"table.ContainsValue(\"456\") ={table.ContainsValue("456") }");
                    //清空
                    table.Clear();
                }
                {
                    //2、Dictionary
                    //字典，支持泛型，无序
                    Console.WriteLine("***************Dictionary******************");
                    Dictionary<int, string> dic = new Dictionary<int, string>();
                    dic.Add(1, "HaHa");
                    dic.Add(5, "HoHo");
                    dic.Add(3, "HeHe");
                    dic.Add(2, "HiHi");
                    foreach (var item in dic)
                    {
                        Console.WriteLine($"Key：{item.Key} Value：{item.Value}");
                    }
                }
                {
                    //3、SortedDictionary
                    //字典，支持泛型，有序
                    Console.WriteLine("***************SortedDictionary******************");
                    SortedDictionary<int, string> dic = new SortedDictionary<int, string>();
                    dic.Add(1, "HaHa");
                    dic.Add(5, "HoHo");
                    dic.Add(3, "HeHe");
                    dic.Add(2, "HiHi");
                    dic.Add(4, "HuHu1");
                    dic[4] = "HuHu";                    
                    foreach (var item in dic)
                    {
                        Console.WriteLine($"Key：{item.Key} Value：{item.Value}");
                    }
                }
                {
                    //4、SortedList
                    //排序列表是数组和哈希表的组合，使用索引访问各项，则它是一个动态数组，如果您使用键访问各项，则它是一个哈希表。集合中的各项总是按键值排序。
                    Console.WriteLine("***************SortedList******************");
                    SortedList sortedList = new SortedList();
                    sortedList.Add("First", "Hello");
                    sortedList.Add("Second", "World");
                    sortedList.Add("Third", "!");
                    sortedList["Third"] = "~~";
                    sortedList.Add("Fourth", "!");
                    //使用键访问
                    sortedList["Fourth"] = "!!!";
                    //可以用索引访问
                    Console.WriteLine(sortedList.GetByIndex(0));
                    //获取所有key
                    var keyList = sortedList.GetKeyList();
                    //获取所有value
                    var valueList = sortedList.GetValueList();
                    //用于最小化集合的内存开销
                    sortedList.TrimToSize();
                    //删除元素
                    sortedList.Remove("Third");
                    sortedList.RemoveAt(0);
                    //清空集合
                    sortedList.Clear();
                }

                //六、迭代器模式
                //1、迭代器模式
                //迭代器模式是设计模式中行为模式(behavioral pattern)的一种。迭代器模式使得你能够使用统一的方式获取到序列中的所有元素，而不用关心是其类型是array，list，linked list或者是其他什么序列结构。这一点使得能够非常高效的构建数据处理通道(data pipeline)。
                //在.NET中，迭代器模式被IEnumerator和IEnumerable及其对应的泛型接口所封装。
                //IEnumerable：如果一个类实现了IEnumerable接口，那么就能够被迭代，IEnumerable接口定义了GetEnumerator方法将返回IEnumerator接口的实现，它就是迭代器本身。
                //IEnumerator：IEnumerator接口定义了访问数据的统一属性和方法object Current：当前访问的数据对象，bool MoveNext()：移动到下一个位置访问下一个数据的方法，并判断是否有下一个数据;void Reset()：数据列表改变或者重新访问重置位置
                {
                    Console.WriteLine("***************迭代器模式--各自遍历******************");
                    //数组的遍历
                    int[] list = new int[3] { 1, 2, 3 };
                    for (int i = 0; i < list.Length; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                    //List遍历
                    List<int> list2 = new List<int>() { 1, 2, 3 };
                    for (int i = 0; i < list2.Count; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                    Console.WriteLine("***************迭代器模式--foreach通用遍历******************");
                    //通用遍历
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }
                    foreach (var item in list2)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine("***************迭代器模式--迭代器遍历******************");
                    //迭代器访问真相
                    var list3 = list.GetEnumerator();
                    while (list3.MoveNext())
                    {
                        Console.WriteLine(list3.Current);
                    }
                    //迭代器访问真相
                    var list4 = list2.GetEnumerator();
                    while (list4.MoveNext())
                    {
                        Console.WriteLine(list4.Current);
                    }
                }

                //2、Yield原理
                //Yield关键字其实是一种语法糖，最终还是通过实现IEnumberable<T>、IEnumberable、IEnumberator<T>和IEnumberator接口实现的迭代功能，含有yield的函数说明它是一个生成器，而不是普通的函数。Yield必须配合IEnumerable使用。
                //当程序运行到yield return这一行时，该函数会返回值，并保存当前域的所有变量状态，等到该函数下一次被调用时，会从上一次中断的地方继续往下执行，直到函数正常执行完成。
                //当程序运行到yield break这一行时，程序就结束运行退出。
                {
                    Console.WriteLine("*****************Yield**********************");
                    var yieldlist = Yield();
                    foreach (var item in yieldlist)
                    {
                        Console.WriteLine(item);//按需获取，要一个拿一个
                    }
                    var commonlist = Common();
                    foreach (var item in commonlist)
                    {
                        Console.WriteLine(item);//先全部获取，然后一起返回
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Yield方法
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> Yield()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i > 2 && i < 4)
                {
                    yield break;
                }
                else
                {
                    yield return Get(i);
                    Console.WriteLine($"Yield执行第{i + 1}次");
                }
            }
        }

        /// <summary>
        /// 普通方法的遍历
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<int> Common()
        {
            List<int> intList = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                intList.Add(Get(i));
                Console.WriteLine($"Common执行第{i + 1}次");
            }
            return intList;
        }

        private static int Get(int num)
        {
            Thread.Sleep(500);
            return num * DateTime.Now.Second;
        }
    }
}
