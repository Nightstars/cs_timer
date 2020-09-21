/* -----------------------------------------------------------------------------
 1.    INTRODUCTION
This project is a guide program on how to use the console to perform timing tasks
on the .net core platform, so that the developer who require this
business do not need to focus on the realization of timing tasks, but pay 
more attention to actual business functions. This project supports configuration 
Files, allowing dynamic adjustment of the timing point after the version is 
released, temporarily only supports daily timing, which can be accurate to the 
second level.
2.    CONTACT INFORMATION
chrsitzhangowner@gmail.com
----------------------------------------------------------------------------- */

/************************ cs_timer .net core support *************************
   Author(s):   christ chang
   Description: cs_timer .net core support
   github: https://github.com/Nightstars/cs_timer
*******************************************************************************/
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
            Console.WriteLine("/********************** cs_timer .net core support ***********************");
                Console.WriteLine("   Author(s):   christ chang");
                Console.WriteLine("   Description: cs_timer .net core support");
                Console.WriteLine("   github: https://github.com/Nightstars/cs_timer");
                Console.WriteLine("************************************************************************/");
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
