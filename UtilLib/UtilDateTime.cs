
 

 
 

















using System;
using System.Diagnostics;
using System.Globalization;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类  时间部分 
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 获取本周最后一天日期
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTimeOfWeekend()
        {
            var result = DateTime.Now;
            result = result.AddDays(7 + (int)DayOfWeek.Sunday - (int)result.DayOfWeek);
            return result;
        }

        #region 调试处理时间

        /// <summary>
        /// 处理时间显示
        /// </summary>
        public static Stopwatch BenchmarkStopwatch;
        /// <summary>
        /// 处理对象
        /// </summary>
        public static string BenchmarkMode = "";
        /// <summary>
        /// 开始处理
        /// </summary>
        /// <param name="mode">处理对象</param>
        public static void BenchmarkStart(string mode = "执行时间")
        {
            BenchmarkMode = mode;
            Show($"处理 <{BenchmarkMode}>。。。。。。开始。。。。。。");
            BenchmarkStopwatch = Stopwatch.StartNew();
        }
        /// <summary>
        /// 结束处理
        /// </summary>
        public static void BenchmarkEnd()
        {
            if (BenchmarkStopwatch == null)
            {
                return;
            }
            BenchmarkStopwatch.Stop();
            Show($"处理 <{BenchmarkMode}>。。。。。。完毕，耗时 {BenchmarkStopwatch.ElapsedMilliseconds} 毫秒 。");
        }
        /// <summary>
        /// 用来测试执行时间
        /// </summary>
        /// <param name="warmupIterations">热身次数</param>
        /// <param name="benchmarkIterations">执行次数</param>
        /// <param name="action"></param>
        public static void RunBenchmark(int warmupIterations, int benchmarkIterations, Action action)
        {
            Console.WriteLine("Warmup iterations: {0}", warmupIterations);
            for (int i = 0; i < warmupIterations; i++)
            {
                action();
            }

            Console.WriteLine("Benchmark iterations: {0}", benchmarkIterations);
            var stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < benchmarkIterations; i++)
            {
                action();
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed time: {0}ms", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Ops per second: {0}", (int)((double)benchmarkIterations * 1000 / stopwatch.ElapsedMilliseconds));
        }

        #endregion

    }
}