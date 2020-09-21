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
using System;
using System.Collections.Generic;
using System.Text;

namespace cs_timer.utils
{
    class DatetimeUtils
    {

        #region Remain
        /// <summary>
        /// 计算下次任务剩余时间
        /// </summary>
        /// <param name="dt1">计划任务时间</param>
        /// <returns></returns>
        public string Remain(DateTime dt1)
        {
            string remaining = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(dt1.Ticks);
                TimeSpan ts2 = new TimeSpan(Convert.ToDateTime(DateTime.Now.ToString("T")).Ticks);
                TimeSpan datetimediff = ts1.Subtract(ts2).Duration();
                if (DateTime.Compare(Convert.ToDateTime(DateTime.Now.ToString("T")), dt1) > 0)
                {
                    string minutes = null;
                    if (((60 - int.Parse(datetimediff.Minutes.ToString())) == 60))
                    {
                        minutes = "59";
                    }
                    else
                    {
                        minutes = (60 - int.Parse(datetimediff.Minutes.ToString())).ToString();
                    }
                    remaining = datetimediff.Days.ToString() + "天"
                            + (int.Parse(datetimediff.Hours.ToString().ToString()) + 23).ToString() + "时"
                            + minutes + "分"
                            + (60 - int.Parse(datetimediff.Seconds.ToString())) + "秒";
                }
                else
                {
                    remaining = datetimediff.Days.ToString() + "天"
                            + datetimediff.Hours.ToString() + "时"
                            + datetimediff.Minutes.ToString() + "分"
                            + datetimediff.Seconds.ToString() + "秒";
                }
            }
            catch
            {
                return "Error";
            }
            return remaining;
        }
        #endregion

        #region RunningTime
        /// <summary>
        /// 计算时间差
        /// </summary>
        /// <param name="dt1">时间参数1</param>
        /// <param name="dt2">时间参数2</param>
        /// <returns></returns>
        public string RunningTime(DateTime dt1,DateTime dt2)
        {
            string runningTime = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(dt1.Ticks);
                TimeSpan ts2 = new TimeSpan(dt2.Ticks);
                TimeSpan datetimediff = ts1.Subtract(ts2).Duration();
                runningTime = datetimediff.Days.ToString() + "天"
                            + datetimediff.Hours.ToString() + "时"
                            + datetimediff.Minutes.ToString() + "分"
                            + datetimediff.Seconds.ToString() + "秒";
            }
            catch
            {
                return "Error";
            }
            return runningTime;
        }
        #endregion
    }
}
