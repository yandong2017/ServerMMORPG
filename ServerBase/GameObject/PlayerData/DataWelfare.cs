/****************************************************************************
Copyright (c) 2014-2015 凌惊雪 微信:Lingjingxue 邮箱:lingjingxue@sina.com QQ:271487457

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
****************************************************************************/


using ServerBase.Protocol;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServerPublic.GameObject
{
    [Desc("玩家福利数据")]
    [DataContract]
    public class DataWelfare
    {
        [Desc("福利数据")]//key:类型
        [DataMember]
        public Dictionary<int, WelfareBase> DictWelfare = new Dictionary<int, WelfareBase>();

        //未领取的奖励数目
        public int WelfareAwardNum
        {
            get
            {
                int result = 0;
                foreach (var info in DictWelfare.Values)
                {
                    if (info.State == (int)ETaskState.已完成条件)
                    {
                        result++;
                    }
                }
                return result;
            }
        }
    }

    [Desc("单条福利数据")]
    [DataContract]
    public class WelfareBase
    {
        [Desc("ID(配置ID)")]
        [DataMember]
        public int Id = 0;
        [Desc("当前进度")]
        [DataMember]
        public int Schedule = 0;
        [Desc("当前状态 EWelfareState")]
        [DataMember]
        public int State = 0;
    }
}