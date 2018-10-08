
 

 
 

















using System.Collections.Generic;
using System.Linq;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类  Dictionary 嵌套 List
    /// </summary>
    public class DictList<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        /// <summary>
        /// 
        /// </summary>
        public DictList() 
            : base()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <param name="newList"></param>
        /// <returns></returns>
        public bool TryGetValues(TKey key, out List<TValue> values, bool newList = true)
        {
            bool result = TryGetValue(key, out values);
            if (newList && !result)
            {
                values = new List<TValue>();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value)
        {
            if (!TryGetValues(key, out var values))
            {
                base.Add(key, values);
            }
            values.Add(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool ContainsValue(TKey key, TValue value)
        {
            if (TryGetValue(key, out var values))
            {
                return values.Contains(value);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(TKey key, TValue value)
        {
            if (TryGetValue(key, out var values))
            {
                return values.Remove(value);
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        public void Merge(DictList<TKey, TValue> other)
        {
            if (other == null)
            {
                return;
            }
            foreach (var kvp in other)
            {
                foreach (var value in kvp.Value)
                {
                    this.Add(kvp.Key, value);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetIndexValue(TKey key, int index, out TValue value)
        {
            try
            {
                value = base[key][index];
                return true;
            }
            catch
            {
                value = default(TValue);
                return false;
            }
        }

    }
}