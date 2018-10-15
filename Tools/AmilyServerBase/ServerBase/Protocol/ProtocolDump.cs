
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System.Text;
using ServerBase.BaseManagers;

namespace ServerBase.Protocol
{
    public static class ProtocolDump
    {
        public static string Dump(EProtocolId id, byte[] buffer)
        {
            var sb = new StringBuilder();
            switch (id)
            {
                case EProtocolId.ALL_BASE_DEMO:
                    var Rsp1 = new All_Base_Demo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp1));
                    break;
                case EProtocolId.ALL_BASE_RESULT:
                    var Rsp2 = new All_Base_Result(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp2));
                    break;
                case EProtocolId.ALL_BASE_PING:
                    var Rsp3 = new All_Base_Ping(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp3));
                    break;
                case EProtocolId.ALL_BASE_GAMEVERSION:
                    var Rsp4 = new All_Base_GameVersion(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp4));
                    break;
                case EProtocolId.C2G_DEBUG_CMD:
                    var Rsp5 = new C2G_Debug_Cmd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp5));
                    break;
                case EProtocolId.G2C_DEBUG_CMD:
                    var Rsp6 = new G2C_Debug_Cmd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp6));
                    break;
                case EProtocolId.G2C_LOGIN_CONNECT:
                    var Rsp7 = new G2C_Login_Connect(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp7));
                    break;
                case EProtocolId.C2L_LOGIN_USERLOGIN:
                    var Rsp8 = new C2L_Login_UserLogin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp8));
                    break;
                case EProtocolId.L2C_LOGIN_USERLOGIN:
                    var Rsp9 = new L2C_Login_UserLogin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp9));
                    break;
                case EProtocolId.C2G_LOGIN_PLAYERLOGIN:
                    var Rsp10 = new C2G_Login_PlayerLogin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp10));
                    break;
                case EProtocolId.G2C_LOGIN_PLAYERLOGIN:
                    var Rsp11 = new G2C_Login_PlayerLogin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp11));
                    break;
                case EProtocolId.C2G_LOGIN_PLAYERCREATE:
                    var Rsp12 = new C2G_Login_PlayerCreate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp12));
                    break;
                case EProtocolId.G2C_LOGIN_PLAYERCREATE:
                    var Rsp13 = new G2C_Login_PlayerCreate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp13));
                    break;
                case EProtocolId.G2C_LOGIN_REPLACED:
                    var Rsp14 = new G2C_Login_Replaced(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp14));
                    break;
                case EProtocolId.G2C_LOGIN_BAN:
                    var Rsp15 = new G2C_Login_Ban(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp15));
                    break;
                case EProtocolId.C2G_LOGIN_LISTSTATE:
                    var Rsp16 = new C2G_Login_ListState(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp16));
                    break;
                case EProtocolId.G2C_LOGIN_LISTSTATE:
                    var Rsp17 = new G2C_Login_ListState(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp17));
                    break;
                case EProtocolId.C2G_LOGIN_CHECKNAME:
                    var Rsp18 = new C2G_Login_CheckName(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp18));
                    break;
                case EProtocolId.G2C_LOGIN_CHECKNAME:
                    var Rsp19 = new G2C_Login_CheckName(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp19));
                    break;
                case EProtocolId.C2G_INFO_GETALL:
                    var Rsp20 = new C2G_Info_GetAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp20));
                    break;
                case EProtocolId.G2C_INFO_GETALL:
                    var Rsp21 = new G2C_Info_GetAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp21));
                    break;
                case EProtocolId.G2C_INFO_PUSHALL:
                    var Rsp22 = new G2C_Info_PushAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp22));
                    break;
                case EProtocolId.G2C_INFO_PUSHITEM:
                    var Rsp23 = new G2C_Info_PushItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp23));
                    break;
                case EProtocolId.G2C_INFO_PUSHEQUIP:
                    var Rsp24 = new G2C_Info_PushEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp24));
                    break;
                case EProtocolId.G2C_INFO_PUSHWARRIOR:
                    var Rsp25 = new G2C_Info_PushWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp25));
                    break;
                case EProtocolId.G2C_INFO_PUSHUPDATE:
                    var Rsp26 = new G2C_Info_PushUpdate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp26));
                    break;
                case EProtocolId.C2G_INFO_CHANGENAME:
                    var Rsp27 = new C2G_Info_ChangeName(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp27));
                    break;
                case EProtocolId.G2C_INFO_CHANGENAME:
                    var Rsp28 = new G2C_Info_ChangeName(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp28));
                    break;
                case EProtocolId.C2G_INFO_CHANGEFLAGCLIENT:
                    var Rsp29 = new C2G_Info_ChangeFlagClient(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp29));
                    break;
                case EProtocolId.G2C_INFO_CHANGEFLAGCLIENT:
                    var Rsp30 = new G2C_Info_ChangeFlagClient(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp30));
                    break;
                case EProtocolId.C2G_INFO_CHANGEHEADINDEX:
                    var Rsp31 = new C2G_Info_ChangeHeadIndex(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp31));
                    break;
                case EProtocolId.G2C_INFO_CHANGEHEADINDEX:
                    var Rsp32 = new G2C_Info_ChangeHeadIndex(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp32));
                    break;
                case EProtocolId.C2G_INFO_CHANGEHEADDATA:
                    var Rsp33 = new C2G_Info_ChangeHeadData(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp33));
                    break;
                case EProtocolId.G2C_INFO_CHANGEHEADDATA:
                    var Rsp34 = new G2C_Info_ChangeHeadData(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp34));
                    break;
                case EProtocolId.C2G_INFO_SUBMITBUG:
                    var Rsp35 = new C2G_Info_SubmitBug(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp35));
                    break;
                case EProtocolId.G2C_INFO_SUBMITBUG:
                    var Rsp36 = new G2C_Info_SubmitBug(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp36));
                    break;
                case EProtocolId.G2C_INFO_NOTIFYLEVELUP:
                    var Rsp37 = new G2C_Info_NotifyLevelUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp37));
                    break;
                case EProtocolId.C2G_INFO_PLAYERDATA:
                    var Rsp38 = new C2G_Info_PlayerData(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp38));
                    break;
                case EProtocolId.G2C_INFO_PLAYERDATA:
                    var Rsp39 = new G2C_Info_PlayerData(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp39));
                    break;
                case EProtocolId.C2G_INFO_CHANGESIGNATURE:
                    var Rsp40 = new C2G_Info_ChangeSignature(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp40));
                    break;
                case EProtocolId.G2C_INFO_CHANGESIGNATURE:
                    var Rsp41 = new G2C_Info_ChangeSignature(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp41));
                    break;
                case EProtocolId.C2G_NOTICE_SYSTEM:
                    var Rsp42 = new C2G_Notice_System(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp42));
                    break;
                case EProtocolId.G2C_NOTICE_SYSTEM:
                    var Rsp43 = new G2C_Notice_System(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp43));
                    break;
                case EProtocolId.C2G_NOTICE_ACTIVITY:
                    var Rsp44 = new C2G_Notice_Activity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp44));
                    break;
                case EProtocolId.G2C_NOTICE_ACTIVITY:
                    var Rsp45 = new G2C_Notice_Activity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp45));
                    break;
                case EProtocolId.G2C_NOTICE_ROLLING:
                    var Rsp46 = new G2C_Notice_Rolling(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp46));
                    break;
                case EProtocolId.C2G_MAIL_LIST:
                    var Rsp47 = new C2G_Mail_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp47));
                    break;
                case EProtocolId.G2C_MAIL_LIST:
                    var Rsp48 = new G2C_Mail_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp48));
                    break;
                case EProtocolId.C2G_MAIL_READ:
                    var Rsp49 = new C2G_Mail_Read(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp49));
                    break;
                case EProtocolId.G2C_MAIL_READ:
                    var Rsp50 = new G2C_Mail_Read(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp50));
                    break;
                case EProtocolId.C2G_MAIL_GET:
                    var Rsp51 = new C2G_Mail_Get(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp51));
                    break;
                case EProtocolId.G2C_MAIL_GET:
                    var Rsp52 = new G2C_Mail_Get(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp52));
                    break;
                case EProtocolId.C2G_MAIL_GETALL:
                    var Rsp53 = new C2G_Mail_GetAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp53));
                    break;
                case EProtocolId.G2C_MAIL_GETALL:
                    var Rsp54 = new G2C_Mail_GetAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp54));
                    break;
                case EProtocolId.C2G_MAIL_DELETE:
                    var Rsp55 = new C2G_Mail_Delete(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp55));
                    break;
                case EProtocolId.G2C_MAIL_DELETE:
                    var Rsp56 = new G2C_Mail_Delete(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp56));
                    break;
                case EProtocolId.C2G_MAIL_DELETEREADED:
                    var Rsp57 = new C2G_Mail_DeleteReaded(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp57));
                    break;
                case EProtocolId.G2C_MAIL_DELETEREADED:
                    var Rsp58 = new G2C_Mail_DeleteReaded(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp58));
                    break;
                case EProtocolId.C2G_MAIL_SAVE:
                    var Rsp59 = new C2G_Mail_Save(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp59));
                    break;
                case EProtocolId.G2C_MAIL_SAVE:
                    var Rsp60 = new G2C_Mail_Save(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp60));
                    break;
                case EProtocolId.C2G_MAIL_SEND:
                    var Rsp61 = new C2G_Mail_Send(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp61));
                    break;
                case EProtocolId.G2C_MAIL_SEND:
                    var Rsp62 = new G2C_Mail_Send(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp62));
                    break;
                case EProtocolId.C2G_CHAT_SEND:
                    var Rsp63 = new C2G_Chat_Send(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp63));
                    break;
                case EProtocolId.G2C_CHAT_SEND:
                    var Rsp64 = new G2C_Chat_Send(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp64));
                    break;
                case EProtocolId.G2C_CHAT_RECEIVE:
                    var Rsp65 = new G2C_Chat_Receive(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp65));
                    break;
                case EProtocolId.C2G_CHAT_GETPRIVATECHAT:
                    var Rsp66 = new C2G_Chat_GetPrivateChat(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp66));
                    break;
                case EProtocolId.G2C_CHAT_GETPRIVATECHAT:
                    var Rsp67 = new G2C_Chat_GetPrivateChat(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp67));
                    break;
                case EProtocolId.C2G_CHAT_REMOVE:
                    var Rsp68 = new C2G_Chat_Remove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp68));
                    break;
                case EProtocolId.G2C_CHAT_REMOVE:
                    var Rsp69 = new G2C_Chat_Remove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp69));
                    break;
                case EProtocolId.C2G_FRIEND_LIST:
                    var Rsp70 = new C2G_Friend_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp70));
                    break;
                case EProtocolId.G2C_FRIEND_LIST:
                    var Rsp71 = new G2C_Friend_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp71));
                    break;
                case EProtocolId.C2G_FRIEND_LISTAPPLY:
                    var Rsp72 = new C2G_Friend_ListApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp72));
                    break;
                case EProtocolId.G2C_FRIEND_LISTAPPLY:
                    var Rsp73 = new G2C_Friend_ListApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp73));
                    break;
                case EProtocolId.C2G_FRIEND_LISTRECOMMEND:
                    var Rsp74 = new C2G_Friend_ListRecommend(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp74));
                    break;
                case EProtocolId.G2C_FRIEND_LISTRECOMMEND:
                    var Rsp75 = new G2C_Friend_ListRecommend(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp75));
                    break;
                case EProtocolId.C2G_FRIEND_APPLY:
                    var Rsp76 = new C2G_Friend_Apply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp76));
                    break;
                case EProtocolId.G2C_FRIEND_APPLY:
                    var Rsp77 = new G2C_Friend_Apply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp77));
                    break;
                case EProtocolId.C2G_FRIEND_ADD:
                    var Rsp78 = new C2G_Friend_Add(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp78));
                    break;
                case EProtocolId.G2C_FRIEND_ADD:
                    var Rsp79 = new G2C_Friend_Add(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp79));
                    break;
                case EProtocolId.C2G_FRIEND_REMOVE:
                    var Rsp80 = new C2G_Friend_Remove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp80));
                    break;
                case EProtocolId.G2C_FRIEND_REMOVE:
                    var Rsp81 = new G2C_Friend_Remove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp81));
                    break;
                case EProtocolId.C2G_FRIEND_GIVE:
                    var Rsp82 = new C2G_Friend_Give(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp82));
                    break;
                case EProtocolId.G2C_FRIEND_GIVE:
                    var Rsp83 = new G2C_Friend_Give(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp83));
                    break;
                case EProtocolId.C2G_FRIEND_RECEIVE:
                    var Rsp84 = new C2G_Friend_Receive(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp84));
                    break;
                case EProtocolId.G2C_FRIEND_RECEIVE:
                    var Rsp85 = new G2C_Friend_Receive(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp85));
                    break;
                case EProtocolId.C2G_FRIEND_SCREEN:
                    var Rsp86 = new C2G_Friend_Screen(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp86));
                    break;
                case EProtocolId.G2C_FRIEND_SCREEN:
                    var Rsp87 = new G2C_Friend_Screen(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp87));
                    break;
                case EProtocolId.C2G_MAP_LISTCITY:
                    var Rsp88 = new C2G_Map_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp88));
                    break;
                case EProtocolId.G2C_MAP_LISTCITY:
                    var Rsp89 = new G2C_Map_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp89));
                    break;
                case EProtocolId.C2G_MAP_CITYINFO:
                    var Rsp90 = new C2G_Map_CityInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp90));
                    break;
                case EProtocolId.G2C_MAP_CITYINFO:
                    var Rsp91 = new G2C_Map_CityInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp91));
                    break;
                case EProtocolId.C2G_MAP_LISTMYCITY:
                    var Rsp92 = new C2G_Map_ListMyCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp92));
                    break;
                case EProtocolId.G2C_MAP_LISTMYCITY:
                    var Rsp93 = new G2C_Map_ListMyCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp93));
                    break;
                case EProtocolId.C2G_ITEM_LIST:
                    var Rsp94 = new C2G_Item_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp94));
                    break;
                case EProtocolId.G2C_ITEM_LIST:
                    var Rsp95 = new G2C_Item_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp95));
                    break;
                case EProtocolId.C2G_ITEM_SELL:
                    var Rsp96 = new C2G_Item_Sell(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp96));
                    break;
                case EProtocolId.G2C_ITEM_SELL:
                    var Rsp97 = new G2C_Item_Sell(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp97));
                    break;
                case EProtocolId.C2G_ITEM_USE:
                    var Rsp98 = new C2G_Item_Use(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp98));
                    break;
                case EProtocolId.G2C_ITEM_USE:
                    var Rsp99 = new G2C_Item_Use(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp99));
                    break;
                case EProtocolId.C2G_ITEM_RESOURCESLIST:
                    var Rsp100 = new C2G_Item_ResourcesList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp100));
                    break;
                case EProtocolId.G2C_ITEM_RESOURCESLIST:
                    var Rsp101 = new G2C_Item_ResourcesList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp101));
                    break;
                case EProtocolId.C2G_ITEM_RESOURCESUSE:
                    var Rsp102 = new C2G_Item_ResourcesUse(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp102));
                    break;
                case EProtocolId.G2C_ITEM_RESOURCESUSE:
                    var Rsp103 = new G2C_Item_ResourcesUse(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp103));
                    break;
                case EProtocolId.C2G_ITEM_RESOURCESBUY:
                    var Rsp104 = new C2G_Item_ResourcesBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp104));
                    break;
                case EProtocolId.G2C_ITEM_RESOURCESBUY:
                    var Rsp105 = new G2C_Item_ResourcesBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp105));
                    break;
                case EProtocolId.C2G_ITEM_COMBATUSE:
                    var Rsp106 = new C2G_Item_CombatUse(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp106));
                    break;
                case EProtocolId.G2C_ITEM_COMBATUSE:
                    var Rsp107 = new G2C_Item_CombatUse(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp107));
                    break;
                case EProtocolId.C2G_EQUIP_LIST:
                    var Rsp108 = new C2G_Equip_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp108));
                    break;
                case EProtocolId.G2C_EQUIP_LIST:
                    var Rsp109 = new G2C_Equip_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp109));
                    break;
                case EProtocolId.C2G_EQUIP_WARRIORLIST:
                    var Rsp110 = new C2G_Equip_WarriorList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp110));
                    break;
                case EProtocolId.G2C_EQUIP_WARRIORLIST:
                    var Rsp111 = new G2C_Equip_WarriorList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp111));
                    break;
                case EProtocolId.C2G_EQUIP_WARRIORALL:
                    var Rsp112 = new C2G_Equip_WarriorAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp112));
                    break;
                case EProtocolId.G2C_EQUIP_WARRIORALL:
                    var Rsp113 = new G2C_Equip_WarriorAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp113));
                    break;
                case EProtocolId.C2G_EQUIP_WARRIORWIELD:
                    var Rsp114 = new C2G_Equip_WarriorWield(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp114));
                    break;
                case EProtocolId.G2C_EQUIP_WARRIORWIELD:
                    var Rsp115 = new G2C_Equip_WarriorWield(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp115));
                    break;
                case EProtocolId.C2G_EQUIP_WARRIORREMOVE:
                    var Rsp116 = new C2G_Equip_WarriorRemove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp116));
                    break;
                case EProtocolId.G2C_EQUIP_WARRIORREMOVE:
                    var Rsp117 = new G2C_Equip_WarriorRemove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp117));
                    break;
                case EProtocolId.C2G_EQUIP_WARRIORRESOLVE:
                    var Rsp118 = new C2G_Equip_WarriorResolve(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp118));
                    break;
                case EProtocolId.G2C_EQUIP_WARRIORRESOLVE:
                    var Rsp119 = new G2C_Equip_WarriorResolve(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp119));
                    break;
                case EProtocolId.C2G_EQUIP_RENAME:
                    var Rsp120 = new C2G_Equip_Rename(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp120));
                    break;
                case EProtocolId.G2C_EQUIP_RENAME:
                    var Rsp121 = new G2C_Equip_Rename(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp121));
                    break;
                case EProtocolId.C2G_EQUIP_INTENSIFYINFO:
                    var Rsp122 = new C2G_Equip_IntensifyInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp122));
                    break;
                case EProtocolId.G2C_EQUIP_INTENSIFYINFO:
                    var Rsp123 = new G2C_Equip_IntensifyInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp123));
                    break;
                case EProtocolId.C2G_EQUIP_INTENSIFY:
                    var Rsp124 = new C2G_Equip_Intensify(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp124));
                    break;
                case EProtocolId.G2C_EQUIP_INTENSIFY:
                    var Rsp125 = new G2C_Equip_Intensify(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp125));
                    break;
                case EProtocolId.C2G_WARRIOR_WARRIORLIST:
                    var Rsp126 = new C2G_Warrior_WarriorList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp126));
                    break;
                case EProtocolId.G2C_WARRIOR_WARRIORLIST:
                    var Rsp127 = new G2C_Warrior_WarriorList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp127));
                    break;
                case EProtocolId.C2G_WARRIOR_LOCK:
                    var Rsp128 = new C2G_Warrior_Lock(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp128));
                    break;
                case EProtocolId.G2C_WARRIOR_LOCK:
                    var Rsp129 = new G2C_Warrior_Lock(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp129));
                    break;
                case EProtocolId.C2G_WARRIOR_ADVANCE:
                    var Rsp130 = new C2G_Warrior_Advance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp130));
                    break;
                case EProtocolId.G2C_WARRIOR_ADVANCE:
                    var Rsp131 = new G2C_Warrior_Advance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp131));
                    break;
                case EProtocolId.C2G_WARRIOR_RENAME:
                    var Rsp132 = new C2G_Warrior_Rename(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp132));
                    break;
                case EProtocolId.G2C_WARRIOR_RENAME:
                    var Rsp133 = new G2C_Warrior_Rename(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp133));
                    break;
                case EProtocolId.C2G_WARRIOR_UPLEVEL:
                    var Rsp134 = new C2G_Warrior_UpLevel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp134));
                    break;
                case EProtocolId.G2C_WARRIOR_UPLEVEL:
                    var Rsp135 = new G2C_Warrior_UpLevel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp135));
                    break;
                case EProtocolId.G2C_WARRIOR_NOTIFYLEVELUP:
                    var Rsp136 = new G2C_Warrior_NotifyLevelUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp136));
                    break;
                case EProtocolId.C2G_WARRIOR_IMPROVEINFO:
                    var Rsp137 = new C2G_Warrior_ImproveInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp137));
                    break;
                case EProtocolId.G2C_WARRIOR_IMPROVEINFO:
                    var Rsp138 = new G2C_Warrior_ImproveInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp138));
                    break;
                case EProtocolId.C2G_WARRIOR_IMPROVE:
                    var Rsp139 = new C2G_Warrior_Improve(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp139));
                    break;
                case EProtocolId.G2C_WARRIOR_IMPROVE:
                    var Rsp140 = new G2C_Warrior_Improve(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp140));
                    break;
                case EProtocolId.C2G_WARRIOR_STAR:
                    var Rsp141 = new C2G_Warrior_Star(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp141));
                    break;
                case EProtocolId.G2C_WARRIOR_STAR:
                    var Rsp142 = new G2C_Warrior_Star(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp142));
                    break;
                case EProtocolId.C2G_WARRIOR_SKILL:
                    var Rsp143 = new C2G_Warrior_Skill(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp143));
                    break;
                case EProtocolId.G2C_WARRIOR_SKILL:
                    var Rsp144 = new G2C_Warrior_Skill(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp144));
                    break;
                case EProtocolId.C2G_WARRIOR_WAKEUNLOCK:
                    var Rsp145 = new C2G_Warrior_WakeUnlock(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp145));
                    break;
                case EProtocolId.G2C_WARRIOR_WAKEUNLOCK:
                    var Rsp146 = new G2C_Warrior_WakeUnlock(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp146));
                    break;
                case EProtocolId.C2G_WARRIOR_WAKEINFO:
                    var Rsp147 = new C2G_Warrior_WakeInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp147));
                    break;
                case EProtocolId.G2C_WARRIOR_WAKEINFO:
                    var Rsp148 = new G2C_Warrior_WakeInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp148));
                    break;
                case EProtocolId.C2G_WARRIOR_WAKEUP:
                    var Rsp149 = new C2G_Warrior_WakeUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp149));
                    break;
                case EProtocolId.G2C_WARRIOR_WAKEUP:
                    var Rsp150 = new G2C_Warrior_WakeUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp150));
                    break;
                case EProtocolId.C2G_WARRIOR_SELL:
                    var Rsp151 = new C2G_Warrior_Sell(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp151));
                    break;
                case EProtocolId.G2C_WARRIOR_SELL:
                    var Rsp152 = new G2C_Warrior_Sell(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp152));
                    break;
                case EProtocolId.C2G_BUILDINGPLAYER_LIST:
                    var Rsp153 = new C2G_BuildingPlayer_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp153));
                    break;
                case EProtocolId.G2C_BUILDINGPLAYER_LIST:
                    var Rsp154 = new G2C_BuildingPlayer_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp154));
                    break;
                case EProtocolId.G2C_BUILDINGPLAYER_PUSHINFOSIMPLE:
                    var Rsp155 = new G2C_BuildingPlayer_PushInfoSimple(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp155));
                    break;
                case EProtocolId.C2G_BUILDINGPLAYER_HARVEST:
                    var Rsp156 = new C2G_BuildingPlayer_Harvest(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp156));
                    break;
                case EProtocolId.G2C_BUILDINGPLAYER_HARVEST:
                    var Rsp157 = new G2C_BuildingPlayer_Harvest(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp157));
                    break;
                case EProtocolId.C2G_BUILDINGPLAYER_HARVESTALL:
                    var Rsp158 = new C2G_BuildingPlayer_HarvestAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp158));
                    break;
                case EProtocolId.G2C_BUILDINGPLAYER_HARVESTALL:
                    var Rsp159 = new G2C_BuildingPlayer_HarvestAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp159));
                    break;
                case EProtocolId.C2G_BUILDINGPLAYER_BUILD:
                    var Rsp160 = new C2G_BuildingPlayer_Build(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp160));
                    break;
                case EProtocolId.G2C_BUILDINGPLAYER_BUILD:
                    var Rsp161 = new G2C_BuildingPlayer_Build(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp161));
                    break;
                case EProtocolId.G2C_BUILDINGPLAYER_NOTIFYBUILT:
                    var Rsp162 = new G2C_BuildingPlayer_NotifyBuilt(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp162));
                    break;
                case EProtocolId.C2G_SMITH_START:
                    var Rsp163 = new C2G_Smith_Start(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp163));
                    break;
                case EProtocolId.G2C_SMITH_START:
                    var Rsp164 = new G2C_Smith_Start(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp164));
                    break;
                case EProtocolId.C2G_SMITH_DO:
                    var Rsp165 = new C2G_Smith_Do(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp165));
                    break;
                case EProtocolId.G2C_SMITH_DO:
                    var Rsp166 = new G2C_Smith_Do(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp166));
                    break;
                case EProtocolId.C2G_SCIENCE_LIST:
                    var Rsp167 = new C2G_Science_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp167));
                    break;
                case EProtocolId.G2C_SCIENCE_LIST:
                    var Rsp168 = new G2C_Science_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp168));
                    break;
                case EProtocolId.C2G_SCIENCE_LEARN:
                    var Rsp169 = new C2G_Science_Learn(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp169));
                    break;
                case EProtocolId.G2C_SCIENCE_LEARN:
                    var Rsp170 = new G2C_Science_Learn(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp170));
                    break;
                case EProtocolId.C2G_SCIENCE_INFO:
                    var Rsp171 = new C2G_Science_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp171));
                    break;
                case EProtocolId.G2C_SCIENCE_INFO:
                    var Rsp172 = new G2C_Science_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp172));
                    break;
                case EProtocolId.C2G_SCIENCE_CANCEL:
                    var Rsp173 = new C2G_Science_Cancel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp173));
                    break;
                case EProtocolId.G2C_SCIENCE_CANCEL:
                    var Rsp174 = new G2C_Science_Cancel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp174));
                    break;
                case EProtocolId.G2C_SCIENCE_NOTIFY:
                    var Rsp175 = new G2C_Science_Notify(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp175));
                    break;
                case EProtocolId.C2G_RECRUIT_INFO:
                    var Rsp176 = new C2G_Recruit_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp176));
                    break;
                case EProtocolId.G2C_RECRUIT_INFO:
                    var Rsp177 = new G2C_Recruit_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp177));
                    break;
                case EProtocolId.C2G_RECRUIT_START:
                    var Rsp178 = new C2G_Recruit_Start(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp178));
                    break;
                case EProtocolId.G2C_RECRUIT_START:
                    var Rsp179 = new G2C_Recruit_Start(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp179));
                    break;
                case EProtocolId.G2C_RECRUIT_NOTIFYCOMPLETE:
                    var Rsp180 = new G2C_Recruit_NotifyComplete(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp180));
                    break;
                case EProtocolId.C2G_PLAYER_SPEEDUPINFO:
                    var Rsp181 = new C2G_Player_SpeedupInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp181));
                    break;
                case EProtocolId.G2C_PLAYER_SPEEDUPINFO:
                    var Rsp182 = new G2C_Player_SpeedupInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp182));
                    break;
                case EProtocolId.C2G_BUILDINGPLAYER_SPEEDUPCOMPLETE:
                    var Rsp183 = new C2G_BuildingPlayer_SpeedupComplete(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp183));
                    break;
                case EProtocolId.G2C_BUILDINGPLAYER_SPEEDUPCOMPLETE:
                    var Rsp184 = new G2C_BuildingPlayer_SpeedupComplete(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp184));
                    break;
                case EProtocolId.C2G_RECRUIT_SPEEDUP:
                    var Rsp185 = new C2G_Recruit_Speedup(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp185));
                    break;
                case EProtocolId.G2C_RECRUIT_SPEEDUP:
                    var Rsp186 = new G2C_Recruit_Speedup(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp186));
                    break;
                case EProtocolId.C2G_SCIENCE_FAST:
                    var Rsp187 = new C2G_Science_Fast(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp187));
                    break;
                case EProtocolId.G2C_SCIENCE_FAST:
                    var Rsp188 = new G2C_Science_Fast(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp188));
                    break;
                case EProtocolId.C2G_PLAYER_SPEEDUPBUY:
                    var Rsp189 = new C2G_Player_SpeedupBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp189));
                    break;
                case EProtocolId.G2C_PLAYER_SPEEDUPBUY:
                    var Rsp190 = new G2C_Player_SpeedupBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp190));
                    break;
                case EProtocolId.C2G_PLAYER_SPEEDUP:
                    var Rsp191 = new C2G_Player_Speedup(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp191));
                    break;
                case EProtocolId.G2C_PLAYER_SPEEDUP:
                    var Rsp192 = new G2C_Player_Speedup(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp192));
                    break;
                case EProtocolId.C2G_HELP_FAST:
                    var Rsp193 = new C2G_Help_Fast(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp193));
                    break;
                case EProtocolId.G2C_HELP_FAST:
                    var Rsp194 = new G2C_Help_Fast(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp194));
                    break;
                case EProtocolId.C2G_CITY_CITYINFO:
                    var Rsp195 = new C2G_City_CityInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp195));
                    break;
                case EProtocolId.G2C_CITY_CITYINFO:
                    var Rsp196 = new G2C_City_CityInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp196));
                    break;
                case EProtocolId.C2G_CITY_LISTCITY:
                    var Rsp197 = new C2G_City_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp197));
                    break;
                case EProtocolId.G2C_CITY_LISTCITY:
                    var Rsp198 = new G2C_City_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp198));
                    break;
                case EProtocolId.C2G_CITY_DEPOTINFO:
                    var Rsp199 = new C2G_City_DepotInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp199));
                    break;
                case EProtocolId.G2C_CITY_DEPOTINFO:
                    var Rsp200 = new G2C_City_DepotInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp200));
                    break;
                case EProtocolId.C2G_CITYBUILDING_LIST:
                    var Rsp201 = new C2G_CityBuilding_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp201));
                    break;
                case EProtocolId.G2C_CITYBUILDING_LIST:
                    var Rsp202 = new G2C_CityBuilding_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp202));
                    break;
                case EProtocolId.C2G_CITYBUILDING_BUILD:
                    var Rsp203 = new C2G_CityBuilding_Build(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp203));
                    break;
                case EProtocolId.G2C_CITYBUILDING_BUILD:
                    var Rsp204 = new G2C_CityBuilding_Build(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp204));
                    break;
                case EProtocolId.C2G_WALL_INFO:
                    var Rsp205 = new C2G_Wall_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp205));
                    break;
                case EProtocolId.G2C_WALL_INFO:
                    var Rsp206 = new G2C_Wall_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp206));
                    break;
                case EProtocolId.C2G_WALL_REPAIR:
                    var Rsp207 = new C2G_Wall_Repair(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp207));
                    break;
                case EProtocolId.G2C_WALL_REPAIR:
                    var Rsp208 = new G2C_Wall_Repair(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp208));
                    break;
                case EProtocolId.C2G_WALL_MAKEWORK:
                    var Rsp209 = new C2G_Wall_MakeWork(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp209));
                    break;
                case EProtocolId.G2C_WALL_MAKEWORK:
                    var Rsp210 = new G2C_Wall_MakeWork(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp210));
                    break;
                case EProtocolId.C2G_CAMP_INFO:
                    var Rsp211 = new C2G_Camp_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp211));
                    break;
                case EProtocolId.G2C_CAMP_INFO:
                    var Rsp212 = new G2C_Camp_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp212));
                    break;
                case EProtocolId.C2G_CITY_SHOPINFO:
                    var Rsp213 = new C2G_City_ShopInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp213));
                    break;
                case EProtocolId.G2C_CITY_SHOPINFO:
                    var Rsp214 = new G2C_City_ShopInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp214));
                    break;
                case EProtocolId.C2G_CITY_SHOPBUY:
                    var Rsp215 = new C2G_City_ShopBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp215));
                    break;
                case EProtocolId.G2C_CITY_SHOPBUY:
                    var Rsp216 = new G2C_City_ShopBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp216));
                    break;
                case EProtocolId.C2G_SHOP_LIST:
                    var Rsp217 = new C2G_Shop_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp217));
                    break;
                case EProtocolId.G2C_SHOP_LIST:
                    var Rsp218 = new G2C_Shop_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp218));
                    break;
                case EProtocolId.C2G_SHOP_BUY:
                    var Rsp219 = new C2G_Shop_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp219));
                    break;
                case EProtocolId.G2C_SHOP_BUY:
                    var Rsp220 = new G2C_Shop_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp220));
                    break;
                case EProtocolId.C2G_SHOP_QUICKBUY:
                    var Rsp221 = new C2G_Shop_QuickBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp221));
                    break;
                case EProtocolId.G2C_SHOP_QUICKBUY:
                    var Rsp222 = new G2C_Shop_QuickBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp222));
                    break;
                case EProtocolId.C2G_REFRESH_DIAMOND_STORE:
                    var Rsp223 = new C2G_Refresh_Diamond_Store(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp223));
                    break;
                case EProtocolId.G2C_REFRESH_DIAMOND_STORE:
                    var Rsp224 = new G2C_Refresh_Diamond_Store(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp224));
                    break;
                case EProtocolId.C2G_SHOP_BUYWARRIORBAG:
                    var Rsp225 = new C2G_Shop_BuyWarriorBag(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp225));
                    break;
                case EProtocolId.G2C_SHOP_BUYWARRIORBAG:
                    var Rsp226 = new G2C_Shop_BuyWarriorBag(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp226));
                    break;
                case EProtocolId.C2G_BUY_GOLD:
                    var Rsp227 = new C2G_Buy_Gold(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp227));
                    break;
                case EProtocolId.G2C_BUY_GOLD:
                    var Rsp228 = new G2C_Buy_Gold(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp228));
                    break;
                case EProtocolId.C2G_EXCHANGE_LIST:
                    var Rsp229 = new C2G_Exchange_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp229));
                    break;
                case EProtocolId.G2C_EXCHANGE_LIST:
                    var Rsp230 = new G2C_Exchange_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp230));
                    break;
                case EProtocolId.C2G_EXCHANGE_SHELVES:
                    var Rsp231 = new C2G_Exchange_Shelves(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp231));
                    break;
                case EProtocolId.G2C_EXCHANGE_SHELVES:
                    var Rsp232 = new G2C_Exchange_Shelves(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp232));
                    break;
                case EProtocolId.C2G_EXCHANGE_REVOKE:
                    var Rsp233 = new C2G_Exchange_Revoke(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp233));
                    break;
                case EProtocolId.G2C_EXCHANGE_REVOKE:
                    var Rsp234 = new G2C_Exchange_Revoke(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp234));
                    break;
                case EProtocolId.C2G_EXCHANGE_TRANSACTION:
                    var Rsp235 = new C2G_Exchange_Transaction(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp235));
                    break;
                case EProtocolId.G2C_EXCHANGE_TRANSACTION:
                    var Rsp236 = new G2C_Exchange_Transaction(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp236));
                    break;
                case EProtocolId.C2G_GETTRANSACTIONLOGLIST:
                    var Rsp237 = new C2G_GetTransactionLogList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp237));
                    break;
                case EProtocolId.G2C_GETTRANSACTIONLOGLIST:
                    var Rsp238 = new G2C_GetTransactionLogList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp238));
                    break;
                case EProtocolId.C2G_AUCTION_LISTITEM:
                    var Rsp239 = new C2G_Auction_ListItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp239));
                    break;
                case EProtocolId.G2C_AUCTION_LISTITEM:
                    var Rsp240 = new G2C_Auction_ListItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp240));
                    break;
                case EProtocolId.C2G_AUCTION_SELLITEM:
                    var Rsp241 = new C2G_Auction_SellItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp241));
                    break;
                case EProtocolId.G2C_AUCTION_SELLITEM:
                    var Rsp242 = new G2C_Auction_SellItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp242));
                    break;
                case EProtocolId.C2G_AUCTION_RETURNITEM:
                    var Rsp243 = new C2G_Auction_ReturnItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp243));
                    break;
                case EProtocolId.G2C_AUCTION_RETURNITEM:
                    var Rsp244 = new G2C_Auction_ReturnItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp244));
                    break;
                case EProtocolId.C2G_AUCTION_BUYITEM:
                    var Rsp245 = new C2G_Auction_BuyItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp245));
                    break;
                case EProtocolId.G2C_AUCTION_BUYITEM:
                    var Rsp246 = new G2C_Auction_BuyItem(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp246));
                    break;
                case EProtocolId.C2G_AUCTION_LISTEQUIP:
                    var Rsp247 = new C2G_Auction_ListEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp247));
                    break;
                case EProtocolId.G2C_AUCTION_LISTEQUIP:
                    var Rsp248 = new G2C_Auction_ListEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp248));
                    break;
                case EProtocolId.C2G_AUCTION_SELLEQUIP:
                    var Rsp249 = new C2G_Auction_SellEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp249));
                    break;
                case EProtocolId.G2C_AUCTION_SELLEQUIP:
                    var Rsp250 = new G2C_Auction_SellEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp250));
                    break;
                case EProtocolId.C2G_AUCTION_RETURNEQUIP:
                    var Rsp251 = new C2G_Auction_ReturnEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp251));
                    break;
                case EProtocolId.G2C_AUCTION_RETURNEQUIP:
                    var Rsp252 = new G2C_Auction_ReturnEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp252));
                    break;
                case EProtocolId.C2G_AUCTION_BUYEQUIP:
                    var Rsp253 = new C2G_Auction_BuyEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp253));
                    break;
                case EProtocolId.G2C_AUCTION_BUYEQUIP:
                    var Rsp254 = new G2C_Auction_BuyEquip(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp254));
                    break;
                case EProtocolId.C2G_AUCTION_LISTWARRIOR:
                    var Rsp255 = new C2G_Auction_ListWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp255));
                    break;
                case EProtocolId.G2C_AUCTION_LISTWARRIOR:
                    var Rsp256 = new G2C_Auction_ListWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp256));
                    break;
                case EProtocolId.C2G_AUCTION_SELLWARRIOR:
                    var Rsp257 = new C2G_Auction_SellWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp257));
                    break;
                case EProtocolId.G2C_AUCTION_SELLWARRIOR:
                    var Rsp258 = new G2C_Auction_SellWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp258));
                    break;
                case EProtocolId.C2G_AUCTION_RETURNWARRIOR:
                    var Rsp259 = new C2G_Auction_ReturnWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp259));
                    break;
                case EProtocolId.G2C_AUCTION_RETURNWARRIOR:
                    var Rsp260 = new G2C_Auction_ReturnWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp260));
                    break;
                case EProtocolId.C2G_AUCTION_BUYWARRIOR:
                    var Rsp261 = new C2G_Auction_BuyWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp261));
                    break;
                case EProtocolId.G2C_AUCTION_BUYWARRIOR:
                    var Rsp262 = new G2C_Auction_BuyWarrior(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp262));
                    break;
                case EProtocolId.C2G_AUCTION_SEARCH:
                    var Rsp263 = new C2G_Auction_Search(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp263));
                    break;
                case EProtocolId.G2C_AUCTION_SEARCH:
                    var Rsp264 = new G2C_Auction_Search(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp264));
                    break;
                case EProtocolId.C2G_AUCTION_GETLOG:
                    var Rsp265 = new C2G_Auction_GetLog(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp265));
                    break;
                case EProtocolId.G2C_AUCTION_GETLOG:
                    var Rsp266 = new G2C_Auction_GetLog(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp266));
                    break;
                case EProtocolId.C2G_DRAW_GETINFO:
                    var Rsp267 = new C2G_Draw_GetInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp267));
                    break;
                case EProtocolId.G2C_DRAW_GETINFO:
                    var Rsp268 = new G2C_Draw_GetInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp268));
                    break;
                case EProtocolId.C2G_DRAW_LUCK:
                    var Rsp269 = new C2G_Draw_Luck(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp269));
                    break;
                case EProtocolId.G2C_DRAW_LUCK:
                    var Rsp270 = new G2C_Draw_Luck(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp270));
                    break;
                case EProtocolId.C2G_DRAW_GETAWARD:
                    var Rsp271 = new C2G_Draw_GetAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp271));
                    break;
                case EProtocolId.G2C_DRAW_GETAWARD:
                    var Rsp272 = new G2C_Draw_GetAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp272));
                    break;
                case EProtocolId.C2G_CDKEY_USE:
                    var Rsp273 = new C2G_Cdkey_Use(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp273));
                    break;
                case EProtocolId.G2C_CDKEY_USE:
                    var Rsp274 = new G2C_Cdkey_Use(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp274));
                    break;
                case EProtocolId.C2G_TOP_TOPLIST:
                    var Rsp275 = new C2G_Top_Toplist(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp275));
                    break;
                case EProtocolId.G2C_TOP_TOPLIST:
                    var Rsp276 = new G2C_Top_Toplist(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp276));
                    break;
                case EProtocolId.C2G_TOP_INFO:
                    var Rsp277 = new C2G_Top_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp277));
                    break;
                case EProtocolId.G2C_TOP_INFO:
                    var Rsp278 = new G2C_Top_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp278));
                    break;
                case EProtocolId.C2G_TASK_LIST:
                    var Rsp279 = new C2G_Task_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp279));
                    break;
                case EProtocolId.G2C_TASK_LIST:
                    var Rsp280 = new G2C_Task_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp280));
                    break;
                case EProtocolId.C2G_TASK_GET:
                    var Rsp281 = new C2G_Task_Get(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp281));
                    break;
                case EProtocolId.G2C_TASK_GET:
                    var Rsp282 = new G2C_Task_Get(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp282));
                    break;
                case EProtocolId.C2G_TASK_GETALL:
                    var Rsp283 = new C2G_Task_GetAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp283));
                    break;
                case EProtocolId.G2C_TASK_GETALL:
                    var Rsp284 = new G2C_Task_GetAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp284));
                    break;
                case EProtocolId.C2G_TASK_EVERYDAY:
                    var Rsp285 = new C2G_Task_Everyday(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp285));
                    break;
                case EProtocolId.G2C_TASK_EVERYDAY:
                    var Rsp286 = new G2C_Task_Everyday(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp286));
                    break;
                case EProtocolId.C2G_TASK_EVERYDAYAWARD:
                    var Rsp287 = new C2G_Task_EverydayAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp287));
                    break;
                case EProtocolId.G2C_TASK_EVERYDAYAWARD:
                    var Rsp288 = new G2C_Task_EverydayAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp288));
                    break;
                case EProtocolId.C2G_SIGN_INFO:
                    var Rsp289 = new C2G_Sign_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp289));
                    break;
                case EProtocolId.G2C_SIGN_INFO:
                    var Rsp290 = new G2C_Sign_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp290));
                    break;
                case EProtocolId.C2G_SIGN:
                    var Rsp291 = new C2G_Sign(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp291));
                    break;
                case EProtocolId.G2C_SIGN:
                    var Rsp292 = new G2C_Sign(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp292));
                    break;
                case EProtocolId.C2G_RESIGN:
                    var Rsp293 = new C2G_ReSign(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp293));
                    break;
                case EProtocolId.G2C_RESIGN:
                    var Rsp294 = new G2C_ReSign(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp294));
                    break;
                case EProtocolId.C2G_BUFF_INFO:
                    var Rsp295 = new C2G_Buff_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp295));
                    break;
                case EProtocolId.G2C_BUFF_INFO:
                    var Rsp296 = new G2C_Buff_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp296));
                    break;
                case EProtocolId.C2G_ACITVITY_LIST:
                    var Rsp297 = new C2G_Acitvity_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp297));
                    break;
                case EProtocolId.G2C_ACITVITY_LIST:
                    var Rsp298 = new G2C_Acitvity_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp298));
                    break;
                case EProtocolId.C2G_ACITVITY_REBATEINFO:
                    var Rsp299 = new C2G_Acitvity_RebateInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp299));
                    break;
                case EProtocolId.G2C_ACITVITY_REBATEINFO:
                    var Rsp300 = new G2C_Acitvity_RebateInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp300));
                    break;
                case EProtocolId.C2G_ACITVITY_7DAY:
                    var Rsp301 = new C2G_Acitvity_7Day(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp301));
                    break;
                case EProtocolId.G2C_ACITVITY_7DAY:
                    var Rsp302 = new G2C_Acitvity_7Day(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp302));
                    break;
                case EProtocolId.C2G_ACITVITY_7DAYGET:
                    var Rsp303 = new C2G_Acitvity_7DayGet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp303));
                    break;
                case EProtocolId.G2C_ACITVITY_7DAYGET:
                    var Rsp304 = new G2C_Acitvity_7DayGet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp304));
                    break;
                case EProtocolId.C2G_ACITVITY_7DAYLOGININFO:
                    var Rsp305 = new C2G_Acitvity_7DayLoginInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp305));
                    break;
                case EProtocolId.G2C_ACITVITY_7DAYLOGININFO:
                    var Rsp306 = new G2C_Acitvity_7DayLoginInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp306));
                    break;
                case EProtocolId.C2G_ACITVITY_7DAYLOGINGET:
                    var Rsp307 = new C2G_Acitvity_7DayLoginGet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp307));
                    break;
                case EProtocolId.G2C_ACITVITY_7DAYLOGINGET:
                    var Rsp308 = new G2C_Acitvity_7DayLoginGet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp308));
                    break;
                case EProtocolId.C2G_WELFARE_INFO:
                    var Rsp309 = new C2G_Welfare_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp309));
                    break;
                case EProtocolId.G2C_WELFARE_INFO:
                    var Rsp310 = new G2C_Welfare_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp310));
                    break;
                case EProtocolId.C2G_WELFARE_AWARD:
                    var Rsp311 = new C2G_Welfare_Award(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp311));
                    break;
                case EProtocolId.G2C_WELFARE_AWARD:
                    var Rsp312 = new G2C_Welfare_Award(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp312));
                    break;
                case EProtocolId.C2G_GUILD_LIST:
                    var Rsp313 = new C2G_Guild_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp313));
                    break;
                case EProtocolId.G2C_GUILD_LIST:
                    var Rsp314 = new G2C_Guild_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp314));
                    break;
                case EProtocolId.C2G_GUILD_LISTDETAILS:
                    var Rsp315 = new C2G_Guild_ListDetails(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp315));
                    break;
                case EProtocolId.G2C_GUILD_LISTDETAILS:
                    var Rsp316 = new G2C_Guild_ListDetails(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp316));
                    break;
                case EProtocolId.C2G_GUILD_CREATE:
                    var Rsp317 = new C2G_Guild_Create(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp317));
                    break;
                case EProtocolId.G2C_GUILD_CREATE:
                    var Rsp318 = new G2C_Guild_Create(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp318));
                    break;
                case EProtocolId.C2G_GUILD_TRYLEAVE:
                    var Rsp319 = new C2G_Guild_TryLeave(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp319));
                    break;
                case EProtocolId.G2C_GUILD_TRYLEAVE:
                    var Rsp320 = new G2C_Guild_TryLeave(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp320));
                    break;
                case EProtocolId.C2G_GUILD_TRYKICK:
                    var Rsp321 = new C2G_Guild_TryKick(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp321));
                    break;
                case EProtocolId.G2C_GUILD_TRYKICK:
                    var Rsp322 = new G2C_Guild_TryKick(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp322));
                    break;
                case EProtocolId.C2G_GUILD_ABDICATE:
                    var Rsp323 = new C2G_Guild_Abdicate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp323));
                    break;
                case EProtocolId.G2C_GUILD_ABDICATE:
                    var Rsp324 = new G2C_Guild_Abdicate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp324));
                    break;
                case EProtocolId.C2G_GUILD_TRYJOIN:
                    var Rsp325 = new C2G_Guild_TryJoin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp325));
                    break;
                case EProtocolId.G2C_GUILD_TRYJOIN:
                    var Rsp326 = new G2C_Guild_TryJoin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp326));
                    break;
                case EProtocolId.C2G_GUILD_LISTAPPLY:
                    var Rsp327 = new C2G_Guild_ListApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp327));
                    break;
                case EProtocolId.G2C_GUILD_LISTAPPLY:
                    var Rsp328 = new G2C_Guild_ListApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp328));
                    break;
                case EProtocolId.C2G_GUILD_APPLYACTION:
                    var Rsp329 = new C2G_Guild_ApplyAction(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp329));
                    break;
                case EProtocolId.G2C_GUILD_APPLYACTION:
                    var Rsp330 = new G2C_Guild_ApplyAction(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp330));
                    break;
                case EProtocolId.C2G_GUILD_LISTMBS:
                    var Rsp331 = new C2G_Guild_ListMbs(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp331));
                    break;
                case EProtocolId.G2C_GUILD_LISTMBS:
                    var Rsp332 = new G2C_Guild_ListMbs(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp332));
                    break;
                case EProtocolId.C2G_GUILD_LISTLOGRECORD:
                    var Rsp333 = new C2G_Guild_ListLogRecord(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp333));
                    break;
                case EProtocolId.G2C_GUILD_LISTLOGRECORD:
                    var Rsp334 = new G2C_Guild_ListLogRecord(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp334));
                    break;
                case EProtocolId.C2G_GUILD_RENAME:
                    var Rsp335 = new C2G_Guild_Rename(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp335));
                    break;
                case EProtocolId.G2C_GUILD_RENAME:
                    var Rsp336 = new G2C_Guild_Rename(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp336));
                    break;
                case EProtocolId.C2G_GUILD_JOINMODE:
                    var Rsp337 = new C2G_Guild_JoinMode(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp337));
                    break;
                case EProtocolId.G2C_GUILD_JOINMODE:
                    var Rsp338 = new G2C_Guild_JoinMode(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp338));
                    break;
                case EProtocolId.C2G_GUILD_MANIFESTO:
                    var Rsp339 = new C2G_Guild_Manifesto(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp339));
                    break;
                case EProtocolId.G2C_GUILD_MANIFESTO:
                    var Rsp340 = new G2C_Guild_Manifesto(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp340));
                    break;
                case EProtocolId.C2G_GUILD_NOTICE:
                    var Rsp341 = new C2G_Guild_Notice(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp341));
                    break;
                case EProtocolId.G2C_GUILD_NOTICE:
                    var Rsp342 = new G2C_Guild_Notice(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp342));
                    break;
                case EProtocolId.C2G_GUILD_DONATEINFO:
                    var Rsp343 = new C2G_Guild_DonateInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp343));
                    break;
                case EProtocolId.G2C_GUILD_DONATEINFO:
                    var Rsp344 = new G2C_Guild_DonateInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp344));
                    break;
                case EProtocolId.C2G_GUILD_DONATE:
                    var Rsp345 = new C2G_Guild_Donate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp345));
                    break;
                case EProtocolId.G2C_GUILD_DONATE:
                    var Rsp346 = new G2C_Guild_Donate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp346));
                    break;
                case EProtocolId.C2G_GUILD_LISTDIPLOMACY:
                    var Rsp347 = new C2G_Guild_ListDiplomacy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp347));
                    break;
                case EProtocolId.G2C_GUILD_LISTDIPLOMACY:
                    var Rsp348 = new G2C_Guild_ListDiplomacy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp348));
                    break;
                case EProtocolId.C2G_GUILD_SEARCHNAME:
                    var Rsp349 = new C2G_Guild_SearchName(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp349));
                    break;
                case EProtocolId.G2C_GUILD_SEARCHNAME:
                    var Rsp350 = new G2C_Guild_SearchName(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp350));
                    break;
                case EProtocolId.C2G_GUILD_LISTALLIANCEAPPLY:
                    var Rsp351 = new C2G_Guild_ListAllianceApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp351));
                    break;
                case EProtocolId.G2C_GUILD_LISTALLIANCEAPPLY:
                    var Rsp352 = new G2C_Guild_ListAllianceApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp352));
                    break;
                case EProtocolId.C2G_GUILD_ALLIANCEAPPLY:
                    var Rsp353 = new C2G_Guild_AllianceApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp353));
                    break;
                case EProtocolId.G2C_GUILD_ALLIANCEAPPLY:
                    var Rsp354 = new G2C_Guild_AllianceApply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp354));
                    break;
                case EProtocolId.C2G_GUILD_ALLIANCEREMOVE:
                    var Rsp355 = new C2G_Guild_AllianceRemove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp355));
                    break;
                case EProtocolId.G2C_GUILD_ALLIANCEREMOVE:
                    var Rsp356 = new G2C_Guild_AllianceRemove(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp356));
                    break;
                case EProtocolId.C2G_GUILD_ALLIANCEAPPLYACTION:
                    var Rsp357 = new C2G_Guild_AllianceApplyAction(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp357));
                    break;
                case EProtocolId.G2C_GUILD_ALLIANCEAPPLYACTION:
                    var Rsp358 = new G2C_Guild_AllianceApplyAction(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp358));
                    break;
                case EProtocolId.C2G_GUILD_LISTCITY:
                    var Rsp359 = new C2G_Guild_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp359));
                    break;
                case EProtocolId.G2C_GUILD_LISTCITY:
                    var Rsp360 = new G2C_Guild_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp360));
                    break;
                case EProtocolId.C2G_GUILD_SETCAPITALCITY:
                    var Rsp361 = new C2G_Guild_SetCapitalCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp361));
                    break;
                case EProtocolId.G2C_GUILD_SETCAPITALCITY:
                    var Rsp362 = new G2C_Guild_SetCapitalCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp362));
                    break;
                case EProtocolId.C2G_GUILD_SETCITYLEADER:
                    var Rsp363 = new C2G_Guild_SetCityLeader(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp363));
                    break;
                case EProtocolId.G2C_GUILD_SETCITYLEADER:
                    var Rsp364 = new G2C_Guild_SetCityLeader(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp364));
                    break;
                case EProtocolId.C2G_GUILD_REMOVECITYLEADER:
                    var Rsp365 = new C2G_Guild_RemoveCityLeader(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp365));
                    break;
                case EProtocolId.G2C_GUILD_REMOVECITYLEADER:
                    var Rsp366 = new G2C_Guild_RemoveCityLeader(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp366));
                    break;
                case EProtocolId.C2G_GUILD_LISTLOGSITUATION:
                    var Rsp367 = new C2G_Guild_ListLogSituation(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp367));
                    break;
                case EProtocolId.G2C_GUILD_LISTLOGSITUATION:
                    var Rsp368 = new G2C_Guild_ListLogSituation(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp368));
                    break;
                case EProtocolId.C2G_GUILD_LISTTOP:
                    var Rsp369 = new C2G_Guild_ListTop(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp369));
                    break;
                case EProtocolId.G2C_GUILD_LISTTOP:
                    var Rsp370 = new G2C_Guild_ListTop(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp370));
                    break;
                case EProtocolId.C2G_RED_PACKET_LIST:
                    var Rsp371 = new C2G_Red_Packet_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp371));
                    break;
                case EProtocolId.G2C_RED_PACKET_LIST:
                    var Rsp372 = new G2C_Red_Packet_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp372));
                    break;
                case EProtocolId.C2G_RED_PACKET_INFO:
                    var Rsp373 = new C2G_Red_Packet_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp373));
                    break;
                case EProtocolId.G2C_RED_PACKET_INFO:
                    var Rsp374 = new G2C_Red_Packet_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp374));
                    break;
                case EProtocolId.C2G_GIVE_RED_PACKET:
                    var Rsp375 = new C2G_Give_Red_Packet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp375));
                    break;
                case EProtocolId.G2C_GIVE_RED_PACKET:
                    var Rsp376 = new G2C_Give_Red_Packet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp376));
                    break;
                case EProtocolId.G2C_RED_PACKET_RECEIVE:
                    var Rsp377 = new G2C_Red_Packet_Receive(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp377));
                    break;
                case EProtocolId.C2G_GET_RED_PACKET:
                    var Rsp378 = new C2G_Get_Red_Packet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp378));
                    break;
                case EProtocolId.G2C_GET_RED_PACKET:
                    var Rsp379 = new G2C_Get_Red_Packet(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp379));
                    break;
                case EProtocolId.C2G_MANSIONBOSS_INFO:
                    var Rsp380 = new C2G_MansionBoss_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp380));
                    break;
                case EProtocolId.G2C_MANSIONBOSS_INFO:
                    var Rsp381 = new G2C_MansionBoss_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp381));
                    break;
                case EProtocolId.C2G_MANSIONBOSS_OPEN:
                    var Rsp382 = new C2G_MansionBoss_Open(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp382));
                    break;
                case EProtocolId.G2C_MANSIONBOSS_OPEN:
                    var Rsp383 = new G2C_MansionBoss_Open(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp383));
                    break;
                case EProtocolId.C2G_MANSIONBOSS_TOP:
                    var Rsp384 = new C2G_MansionBoss_Top(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp384));
                    break;
                case EProtocolId.G2C_MANSIONBOSS_TOP:
                    var Rsp385 = new G2C_MansionBoss_Top(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp385));
                    break;
                case EProtocolId.C2G_MANSIONBOSS_BATTLE:
                    var Rsp386 = new C2G_MansionBoss_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp386));
                    break;
                case EProtocolId.G2C_MANSIONBOSS_BATTLE:
                    var Rsp387 = new G2C_MansionBoss_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp387));
                    break;
                case EProtocolId.C2G_MANSIONBOSS_BALANCE:
                    var Rsp388 = new C2G_MansionBoss_Balance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp388));
                    break;
                case EProtocolId.G2C_MANSIONBOSS_BALANCE:
                    var Rsp389 = new G2C_MansionBoss_Balance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp389));
                    break;
                case EProtocolId.G2C_MANSIONBOSS_TAKEBALANCE:
                    var Rsp390 = new G2C_MansionBoss_TakeBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp390));
                    break;
                case EProtocolId.C2G_MANSIONBOSS_BUFF:
                    var Rsp391 = new C2G_MansionBoss_Buff(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp391));
                    break;
                case EProtocolId.G2C_MANSIONBOSS_BUFF:
                    var Rsp392 = new G2C_MansionBoss_Buff(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp392));
                    break;
                case EProtocolId.C2G_GUILD_GETACTIVE:
                    var Rsp393 = new C2G_Guild_GetActive(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp393));
                    break;
                case EProtocolId.G2C_GUILD_GETACTIVE:
                    var Rsp394 = new G2C_Guild_GetActive(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp394));
                    break;
                case EProtocolId.C2G_GUILD_ACTIVEAWARD:
                    var Rsp395 = new C2G_Guild_ActiveAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp395));
                    break;
                case EProtocolId.G2C_GUILD_ACTIVEAWARD:
                    var Rsp396 = new G2C_Guild_ActiveAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp396));
                    break;
                case EProtocolId.C2G_GUILD_ACTIVEAWARDALL:
                    var Rsp397 = new C2G_Guild_ActiveAwardAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp397));
                    break;
                case EProtocolId.G2C_GUILD_ACTIVEAWARDALL:
                    var Rsp398 = new G2C_Guild_ActiveAwardAll(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp398));
                    break;
                case EProtocolId.C2G_GUILD_SCIENCEINFO:
                    var Rsp399 = new C2G_Guild_ScienceInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp399));
                    break;
                case EProtocolId.G2C_GUILD_SCIENCEINFO:
                    var Rsp400 = new G2C_Guild_ScienceInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp400));
                    break;
                case EProtocolId.C2G_GUILD_SCIENCELEVELUP:
                    var Rsp401 = new C2G_Guild_ScienceLevelUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp401));
                    break;
                case EProtocolId.G2C_GUILD_SCIENCELEVELUP:
                    var Rsp402 = new G2C_Guild_ScienceLevelUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp402));
                    break;
                case EProtocolId.C2G_GUILD_SHOPINFO:
                    var Rsp403 = new C2G_Guild_ShopInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp403));
                    break;
                case EProtocolId.G2C_GUILD_SHOPINFO:
                    var Rsp404 = new G2C_Guild_ShopInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp404));
                    break;
                case EProtocolId.C2G_GUILD_SHOPBUY:
                    var Rsp405 = new C2G_Guild_ShopBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp405));
                    break;
                case EProtocolId.G2C_GUILD_SHOPBUY:
                    var Rsp406 = new G2C_Guild_ShopBuy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp406));
                    break;
                case EProtocolId.C2G_GUILD_SHOPREFRESH:
                    var Rsp407 = new C2G_Guild_ShopRefresh(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp407));
                    break;
                case EProtocolId.G2C_GUILD_SHOPREFRESH:
                    var Rsp408 = new G2C_Guild_ShopRefresh(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp408));
                    break;
                case EProtocolId.C2G_GUILDSALARY_LISTMBS:
                    var Rsp409 = new C2G_GuildSalary_ListMbs(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp409));
                    break;
                case EProtocolId.G2C_GUILDSALARY_LISTMBS:
                    var Rsp410 = new G2C_GuildSalary_ListMbs(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp410));
                    break;
                case EProtocolId.C2G_GUILDSALARY_PAY:
                    var Rsp411 = new C2G_GuildSalary_Pay(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp411));
                    break;
                case EProtocolId.G2C_GUILDSALARY_PAY:
                    var Rsp412 = new G2C_GuildSalary_Pay(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp412));
                    break;
                case EProtocolId.C2G_GUILDSALARY_LISTCITY:
                    var Rsp413 = new C2G_GuildSalary_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp413));
                    break;
                case EProtocolId.G2C_GUILDSALARY_LISTCITY:
                    var Rsp414 = new G2C_GuildSalary_ListCity(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp414));
                    break;
                case EProtocolId.C2G_GODDESS_SENIORITY:
                    var Rsp415 = new C2G_Goddess_Seniority(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp415));
                    break;
                case EProtocolId.G2C_GODDESS_SENIORITY:
                    var Rsp416 = new G2C_Goddess_Seniority(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp416));
                    break;
                case EProtocolId.C2G_GODDESS_GETINFO:
                    var Rsp417 = new C2G_Goddess_GetInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp417));
                    break;
                case EProtocolId.G2C_GODDESS_GETINFO:
                    var Rsp418 = new G2C_Goddess_GetInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp418));
                    break;
                case EProtocolId.C2G_GODDESS_CHOOSE:
                    var Rsp419 = new C2G_Goddess_Choose(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp419));
                    break;
                case EProtocolId.G2C_GODDESS_CHOOSE:
                    var Rsp420 = new G2C_Goddess_Choose(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp420));
                    break;
                case EProtocolId.C2G_GODDESS_DONATE:
                    var Rsp421 = new C2G_Goddess_Donate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp421));
                    break;
                case EProtocolId.G2C_GODDESS_DONATE:
                    var Rsp422 = new G2C_Goddess_Donate(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp422));
                    break;
                case EProtocolId.C2G_GODDESS_SAVE:
                    var Rsp423 = new C2G_Goddess_Save(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp423));
                    break;
                case EProtocolId.G2C_GODDESS_SAVE:
                    var Rsp424 = new G2C_Goddess_Save(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp424));
                    break;
                case EProtocolId.C2G_GODDESS_DEFEND:
                    var Rsp425 = new C2G_Goddess_Defend(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp425));
                    break;
                case EProtocolId.G2C_GODDESS_DEFEND:
                    var Rsp426 = new G2C_Goddess_Defend(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp426));
                    break;
                case EProtocolId.C2G_WARRIOR_INBATTLE:
                    var Rsp427 = new C2G_Warrior_InBattle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp427));
                    break;
                case EProtocolId.G2C_WARRIOR_INBATTLE:
                    var Rsp428 = new G2C_Warrior_InBattle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp428));
                    break;
                case EProtocolId.C2G_PVE_ARMYINFO:
                    var Rsp429 = new C2G_Pve_ArmyInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp429));
                    break;
                case EProtocolId.G2C_PVE_ARMYINFO:
                    var Rsp430 = new G2C_Pve_ArmyInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp430));
                    break;
                case EProtocolId.C2G_PVE_ARMYCHANGE:
                    var Rsp431 = new C2G_Pve_ArmyChange(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp431));
                    break;
                case EProtocolId.G2C_PVE_ARMYCHANGE:
                    var Rsp432 = new G2C_Pve_ArmyChange(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp432));
                    break;
                case EProtocolId.C2G_PVE_GOBATTLE:
                    var Rsp433 = new C2G_Pve_GoBattle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp433));
                    break;
                case EProtocolId.G2C_PVE_GOBATTLE:
                    var Rsp434 = new G2C_Pve_GoBattle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp434));
                    break;
                case EProtocolId.G2C_PVE_BATTLEBALANCE:
                    var Rsp435 = new G2C_Pve_BattleBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp435));
                    break;
                case EProtocolId.C2G_GAMELEVELSTORY_INFO:
                    var Rsp436 = new C2G_GameLevelStory_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp436));
                    break;
                case EProtocolId.G2C_GAMELEVELSTORY_INFO:
                    var Rsp437 = new G2C_GameLevelStory_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp437));
                    break;
                case EProtocolId.C2G_GAMELEVELSTORY_BATTLE:
                    var Rsp438 = new C2G_GameLevelStory_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp438));
                    break;
                case EProtocolId.G2C_GAMELEVELSTORY_BATTLE:
                    var Rsp439 = new G2C_GameLevelStory_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp439));
                    break;
                case EProtocolId.C2G_GAMELEVELSTORY_BALANCE:
                    var Rsp440 = new C2G_GameLevelStory_Balance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp440));
                    break;
                case EProtocolId.G2C_GAMELEVELSTORY_BALANCE:
                    var Rsp441 = new G2C_GameLevelStory_Balance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp441));
                    break;
                case EProtocolId.C2G_GAMELEVELSTORY_REWARD:
                    var Rsp442 = new C2G_GameLevelStory_Reward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp442));
                    break;
                case EProtocolId.G2C_GAMELEVELSTORY_REWARD:
                    var Rsp443 = new G2C_GameLevelStory_Reward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp443));
                    break;
                case EProtocolId.C2G_GAMELEVELSTORYBUYPOWER:
                    var Rsp444 = new C2G_GameLevelStoryBuyPower(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp444));
                    break;
                case EProtocolId.G2C_GAMELEVELSTORYBUYPOWER:
                    var Rsp445 = new G2C_GameLevelStoryBuyPower(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp445));
                    break;
                case EProtocolId.C2G_GAMELEVELSTORY:
                    var Rsp446 = new C2G_GameLevelStory(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp446));
                    break;
                case EProtocolId.G2C_GAMELEVELSTORY:
                    var Rsp447 = new G2C_GameLevelStory(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp447));
                    break;
                case EProtocolId.C2G_TOWER_INFO:
                    var Rsp448 = new C2G_Tower_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp448));
                    break;
                case EProtocolId.G2C_TOWER_INFO:
                    var Rsp449 = new G2C_Tower_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp449));
                    break;
                case EProtocolId.C2G_TOWER_BATTLE:
                    var Rsp450 = new C2G_Tower_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp450));
                    break;
                case EProtocolId.G2C_TOWER_BATTLE:
                    var Rsp451 = new G2C_Tower_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp451));
                    break;
                case EProtocolId.C2G_TOWER_BATTLEEND:
                    var Rsp452 = new C2G_Tower_BattleEnd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp452));
                    break;
                case EProtocolId.G2C_TOWER_BATTLEEND:
                    var Rsp453 = new G2C_Tower_BattleEnd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp453));
                    break;
                case EProtocolId.C2G_ARENA_INFO:
                    var Rsp454 = new C2G_Arena_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp454));
                    break;
                case EProtocolId.G2C_ARENA_INFO:
                    var Rsp455 = new G2C_Arena_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp455));
                    break;
                case EProtocolId.C2G_ARENA_TOP:
                    var Rsp456 = new C2G_Arena_TOP(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp456));
                    break;
                case EProtocolId.G2C_ARENA_TOP:
                    var Rsp457 = new G2C_Arena_TOP(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp457));
                    break;
                case EProtocolId.C2G_ARENAMATCH_REFRESH:
                    var Rsp458 = new C2G_ArenaMatch_Refresh(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp458));
                    break;
                case EProtocolId.G2C_ARENAMATCH_REFRESH:
                    var Rsp459 = new G2C_ArenaMatch_Refresh(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp459));
                    break;
                case EProtocolId.C2G_ARENAMATCH_BATTLE:
                    var Rsp460 = new C2G_ArenaMatch_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp460));
                    break;
                case EProtocolId.G2C_ARENAMATCH_BATTLE:
                    var Rsp461 = new G2C_ArenaMatch_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp461));
                    break;
                case EProtocolId.C2G_ARENAMATCH_BALANCE:
                    var Rsp462 = new C2G_ArenaMatch_Balance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp462));
                    break;
                case EProtocolId.G2C_ARENAMATCH_BALANCE:
                    var Rsp463 = new G2C_ArenaMatch_Balance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp463));
                    break;
                case EProtocolId.C2G_ARENABATTLEREPORT:
                    var Rsp464 = new C2G_ArenaBattleReport(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp464));
                    break;
                case EProtocolId.G2C_ARENABATTLEREPORT:
                    var Rsp465 = new G2C_ArenaBattleReport(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp465));
                    break;
                case EProtocolId.C2G_ARENAMATCH_BUY:
                    var Rsp466 = new C2G_ArenaMatch_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp466));
                    break;
                case EProtocolId.G2C_ARENAMATCH_BUY:
                    var Rsp467 = new G2C_ArenaMatch_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp467));
                    break;
                case EProtocolId.C2G_ARENA_DEFENSE:
                    var Rsp468 = new C2G_Arena_Defense(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp468));
                    break;
                case EProtocolId.G2C_ARENA_DEFENSE:
                    var Rsp469 = new G2C_Arena_Defense(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp469));
                    break;
                case EProtocolId.C2G_ARENA_SETDEFENSE:
                    var Rsp470 = new C2G_Arena_SetDefense(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp470));
                    break;
                case EProtocolId.G2C_ARENA_SETDEFENSE:
                    var Rsp471 = new G2C_Arena_SetDefense(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp471));
                    break;
                case EProtocolId.C2G_BANK_INFO:
                    var Rsp472 = new C2G_Bank_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp472));
                    break;
                case EProtocolId.G2C_BANK_INFO:
                    var Rsp473 = new G2C_Bank_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp473));
                    break;
                case EProtocolId.C2G_BANK_SIGNIN:
                    var Rsp474 = new C2G_Bank_SignIn(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp474));
                    break;
                case EProtocolId.G2C_BANK_SIGNIN:
                    var Rsp475 = new G2C_Bank_SignIn(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp475));
                    break;
                case EProtocolId.C2G_BANK_WARZONE:
                    var Rsp476 = new C2G_Bank_WarZone(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp476));
                    break;
                case EProtocolId.G2C_BANK_WARZONE:
                    var Rsp477 = new G2C_Bank_WarZone(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp477));
                    break;
                case EProtocolId.C2G_BANK_WARZONEAWARD:
                    var Rsp478 = new C2G_Bank_WarZoneAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp478));
                    break;
                case EProtocolId.G2C_BANK_WARZONEAWARD:
                    var Rsp479 = new G2C_Bank_WarZoneAward(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp479));
                    break;
                case EProtocolId.C2G_BANK_WARZONEFIGHT:
                    var Rsp480 = new C2G_Bank_WarZoneFight(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp480));
                    break;
                case EProtocolId.G2C_BANK_WARZONEFIGHT:
                    var Rsp481 = new G2C_Bank_WarZoneFight(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp481));
                    break;
                case EProtocolId.C2G_BANK_WARZONEBALANCE:
                    var Rsp482 = new C2G_Bank_WarZoneBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp482));
                    break;
                case EProtocolId.G2C_BANK_WARZONEBALANCE:
                    var Rsp483 = new G2C_Bank_WarZoneBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp483));
                    break;
                case EProtocolId.C2G_BANK_WARZONEHURTHP:
                    var Rsp484 = new C2G_Bank_WarZoneHurtHp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp484));
                    break;
                case EProtocolId.G2C_BANK_WARZONEHURTHP:
                    var Rsp485 = new G2C_Bank_WarZoneHurtHp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp485));
                    break;
                case EProtocolId.C2G_BANK_ROBBERFIGHT:
                    var Rsp486 = new C2G_Bank_RobberFight(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp486));
                    break;
                case EProtocolId.G2C_BANK_ROBBERFIGHT:
                    var Rsp487 = new G2C_Bank_RobberFight(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp487));
                    break;
                case EProtocolId.C2G_BANK_ROBBERBALANCE:
                    var Rsp488 = new C2G_Bank_RobberBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp488));
                    break;
                case EProtocolId.G2C_BANK_ROBBERBALANCE:
                    var Rsp489 = new G2C_Bank_RobberBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp489));
                    break;
                case EProtocolId.C2G_BANK_TOP:
                    var Rsp490 = new C2G_Bank_Top(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp490));
                    break;
                case EProtocolId.G2C_BANK_TOP:
                    var Rsp491 = new G2C_Bank_Top(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp491));
                    break;
                case EProtocolId.C2G_BANK_TOPCOUNTRY:
                    var Rsp492 = new C2G_Bank_TopCountry(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp492));
                    break;
                case EProtocolId.G2C_BANK_TOPCOUNTRY:
                    var Rsp493 = new G2C_Bank_TopCountry(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp493));
                    break;
                case EProtocolId.C2G_AFFAIRS_LIST:
                    var Rsp494 = new C2G_Affairs_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp494));
                    break;
                case EProtocolId.G2C_AFFAIRS_LIST:
                    var Rsp495 = new G2C_Affairs_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp495));
                    break;
                case EProtocolId.C2G_AFFAIRS_BEGIN:
                    var Rsp496 = new C2G_Affairs_Begin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp496));
                    break;
                case EProtocolId.G2C_AFFAIRS_BEGIN:
                    var Rsp497 = new G2C_Affairs_Begin(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp497));
                    break;
                case EProtocolId.C2G_AFFAIRS_AWARD:
                    var Rsp498 = new C2G_Affairs_Award(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp498));
                    break;
                case EProtocolId.G2C_AFFAIRS_AWARD:
                    var Rsp499 = new G2C_Affairs_Award(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp499));
                    break;
                case EProtocolId.G2C_AFFAIRS_NOTIFY:
                    var Rsp500 = new G2C_Affairs_Notify(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp500));
                    break;
                case EProtocolId.C2G_GRAB_LIST:
                    var Rsp501 = new C2G_Grab_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp501));
                    break;
                case EProtocolId.G2C_GRAB_LIST:
                    var Rsp502 = new G2C_Grab_List(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp502));
                    break;
                case EProtocolId.C2G_GRAB_BATTLE:
                    var Rsp503 = new C2G_Grab_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp503));
                    break;
                case EProtocolId.G2C_GRAB_BATTLE:
                    var Rsp504 = new G2C_Grab_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp504));
                    break;
                case EProtocolId.C2G_GRAB_FIGHT:
                    var Rsp505 = new C2G_Grab_Fight(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp505));
                    break;
                case EProtocolId.G2C_GRAB_FIGHT:
                    var Rsp506 = new G2C_Grab_Fight(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp506));
                    break;
                case EProtocolId.C2G_GRAB_INFO:
                    var Rsp507 = new C2G_Grab_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp507));
                    break;
                case EProtocolId.G2C_GRAB_INFO:
                    var Rsp508 = new G2C_Grab_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp508));
                    break;
                case EProtocolId.C2G_GRAB_GIVEUP:
                    var Rsp509 = new C2G_Grab_GiveUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp509));
                    break;
                case EProtocolId.G2C_GRAB_GIVEUP:
                    var Rsp510 = new G2C_Grab_GiveUp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp510));
                    break;
                case EProtocolId.C2G_GRAB_MINE:
                    var Rsp511 = new C2G_Grab_Mine(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp511));
                    break;
                case EProtocolId.G2C_GRAB_MINE:
                    var Rsp512 = new G2C_Grab_Mine(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp512));
                    break;
                case EProtocolId.C2G_GRAB_BUY:
                    var Rsp513 = new C2G_Grab_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp513));
                    break;
                case EProtocolId.G2C_GRAB_BUY:
                    var Rsp514 = new G2C_Grab_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp514));
                    break;
                case EProtocolId.C2G_BANDITS_INFO:
                    var Rsp515 = new C2G_Bandits_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp515));
                    break;
                case EProtocolId.G2C_BANDITS_INFO:
                    var Rsp516 = new G2C_Bandits_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp516));
                    break;
                case EProtocolId.C2G_BANDITS_BATTLE:
                    var Rsp517 = new C2G_Bandits_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp517));
                    break;
                case EProtocolId.G2C_BANDITS_BATTLE:
                    var Rsp518 = new G2C_Bandits_Battle(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp518));
                    break;
                case EProtocolId.C2G_BANDITS_BATTLEEND:
                    var Rsp519 = new C2G_Bandits_BattleEnd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp519));
                    break;
                case EProtocolId.G2C_BANDITS_BATTLEEND:
                    var Rsp520 = new G2C_Bandits_BattleEnd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp520));
                    break;
                case EProtocolId.C2G_BANDITS_BUY:
                    var Rsp521 = new C2G_Bandits_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp521));
                    break;
                case EProtocolId.G2C_BANDITS_BUY:
                    var Rsp522 = new G2C_Bandits_Buy(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp522));
                    break;
                case EProtocolId.C2G_BANDITS_RESET:
                    var Rsp523 = new C2G_Bandits_Reset(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp523));
                    break;
                case EProtocolId.G2C_BANDITS_RESET:
                    var Rsp524 = new G2C_Bandits_Reset(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp524));
                    break;
                case EProtocolId.C2G_SUPPLY_SUPPLY:
                    var Rsp525 = new C2G_Supply_Supply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp525));
                    break;
                case EProtocolId.G2C_SUPPLY_SUPPLY:
                    var Rsp526 = new G2C_Supply_Supply(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp526));
                    break;
                case EProtocolId.C2G_SUPPLY_SUPPLYAUTO:
                    var Rsp527 = new C2G_Supply_SupplyAuto(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp527));
                    break;
                case EProtocolId.G2C_SUPPLY_SUPPLYAUTO:
                    var Rsp528 = new G2C_Supply_SupplyAuto(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp528));
                    break;
                case EProtocolId.C2G_STRATEGY_MAP:
                    var Rsp529 = new C2G_Strategy_Map(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp529));
                    break;
                case EProtocolId.G2C_STRATEGY_MAP:
                    var Rsp530 = new G2C_Strategy_Map(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp530));
                    break;
                case EProtocolId.C2G_STRATEGY_CITYINFO:
                    var Rsp531 = new C2G_Strategy_CityInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp531));
                    break;
                case EProtocolId.G2C_STRATEGY_CITYINFO:
                    var Rsp532 = new G2C_Strategy_CityInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp532));
                    break;
                case EProtocolId.C2G_STRATEGY_FIGHTINFO:
                    var Rsp533 = new C2G_Strategy_FightInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp533));
                    break;
                case EProtocolId.G2C_STRATEGY_FIGHTINFO:
                    var Rsp534 = new G2C_Strategy_FightInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp534));
                    break;
                case EProtocolId.G2C_STRATEGY_NOTIFYREFRESHWALLHP:
                    var Rsp535 = new G2C_Strategy_NotifyRefreshWallHp(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp535));
                    break;
                case EProtocolId.G2C_STRATEGY_NOTIFYREFRESHCITYINFO:
                    var Rsp536 = new G2C_Strategy_NotifyRefreshCityInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp536));
                    break;
                case EProtocolId.G2C_STRATEGY_NOTIFYREFRESHCITYS:
                    var Rsp537 = new G2C_Strategy_NotifyRefreshCitys(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp537));
                    break;
                case EProtocolId.C2G_STRATEGY_MATCHINGCANCEL:
                    var Rsp538 = new C2G_Strategy_MatchingCancel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp538));
                    break;
                case EProtocolId.G2C_STRATEGY_MATCHINGCANCEL:
                    var Rsp539 = new G2C_Strategy_MatchingCancel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp539));
                    break;
                case EProtocolId.C2G_STRATEGY_DEFENSE:
                    var Rsp540 = new C2G_Strategy_Defense(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp540));
                    break;
                case EProtocolId.G2C_STRATEGY_DEFENSE:
                    var Rsp541 = new G2C_Strategy_Defense(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp541));
                    break;
                case EProtocolId.C2G_STRATEGY_ATTACK:
                    var Rsp542 = new C2G_Strategy_Attack(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp542));
                    break;
                case EProtocolId.G2C_STRATEGY_ATTACK:
                    var Rsp543 = new G2C_Strategy_Attack(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp543));
                    break;
                case EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGENDDEFENSE:
                    var Rsp544 = new G2C_Strategy_NotifyMatchingEndDefense(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp544));
                    break;
                case EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGATTACKNPC:
                    var Rsp545 = new G2C_Strategy_NotifyMatchingAttackNpc(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp545));
                    break;
                case EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGATTACKWALL:
                    var Rsp546 = new G2C_Strategy_NotifyMatchingAttackWall(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp546));
                    break;
                case EProtocolId.C2G_STRATEGY_ATTACKNPCBALANCE:
                    var Rsp547 = new C2G_Strategy_AttackNpcBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp547));
                    break;
                case EProtocolId.G2C_STRATEGY_ATTACKNPCBALANCE:
                    var Rsp548 = new G2C_Strategy_AttackNpcBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp548));
                    break;
                case EProtocolId.C2G_STRATEGY_ATTACKWALLBALANCE:
                    var Rsp549 = new C2G_Strategy_AttackWallBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp549));
                    break;
                case EProtocolId.G2C_STRATEGY_ATTACKWALLBALANCE:
                    var Rsp550 = new G2C_Strategy_AttackWallBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp550));
                    break;
                case EProtocolId.G2C_STRATEGY_NOTIFYMATCHINGATTACKPLAYER:
                    var Rsp551 = new G2C_Strategy_NotifyMatchingAttackPlayer(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp551));
                    break;
                case EProtocolId.C2G_STRATEGY_ATTACKPLAYERBALANCE:
                    var Rsp552 = new C2G_Strategy_AttackPlayerBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp552));
                    break;
                case EProtocolId.G2C_STRATEGY_ATTACKPLAYERBALANCE:
                    var Rsp553 = new G2C_Strategy_AttackPlayerBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp553));
                    break;
                case EProtocolId.G2C_METRO_NOTIFYREFRESHINFO:
                    var Rsp554 = new G2C_Metro_NotifyRefreshInfo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp554));
                    break;
                case EProtocolId.C2G_METRO_TOPSCORE:
                    var Rsp555 = new C2G_Metro_TopScore(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp555));
                    break;
                case EProtocolId.G2C_METRO_TOPSCORE:
                    var Rsp556 = new G2C_Metro_TopScore(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp556));
                    break;
                case EProtocolId.C2G_METRO_MATCHING:
                    var Rsp557 = new C2G_Metro_Matching(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp557));
                    break;
                case EProtocolId.G2C_METRO_MATCHING:
                    var Rsp558 = new G2C_Metro_Matching(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp558));
                    break;
                case EProtocolId.C2G_METRO_MATCHINGCANCEL:
                    var Rsp559 = new C2G_Metro_MatchingCancel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp559));
                    break;
                case EProtocolId.G2C_METRO_MATCHINGCANCEL:
                    var Rsp560 = new G2C_Metro_MatchingCancel(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp560));
                    break;
                case EProtocolId.G2C_METRO_NOTIFYMATCHINGEND:
                    var Rsp561 = new G2C_Metro_NotifyMatchingEnd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp561));
                    break;
                case EProtocolId.G2C_METRO_NOTIFYMATCHINGMETRO:
                    var Rsp562 = new G2C_Metro_NotifyMatchingMetro(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp562));
                    break;
                case EProtocolId.C2G_METRO_ATTACKPLAYERBALANCE:
                    var Rsp563 = new C2G_Metro_AttackPlayerBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp563));
                    break;
                case EProtocolId.G2C_METRO_ATTACKPLAYERBALANCE:
                    var Rsp564 = new G2C_Metro_AttackPlayerBalance(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp564));
                    break;
                case EProtocolId.C2G_BATTLE_DEMO:
                    var Rsp565 = new C2G_Battle_Demo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp565));
                    break;
                case EProtocolId.G2C_BATTLE_DEMO:
                    var Rsp566 = new G2C_Battle_Demo(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp566));
                    break;
                case EProtocolId.C2G_BATTLE_READY:
                    var Rsp567 = new C2G_Battle_Ready(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp567));
                    break;
                case EProtocolId.G2C_BATTLE_READY:
                    var Rsp568 = new G2C_Battle_Ready(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp568));
                    break;
                case EProtocolId.G2C_BATTLE_NOTIFYREADY:
                    var Rsp569 = new G2C_Battle_NotifyReady(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp569));
                    break;
                case EProtocolId.C2G_BATTLE_FORWARDDATA:
                    var Rsp570 = new C2G_Battle_ForwardData(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp570));
                    break;
                case EProtocolId.G2C_BATTLE_FORWARDDATA:
                    var Rsp571 = new G2C_Battle_ForwardData(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp571));
                    break;
                case EProtocolId.G2A_LOAD_SETLOAD:
                    var Rsp572 = new G2A_Load_SetLoad(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp572));
                    break;
                case EProtocolId.B2T_GM_START:
                    var Rsp573 = new B2T_GM_Start(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp573));
                    break;
                case EProtocolId.B2T_GM_LOGIN:
                    var Rsp574 = new B2T_GM_Login(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp574));
                    break;
                case EProtocolId.T2B_GM_LOGIN:
                    var Rsp575 = new T2B_GM_Login(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp575));
                    break;
                case EProtocolId.B2G_GM_CMD:
                    var Rsp576 = new B2G_GM_Cmd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp576));
                    break;
                case EProtocolId.G2B_GM_CMD:
                    var Rsp577 = new G2B_GM_Cmd(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp577));
                    break;
                case EProtocolId.T2B_MAIL_GLOBALLIST:
                    var Rsp578 = new T2B_Mail_GlobalList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp578));
                    break;
                case EProtocolId.B2T_MAIL_GLOBALLIST:
                    var Rsp579 = new B2T_Mail_GlobalList(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp579));
                    break;
                case EProtocolId.B2T_GMMAIL_SEND:
                    var Rsp580 = new B2T_GmMail_Send(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp580));
                    break;
                case EProtocolId.T2B_GMMAIL_SEND:
                    var Rsp581 = new T2B_GmMail_Send(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp581));
                    break;
                case EProtocolId.B2T_EDIT_PLAYER:
                    var Rsp582 = new B2T_Edit_Player(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp582));
                    break;
                case EProtocolId.T2B_EDIT_PLAYER:
                    var Rsp583 = new T2B_Edit_Player(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp583));
                    break;
                case EProtocolId.B2T_BANK_CONF:
                    var Rsp584 = new B2T_Bank_Conf(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp584));
                    break;
                case EProtocolId.T2B_BANK_CONF:
                    var Rsp585 = new T2B_Bank_Conf(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp585));
                    break;
                case EProtocolId.B2T_BANK_INFO:
                    var Rsp586 = new B2T_Bank_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp586));
                    break;
                case EProtocolId.T2B_BANK_INFO:
                    var Rsp587 = new T2B_Bank_Info(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp587));
                    break;
                case EProtocolId.B2T_GM_END:
                    var Rsp588 = new B2T_GM_End(buffer);
                    sb.Append(BasePropManager.GetFieldsDesc(Rsp588));
                    break;

                default:
                    return "";
            }
            return sb.ToString();
        }
    }
}

