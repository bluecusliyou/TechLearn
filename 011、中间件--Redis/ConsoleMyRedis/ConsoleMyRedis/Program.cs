namespace ConsoleMyRedis
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // 创建 RedisHelper 实例
            string connectionString = "192.168.119.170:6379,password=123123456"; // 根据您的 Redis 服务器配置替换连接字符串
            RedisHelper redisHelper = new RedisHelper(connectionString);

            // 1. 设置连接字符串、选择数据库
            redisHelper.SelectDB(0);

            // 2. String 操作
            Console.WriteLine("String 操作:");
            await redisHelper.SetStringOfAsync("myKey", "myValue");
            string value = await redisHelper.GetStringOfAsync("myKey");
            Console.WriteLine($"获取到的值: {value}");

            // 保存多个键值对
            var keyValuePairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("key1", "value1"),
                new KeyValuePair<string, string>("key2", "value2")
            };
            bool setResult = await redisHelper.SetStringOfAsync(keyValuePairs);
            Console.WriteLine($"多个键值对保存结果: {setResult}");

            // 存储和获取对象
            var myObject = new { Name = "Alice", Age = 30 };
            await redisHelper.SetObjStringOfAsync("myObjectKey", myObject);
            var retrievedObject = await redisHelper.GetObjStringOfAsync<dynamic>("myObjectKey");
            Console.WriteLine($"获取的对象 - Name: {retrievedObject.Name}, Age: {retrievedObject.Age}");

            // 3. Hash 操作
            Console.WriteLine("\nHash 操作:");
            await redisHelper.SetHashOfAsync("myHash", "field1", "value1");
            string hashValue = await redisHelper.GetHashOfAsync("myHash", "field1");
            Console.WriteLine($"获取 Hash 值: {hashValue}");

            // 设置多个字段
            var hashFields = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("field2", "value2"),
                new KeyValuePair<string, string>("field3", "value3")
            };
            await redisHelper.SetHashOfAsync("myHash", hashFields);
            var allHashValues = await redisHelper.HashValuesAsync("myHash");
            Console.WriteLine($"所有 Hash 值: {string.Join(", ", allHashValues)}");

            // 4. List 操作
            Console.WriteLine("\nList 操作:");
            await redisHelper.PushKeyOfListLastAsync("myList", "item1");
            await redisHelper.PushKeyOfListLastAsync("myList", "item2");
            string firstItem = await redisHelper.PopFirtKeyOfListAsync("myList");
            Console.WriteLine($"移除的第一个元素: {firstItem}");
            var allListItems = await redisHelper.ListRangeAsync("myList");
            Console.WriteLine($"列表中的所有元素: {string.Join(", ", allListItems)}");

            // 5. SortedSet 操作
            Console.WriteLine("\nSortedSet 操作:");
            await redisHelper.SortedSetAddAsync("mySortedSet", "member1", 1.0);
            await redisHelper.SortedSetAddAsync("mySortedSet", "member2", 2.0);
            var sortedSetMembers = await redisHelper.SortedSetRangeByRankAsync("mySortedSet");
            Console.WriteLine($"有序集合中的元素: {string.Join(", ", sortedSetMembers)}");

            // 6. Key 操作
            Console.WriteLine("\nKey 操作:");
            bool exists = redisHelper.ExistsKey("myKey");
            Console.WriteLine($"Key 是否存在: {exists}");

            await redisHelper.RenameKeyAsync("myKey", "myRenamedKey");
            exists = redisHelper.ExistsKey("myRenamedKey");
            Console.WriteLine($"重命名后的 Key 是否存在: {exists}");

            // 7. 发布订阅
            Console.WriteLine("\n发布订阅:");
            redisHelper.Subscribe("myChannel", (channel, message) =>
            {
                Console.WriteLine($"接收到消息: {message} 在频道: {channel}");
            });

            // 发布信息
            long publishResult = await redisHelper.PublishAsync("myChannel", "Hello, Redis!");
            Console.WriteLine($"消息发布结果: {publishResult}");

            // 确保订阅持久化，以防止程序提前退出
            Console.WriteLine("按任意键继续...");
            Console.ReadKey();
        }
    }
}