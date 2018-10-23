
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    public enum EProtocolResult
    {
        成功 = 0,
        失败 = 1,
        异常 = 2,
        服务器异常 = 10,
        服务器数据库异常 = 11,
        服务器配置文件异常 = 12,
        游戏服务器未开启 = 13,
        账号不存在 = 14,
        密码错误 = 15,
        账号已存在 = 16,
    };

    public enum ERecordType
    {
        注册游戏 = 1,
        登录游戏 = 2,
        退出游戏 = 3,
        管理员登陆 = 20,
    };

    public enum EActionSource
    {
        系统 = 0,
        GM = 10,
    };

    public enum EnumBaseDemo
    {
        demo0 = 1,
        demo1 = 2,
    };


}

