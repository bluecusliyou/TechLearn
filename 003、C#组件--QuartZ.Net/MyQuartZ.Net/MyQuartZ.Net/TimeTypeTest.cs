using Quartz;

namespace MyQuartZ.Net
{
    public class TimeTypeTest
    {
        public static void Show()
        {
            //时间类型互相转换
            DateTime date1 = DateTime.Parse("2022-01-01 12:00:00");
            DateTimeOffset date2 = DateBuilder.DateOf(12, 00, 00, 1, 1, 2022);
            //DateTime 转换成 DateTimeOffset  TimeSpan表示一个时间间隔
            DateTimeOffset date3 = new DateTimeOffset(date1, TimeSpan.Zero);
            //DateTimeOffset 转换成 DateTime
            DateTime date4 = Convert.ToDateTime(date2);

            //表示固定时间
            DateTime date5 = DateTime.Parse("2022-01-01 12:00:00");
            DateTime date6 = new DateTime(2022, 1, 1, 12, 0, 0);
            DateTimeOffset date7 = DateBuilder.DateOf(12, 00, 00, 1, 1, 2022);
            //2022-01-01 12:00:00  往后增加6天5小时4分3秒
            DateTimeOffset date8 = new DateTimeOffset(12, 00, 00, 1, 1, 2022, new TimeSpan(6, 5, 4, 3));
            //今天的3点2分1秒
            DateTimeOffset date9 = DateBuilder.TodayAt(3, 2, 1);
            //明天的3点2分1秒
            DateTimeOffset date10 = DateBuilder.TomorrowAt(3, 2, 1);

            //四舍五入
            DateTimeOffset date11 = DateBuilder.TodayAt(6, 5, 4);
            DateTimeOffset date12 = DateBuilder.EvenHourDate(date11);           //小时维度上入：7:00:00
            DateTimeOffset date13 = DateBuilder.EvenHourDateBefore(date11);     //小时维度上舍：6:00:00

            //时间周期
            //第一个参数传入null以当前时间为依据，假设当前时间为：14:43:29
            //第一个参数传入时间以传入时间为基准
            //第二个参数传入10表示以整10分钟作为一个周期，10,20,30,40,50,60
            //第二个参数传入20表示以整20分钟作为一个周期，20,40,60
            DateTimeOffset date14 = DateBuilder.NextGivenMinuteDate(null, 10);                              //14:50:00
            DateTimeOffset date15 = DateBuilder.NextGivenMinuteDate(null, 20);                              //15:00:00
            DateTimeOffset date16 = DateBuilder.NextGivenMinuteDate(DateBuilder.TodayAt(1, 45, 30), 10);    //1:50:00

            //增加时间
            DateTime date17 = DateTime.Now.AddYears(1);//当前时间+1年
            DateTime date18 = DateTime.Now.AddMonths(1);//当前时间+1月
            DateTime date19 = DateTime.Now.AddDays(1);//当前时间+1天
            DateTime date20 = DateTime.Now.AddHours(1);//当前时间+1小时
            DateTime date21 = DateTime.Now.AddMinutes(1);//当前时间+1分钟
            DateTime date22 = DateTime.Now.AddSeconds(1);//当前时间+1秒       
        }
    }
}