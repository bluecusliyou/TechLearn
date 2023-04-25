namespace Net6WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //配置日志
            builder.Services.AddLogging(logBuilder =>
            {
                logBuilder.ClearProviders();//删除所有其他的关于日志记录的配置
                logBuilder.SetMinimumLevel(LogLevel.Trace);//设置最低的log级别
                logBuilder.AddLog4Net("CfgFile/log4Net.config");//支持log4net
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}