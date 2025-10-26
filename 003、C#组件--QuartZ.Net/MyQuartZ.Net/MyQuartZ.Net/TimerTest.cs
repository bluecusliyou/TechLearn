namespace MyQuartZ.Net
{
    public class TimerTest
    {
        public static void Show()
        {
            //2秒后每隔3秒执行一次，传入参数"1"
            Timer timer = new Timer((n) =>
            {
                Console.WriteLine("我是定时器中的业务逻辑{0}", n);
            }, "1", 2000, 3000);
        }
    }
}
