using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerBase
{
    public enum ELogLevel
    {
        // 调试
        Debug = 1,
        // 常规信息
        Info = 2,
        // 警告
        Warn = 3,
        // 错误
        Error = 4,
        // 严重错误
        Fatal = 5,
        // 仅显示调试
        OnlyDebug = 6,
        // 不显示
        None = 7,
    }

    public class Loger
    {
        /// <summary>
        /// 文件日志
        /// </summary>
        private static ILog m_logFile = null;

        /// <summary>
        /// 命令行日志
        /// </summary>
        private static ILog m_logConsole = null;

        /// <summary>
        /// 日志等级
        /// </summary>
        private static ELogLevel m_logLevel = ELogLevel.Debug;

        /// <summary>
        /// 初始化日志文件
        /// </summary>
        public static void CreateLoger()
        {
            if (m_logFile == null)
            {
                m_logFile = log4net.LogManager.Exists("log_file");
            }
            if (m_logConsole == null)
            {
                m_logConsole = log4net.LogManager.Exists("log_console");
            }
        }

        /// <summary>
        /// 获取日志等级
        /// </summary>
        /// <returns></returns>
        public static ELogLevel GetLevel()
        {
            return m_logLevel;
        }

        /// <summary>
        /// 修改日志等级
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static ELogLevel ChangeLevel(int level)
        {
            return ChangeLevel((ELogLevel)level);
        }

        /// <summary>
        /// 修改日志等级
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static ELogLevel ChangeLevel(ELogLevel level)
        {
            if (level >= ELogLevel.Debug && level <= ELogLevel.None)
            {
                m_logLevel = level;
            }
            else
            {
                m_logLevel = ELogLevel.None;
            }
            return m_logLevel;
        }

        /// <summary>
        /// 判断是否debug
        /// </summary>
        /// <returns></returns>
        public static bool IsDebug()
        {
            return (m_logLevel >= ELogLevel.Debug);
        }

        /// <summary>
        /// 修改日志等级 外网发布版本
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public static ELogLevel ChangeLevelRelease()
        {
            return ChangeLevel(ELogLevel.Warn);
        }


        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">标题</param>
        /// <param name="ex">异常</param>
        public static void Debug(object titlname, Exception ex)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Green;
            if (m_logFile == null) return;
            if (m_logFile.IsDebugEnabled)
            {
                m_logFile.Debug(titlname, ex);
            }
            if ((m_logConsole.IsDebugEnabled && m_logLevel <= ELogLevel.Debug) || m_logLevel == ELogLevel.OnlyDebug)
            {
                m_logConsole.Debug(titlname, ex);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">信息</param>
        public static void Debug(object titlname)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Green;
            if (m_logFile == null) return;
            if (m_logFile.IsDebugEnabled)
            {
                m_logFile.Debug(titlname);
            }
            if ((m_logConsole.IsDebugEnabled && m_logLevel <= ELogLevel.Debug) || m_logLevel == ELogLevel.OnlyDebug)
            {
                m_logConsole.Debug(titlname);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">标题</param>
        /// <param name="ex">异常</param>
        public static void Info(object titlname, Exception ex)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (m_logFile == null) return;
            if (m_logFile.IsInfoEnabled)
            {
                m_logFile.Info(titlname, ex);
            }
            if (m_logConsole.IsInfoEnabled && m_logLevel <= ELogLevel.Info)
            {
                m_logConsole.Info(titlname, ex);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">信息</param>
        public static void Info(object titlname)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (m_logFile == null) return;
            if (m_logFile.IsInfoEnabled)
            {
                m_logFile.Info(titlname);
            }
            if (m_logConsole.IsInfoEnabled && m_logLevel <= ELogLevel.Info)
            {
                m_logConsole.Info(titlname);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">标题</param>
        /// <param name="ex">异常</param>
        public static void Warn(object titlname, Exception ex)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (m_logFile == null) return;
            if (m_logFile.IsWarnEnabled)
            {
                m_logFile.Warn(titlname, ex);
            }
            if (m_logConsole.IsWarnEnabled && m_logLevel <= ELogLevel.Warn)
            {
                m_logConsole.Warn(titlname, ex);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">信息</param>
        public static void Warn(object titlname)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Magenta;
            if (m_logFile == null) return;
            if (m_logFile.IsWarnEnabled)
            {
                m_logFile.Warn(titlname);
            }
            if (m_logConsole.IsWarnEnabled && m_logLevel <= ELogLevel.Warn)
            {
                m_logConsole.Warn(titlname);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">标题</param>
        /// <param name="ex">异常</param>
        public static void Error(object titlname, Exception ex)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (m_logFile == null)
            {
                Console.WriteLine(titlname);
                return;
            }
            if (m_logFile.IsErrorEnabled)
            {
                m_logFile.Error(titlname, ex);
            }
            if (m_logConsole.IsErrorEnabled && m_logLevel <= ELogLevel.Error)
            {
                m_logConsole.Error(titlname, ex);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">信息</param>
        public static void Error(object titlname)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (m_logFile == null)
            {
                Console.WriteLine(titlname);
                return;
            }
            if (m_logFile.IsErrorEnabled)
            {
                m_logFile.Error(titlname);
            }
            if (m_logConsole.IsErrorEnabled && m_logLevel <= ELogLevel.Error)
            {
                m_logConsole.Error(titlname);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">标题</param>
        /// <param name="ex">异常</param>
        public static void Fatal(object titlname, Exception ex)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Red;
            if (m_logFile == null)
            {
                Console.WriteLine(titlname);
                return;
            }
            if (m_logFile.IsFatalEnabled)
            {
                m_logFile.Fatal(titlname, ex);
            }
            if (m_logConsole.IsFatalEnabled && m_logLevel <= ELogLevel.Fatal)
            {
                m_logConsole.Fatal(titlname, ex);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// BUG日志输出
        /// </summary>
        /// <param name="titlname">信息</param>
        public static void Fatal(object titlname)
        {
            CreateLoger();
            Console.ForegroundColor = ConsoleColor.Red;
            if (m_logFile == null)
            {
                Console.WriteLine(titlname);
                return;
            }
            if (m_logFile.IsFatalEnabled)
            {
                m_logFile.Fatal(titlname);
            }
            if (m_logConsole.IsFatalEnabled && m_logLevel <= ELogLevel.Fatal)
            {
                m_logConsole.Fatal(titlname);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
