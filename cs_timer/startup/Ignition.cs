/* -----------------------------------------------------------------------------
 1.    INTRODUCTION
This project is a guide program on how to use the console to perform timing tasks
on the .net core platform, so that the development tasks that require this
business need do not need to focus on the realization of timing tasks, but pay 
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
using cs_timer.utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;

namespace cs_timer.startup
{
    class Ignition
    {

        #region properties
        private string taskPlanTime;
        private DatetimeUtils datetimeUtils = new DatetimeUtils();
        #endregion

        #region MyRegion
        public Ignition InitTaskPlanTime(string taskPlanTime)
        {
            this.taskPlanTime = taskPlanTime;
            return this;
        }
        #endregion

        #region start
        /// <summary>
        ///开始执行
        /// </summary>
        /// <returns></returns>
        public Ignition Start()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Title = "定时任务";
            Console.CursorVisible = false;
            Program obj = new Program();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(PollingEvent);
            timer.AutoReset = false;
            timer.Interval = 1000;
            while (true)
            {
                timer.Start();
            }
        }
        #endregion

        #region PollingEvent
        /// <summary>
        /// 计划事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PollingEvent(object sender, ElapsedEventArgs e)
        {
            string dt2 = DateTime.Now.ToString("T");
            DateTime dt3 = Convert.ToDateTime(dt2);
            DateTime dt1 = Convert.ToDateTime(this.taskPlanTime);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("系统时间：" + DateTime.Now.ToString("F") + "\t距离下次同步时间：" + datetimeUtils.Remain(dt1));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b");
            if (DateTime.Compare(dt1, dt3) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine();
                string startTime = DateTime.Now.ToString("F");
                Console.WriteLine(startTime + "\ttask running……");
                Thread.Sleep(10000);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(DateTime.Now.ToString("F") + "\ttask end succesfully");
                string endTime = DateTime.Now.ToString("F");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(DateTime.Now.ToString("F")+"\t本次同步用时：" + datetimeUtils.RunningTime(Convert.ToDateTime(startTime), Convert.ToDateTime(endTime)));
            }

        }
        #endregion
    }
}
