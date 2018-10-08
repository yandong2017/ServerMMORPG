using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类  递归检查类并初始化    
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 检查数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="Attribute"> 筛选的属性，为null则不筛选 </param>
        /// <returns></returns>
        public static bool CheckInitObj<T>(ref T obj, Type Attribute = null)
        {
            bool HasInit = false;
            foreach (var fieldInfo in obj.GetType().GetFields())
            {
                //筛选出需要序列化而且是类的字段
                if (!fieldInfo.FieldType.IsClass)
                {
                    continue;
                }
                if (Attribute != null && fieldInfo.GetCustomAttribute(Attribute) == null)
                {
                    continue;
                }
                var value = fieldInfo.GetValue(obj);
                if (value == null)
                {
                    try
                    {
                        //字符串比较特殊
                        if (fieldInfo.FieldType.IsAnsiClass)
                        {
                            fieldInfo.SetValue(obj, "");
                        }
                        else
                        {
                            object o = Activator.CreateInstance(fieldInfo.FieldType);
                            fieldInfo.SetValue(obj, o);
                        }
                        HasInit = true;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    HasInit = HasInit || CheckInitObj(ref value, Attribute);
                }
            }
            return HasInit;
        }
    }
}
