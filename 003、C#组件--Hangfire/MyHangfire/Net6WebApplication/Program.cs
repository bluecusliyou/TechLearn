using Hangfire;
using Hangfire.Dashboard.BasicAuthorization;
using Hangfire.HttpJob;
using Hangfire.MySql;
using System.Transactions;

namespace Net6WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Hangfire services.
            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseStorage(new MySqlStorage(
                 builder.Configuration["ConnectionStrings:HangfireConnection"],
                 new MySqlStorageOptions
                 {
                     TransactionIsolationLevel = IsolationLevel.ReadCommitted,
                     QueuePollInterval = TimeSpan.FromSeconds(15),
                     JobExpirationCheckInterval = TimeSpan.FromHours(1),
                     CountersAggregateInterval = TimeSpan.FromMinutes(5),
                     PrepareSchemaIfNecessary = true,
                     DashboardJobListLimit = 50000,
                     TransactionTimeout = TimeSpan.FromMinutes(1),
                     TablesPrefix = "Hangfire"
                 })).UseHangfireHttpJob());


            var app = builder.Build();

            app.UseHangfireServer();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new BasicAuthAuthorizationFilter(new BasicAuthAuthorizationFilterOptions
                {
                    RequireSsl = false,
                    SslRedirect = false,
                    LoginCaseSensitive = true,
                    Users = new []
                    {
                        new BasicAuthAuthorizationUser
                        {
                            Login = "admin",
                            PasswordClear =  "test"
                        }
                    }
                })}
            });

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}