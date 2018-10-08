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


using ServerBase.Config;
using ServerBase.Protocol;
using ServerBase.BaseManagers;
using ServerBase.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using static ServerBase.Config.Conf;
using UtilLib;
using ServerBase.ServerLoger;
using ServerBase.BaseObjects;
using ServerPublic.GameObject;

namespace ServerPublic.GameObject
{
    [Desc("玩家主角数据")]
    [DataContract]
    public class DataRole
    {
        [Desc("当前生命")]
        [DataMember]
        public int CurrentHp = 10;

        [Desc("技能列表")] //<SkillId, Skill>
        [DataMember]
        public Dictionary<int, Skill> DictSkill = new Dictionary<int, Skill>();

        [Desc("天赋列表")] //<TalentId>
        [DataMember]
        public Dictionary<int,int> DicTalent = new Dictionary<int,int>();

        [Desc("技能装备列表")] //<SlotId, SkillId>
        [DataMember]
        public Dictionary<int, int> DictSkilled = new Dictionary<int, int>();

        [Desc("已装备列表")] //<SlotId, Equip>(SlotId=EEquipType)
        [DataMember]
        public Dictionary<int, Equip> DictEquiped = new Dictionary<int, Equip>();

        //对战备份血量
        public int OldHp = 0;

        // 构造函数
        public DataRole()
        {
            try
            {
                foreach (var configlist in ConfTalentExt)
                {
                    DicTalent[configlist.Key] = configlist.Value[0].Id;
                }
            }
            catch
            {
                loger.Error("构造函数 DataRole 出错");
            }
        }
        
        //获取天赋类型所有值
        public int GetTalentValue(int type)
        {
            int result = 0;
            foreach (var kvp in ConfTalentExt)
            {
                if (!DicTalent.ContainsKey(kvp.Key))
                {
                    DicTalent[kvp.Key] = kvp.Value[0].Id;
                }
                int ScienceId = DicTalent[kvp.Key];
                var conf = ConfTalent[ScienceId];
                if(conf.TalentType==type)
                {
                    result += conf.Value;
                }               
            }      
            return result;
        }

        //天赋总等级
        public int GetTalentLevelTotal()
        {
            var result = 0;
            foreach (var item in DicTalent.Values)
            {
                if (ConfTalent.TryGetValue(item, out var talent))
                {
                    result += talent.Level;
                }
            }
            return result;
        }

    }
}