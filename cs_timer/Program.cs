using cs_timer.startup;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace cs_timer
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string time = configuration.GetSection("SystemSettings")["taskPlanTime"];
            string dbtype = configuration.GetSection("DbSettings")["dbtype"];
            string server = configuration.GetSection("DbSettings")["server"];
            string port = configuration.GetSection("DbSettings")["port"];
            string user = configuration.GetSection("DbSettings")["user"];
            string password = configuration.GetSection("DbSettings")["password"];
            string defaultDatabase = configuration.GetSection("DbSettings")["defaultDatabase"];
            Console.WriteLine("配置信息");
            Console.WriteLine($"任务时间：{time}");
            Console.WriteLine($"数据库类型：{dbtype}");
            Console.WriteLine($"服务主机：{server}");
            Console.WriteLine($"端口：{port}");
            Console.WriteLine($"用户：{user}");
            Console.WriteLine($"密码：{password}");
            Console.WriteLine($"默认数据库：{defaultDatabase}");
            new Ignition().InitTaskPlanTime(time).Start();
        }
    }
}
