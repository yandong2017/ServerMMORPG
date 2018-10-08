
 

 
 

















using System.Collections.Generic;
using System.Linq;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类  比率表抽取
    /// </summary>
    public class UtilRate<T>
    {
        /// <summary>
        /// 比率表
        /// </summary>
        public Dictionary<T, int> RateDic;

        /// <summary>
        /// RateDic:k是ID或者其他什么, v是万份比
        /// </summary>
        /// <param name="ratedic"></param>
        /// <param name="RateResetFlag"></param>
        public UtilRate(Dictionary<T, int> ratedic, bool RateResetFlag = true)
        {
            RateDic = new Dictionary<T, int>(ratedic);
            if (ratedic.Count > 100)
            {
                Util.ShowError("收取表大小不能超过100个，否则性能低");
            }
            if (RateResetFlag)
            {
                RateReset();
            }
        }

        /// <summary>
        /// 把超过的或者不足的,重新分配为万分之几
        /// </summary>
        public void RateReset()
        {
            var sum = RateDic.Values.Sum();
            if (RateDic.Count == 0)
            {
                return;
            }
            if (sum == 0)
            {
                var tmpkv = new Dictionary<T, int>();
                foreach (var node in RateDic)
                {
                    tmpkv[node.Key] = 1;
                }
            }
            double total比率 = sum / 10000d;

            var newkv = new Dictionary<T, int>();

            //大于1.0就是扩大,小于1.0就是缩小
            foreach (var node in RateDic)
            {
                newkv[node.Key] = (int)(node.Value / total比率);
            }
            RateDic = newkv;
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public T RateSingle()
        {
            var idx = Util.Random.Next(0, 10000);
            int curr = 0;
            T last = default(T);
            foreach (var node in RateDic)
            {
                curr += node.Value;
                if (idx <= curr)
                {
                    return node.Key;
                }
                last = node.Key;
            }
            return last;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public T[] RateMultiple(int count)
        {
            if (count >= RateDic.Count || count < 0)
            {
                return RateDic.Keys.ToArray();
            }
            if (count <= 0)
            {
                return new T[0];
            }
            T[] ret = new T[count];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = default(T);
            }

            int ratecount = 0;
            while (ratecount < count)
            {
                var dict = new Dictionary<T, int>();
                foreach (var node in RateDic)
                {
                    if (ret.Contains(node.Key)) { continue; }
                    dict[node.Key] = node.Value;
                }
                var next = new UtilRate<T>(dict);
                var k = next.RateSingle();
                ret[ratecount] = k;
                ratecount++;
            }

            return ret;
        }
    }
}