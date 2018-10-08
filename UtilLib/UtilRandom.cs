
 

 
 

















using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类  随机
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 随机种子
        /// </summary>
        public static Random Random = new Random(Environment.TickCount);
        /// <summary>
        /// 
        /// </summary>
        public static void RandomReset()
        {
            Random = new Random(Environment.TickCount);
        }

        /// <summary>
        /// 生成指定范围内的不重复随机数
        /// </summary>
        /// <param name="count">随机数个数</param>
        /// <param name="minNum">随机数下限（随机数可以取该下界值）</param>
        /// <param name="maxNum">随机数上限（随机数不能取该上界值）</param>
        /// <returns></returns>
        public static int[] RandomMultiple(int count, int minNum, int maxNum)
        {
            int[] result = new int[count];
#if true
            //方法2：利用Hashtable。
            if (maxNum >= minNum)
            {
                Hashtable hashtable = new Hashtable();
                for (int i = 0; hashtable.Count < count; i++)
                {
                    int nValue = Random.Next(minNum, maxNum);
                    if (!hashtable.ContainsValue(nValue))
                    {
                        result[hashtable.Count] = nValue;
                        hashtable.Add(nValue, nValue);
                    }
                }
            }
#else
            //方法1：思想是用一个数组来保存索引号，先随机生成一个数组位置，然后把随机抽取到的位置的索引号取出来，并把最后一个索引号复制到当前的数组位置，然后使随机数的上限减一，具体如：先把这100个数放在一个数组内，每次随机取一个位置（第一次是1-100，第二次是1-99，...），将该位置的数用最后的数代替。
            int j;
            for (j = 0; j < count; j++)
            {
                int i = Rd.Next(minNum, maxNum);
                int num = 0;
                for (int k = 0; k < j; k++)
                {
                    if (result[k] == i)
                    {
                        num = num + 1;
                    }
                }
                if (num == 0)
                {
                    result[j] = i;
                }
                else
                {
                    j = j - 1;
                }
            }
#endif
            return result;
        }

        
    }
}