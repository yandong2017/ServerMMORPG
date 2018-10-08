using System;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 获取标识
        /// </summary>
        /// <param name="_state"></param>
        /// <param name="_flag"></param>
        /// <returns></returns>
        public static bool GetState(long _state, long _flag)
        {
            return (_state & _flag) > 0;
        }

        /// <summary>
        /// 设置标识
        /// </summary>
        /// <param name="_state"></param>
        /// <param name="_flag"></param>
        public static long SetState(long _state, long _flag)
        {
            _state |= _flag;
            return _state;
        }

        /// <summary>
        /// 清除标识
        /// </summary>
        /// <param name="_state"></param>
        /// <param name="_flag"></param>
        public static long ClearState(long _state, long _flag)
        {
            _state &= ~_flag;
            return _state;
        }
        
        /// <summary>
        /// 输出一些反馈消息
        /// </summary>
        /// <param name="obj"></param>
        public static void Show(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{obj}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// 输出一些反馈消息
        /// </summary>
        /// <param name="obj"></param>
        public static void ShowError(object obj)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{obj}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// 输出一些反馈消息
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ex"></param>
        public static void ShowError(object obj, Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{obj}\n{ex.Message}\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// 获取64位唯一ID
        /// </summary>
        /// <returns></returns>
        public static long GUID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// 获取字符串唯一ID
        /// </summary>
        /// <returns></returns>
        public static string SGUID()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// 获取一个随时间递增的数 (14位)
        /// </summary>
        /// <returns></returns>
        public static long GuidIncreasing()
        {
            var ms = (long)(new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds);
            return (ms % 100_0000_0000_0000);
        }
        /// <summary>
        /// 获取一个随时间递减的数 (14位)
        /// </summary>
        /// <returns></returns>
        public static long GuidDescending()
        {
            var ms = (long)(new TimeSpan(DateTime.Now.Ticks).TotalMilliseconds);
            return ((long.MaxValue - ms) % 100_0000_0000_0000);
        }


        /// <summary>
        /// 获取一个简单验证码
        /// </summary>
        /// <returns></returns>
        public static long SimpleVerifyCode(long key = -1)
        {
            long result;
            DateTime dt = DateTime.Now;
            if (key == -1)
            {
                result = dt.Day;
            }
            else if (key == 0)
            {
                result = dt.Hour * dt.Minute;
            }
            else if (key < 100000000)
            {
                result = key * dt.Year * (dt.DayOfYear + 1);
            }
            else
            {
                result = (key / dt.Year) * (dt.DayOfYear + 1);
            }
            return result;
        }
        /// <summary>
        /// 交换
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static int GetDistance(int x1, int y1, int x2, int y2)
        {
            int width = x2 - x1;
            int height = y2 - y1;
            int result = (width * width) + (height * height);
            return (int)Math.Sqrt(result);
        }

    }
}