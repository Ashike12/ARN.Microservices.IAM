using Microsoft.AspNetCore;
using ARN.Microservices.IAM;

public class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.SetMinimumLevel(LogLevel.Information);
            })
            .UseSetting(WebHostDefaults.DetailedErrorsKey, "true")
            .UseStartup<StartUp>();
}