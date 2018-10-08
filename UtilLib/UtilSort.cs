
 

 
 

















using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace UtilLib
{
    /// <summary>
    /// 公共函数类  随机
    /// </summary>
    public static partial class Util
    {
        /// <summary>
        /// 排序 线性
        /// </summary>
        /// <param name="score">分数</param>
        /// <param name="rank">排名</param>
        /// <param name="rankStart">开始排名</param>
        /// <param name="rankEnd">最大排名</param>
        /// <param name="scoreStart">开始分数</param>
        /// <param name="scoreEnd">最小分数</param>
        /// <returns></returns>
        public static void CalculateLineRank(ref int rank, int score, int rankStart, int rankEnd, int scoreStart, int scoreEnd)
        {
            if (score <= scoreStart)
            {
                return;
            }
            if (rankEnd <= rankStart)
            {
                return;
            }
            if (scoreStart <= scoreEnd)
            {
                return;
            }
            int rankadd = 0;
            //排名差大于等于分差
            if ((rankEnd - rankStart) >= (scoreStart - scoreEnd))
            {
                rankadd = score - scoreStart;
            }
            else
            {
                float ratio = ((float)(scoreStart - scoreEnd)) / ((float)(rankEnd - rankStart));
                rankadd = (int)(((float)(score - scoreStart)) * ratio);
            }
            rank += rankadd;
        }
        
        /// <summary>
        /// 获取最近的一个大于值
        /// </summary>
        /// <param name="ll"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static int GetNearestEle(List<int> ll, int v)
        {
            int result = 0;
            foreach (var nn in ll)
            {
                if (nn > v)
                {
                    result = nn;
                    break;
                }
            }
            return result;
        }

        /// <summary>
        /// 移除 SortedDictionary 多余的元素 从头移除
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="dict"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static void SortedDictionaryRemoveFirst<T1, T2>(ref SortedDictionary<T1, T2> dict, int count)
        {
            while (dict.Count > count)
            {
                dict.Remove(dict.First().Key);
            }
        }

    }
}