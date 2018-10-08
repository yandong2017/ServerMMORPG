
 

 
 

















using System.Collections.Generic;
using System.Linq;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类  Dictionary 嵌套 Dictionary
    /// </summary>
    public class DictDict<TKeyBase, TKey, TValue> : Dictionary<TKeyBase, Dictionary<TKey, TValue>>
    {
        /// <summary>
        /// 
        /// </summary>
        public DictDict() 
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keybase"></param>
        /// <param name="values"></param>
        /// <param name="newDict"></param>
        /// <returns></returns>
        public bool TryGetValues(TKeyBase keybase, out Dictionary<TKey, TValue> values, bool newDict = true)
        {
            bool result = TryGetValue(keybase, out values);
            if (newDict && !result)
            {
                values = new Dictionary<TKey, TValue>();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keybase"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKeyBase keybase, TKey key, TValue value)
        {
            if (!TryGetValues(keybase, out var values))
            {
                base.Add(keybase, values);
            }
            values[key] = value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keybase"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValueValue(TKeyBase keybase, TKey key, out TValue value)
        {
            if (TryGetValues(keybase, out var values))
            {
                return values.TryGetValue(key, out value);
            }
            value = default(TValue);
            return false;
        }

    }
}