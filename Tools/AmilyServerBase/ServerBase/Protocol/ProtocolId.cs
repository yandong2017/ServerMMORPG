
/*
本文件由工具自动生成 请勿手动修改！！！
*/

using System;
using System.Collections.Generic;

namespace ServerBase.Protocol
{
    public enum EProtocolId : short
    {
        UNKNOWN_TYPE = 0,

        // All_Base_Demo - OnBaseDemo
        ALL_BASE_DEMO = 10, 
        // All_Base_Result - OnBaseResult
        ALL_BASE_RESULT = 20, 
        // All_Base_Ping - OnBasePing
        ALL_BASE_PING = 21, 
        // All_Base_GameVersion - OnBaseGameVersion
        ALL_BASE_GAMEVERSION = 22, 
        // C2G_Debug_Cmd - OnDebugCmd
        C2G_DEBUG_CMD = 900, 
        // G2C_Debug_Cmd - OnDebugCmd
        G2C_DEBUG_CMD = 901, 
        // G2C_Login_Connect - OnLoginConnect
        G2C_LOGIN_CONNECT = 1000, 
        // C2L_Login_UserLogin - OnLoginUserLogin
        C2L_LOGIN_USERLOGIN = 1001, 
        // L2C_Login_UserLogin - OnLoginUserLogin
        L2C_LOGIN_USERLOGIN = 1002, 
        // C2G_Login_PlayerLogin - OnLoginPlayerLogin
        C2G_LOGIN_PLAYERLOGIN = 1003, 
        // G2C_Login_PlayerLogin - OnLoginPlayerLogin
        G2C_LOGIN_PLAYERLOGIN = 1004, 
        // C2G_Login_PlayerCreate - OnLoginPlayerCreate
        C2G_LOGIN_PLAYERCREATE = 1005, 
        // G2C_Login_PlayerCreate - OnLoginPlayerCreate
        G2C_LOGIN_PLAYERCREATE = 1006, 
        // G2C_Login_Replaced - OnLoginReplaced
        G2C_LOGIN_REPLACED = 1007, 
        // G2C_Login_Ban - OnLoginBan
        G2C_LOGIN_BAN = 1008, 
        // C2G_Login_ListState - OnLoginListState
        C2G_LOGIN_LISTSTATE = 1010, 
        // G2C_Login_ListState - OnLoginListState
        G2C_LOGIN_LISTSTATE = 1011, 
        // C2G_Login_CheckName - OnLoginCheckName
        C2G_LOGIN_CHECKNAME = 1012, 
        // G2C_Login_CheckName - OnLoginCheckName
        G2C_LOGIN_CHECKNAME = 1013, 
        // C2G_Info_GetAll - OnInfoGetAll
        C2G_INFO_GETALL = 1100, 
        // G2C_Info_GetAll - OnInfoGetAll
        G2C_INFO_GETALL = 1101, 
        // G2C_Info_PushAll - OnInfoPushAll
        G2C_INFO_PUSHALL = 1102, 
        // G2C_Info_PushItem - OnInfoPushItem
        G2C_INFO_PUSHITEM = 1103, 
        // G2C_Info_PushEquip - OnInfoPushEquip
        G2C_INFO_PUSHEQUIP = 1104, 
        // G2C_Info_PushWarrior - OnInfoPushWarrior
        G2C_INFO_PUSHWARRIOR = 1105, 
        // G2C_Info_PushUpdate - OnInfoPushUpdate
        G2C_INFO_PUSHUPDATE = 1109, 
        // C2G_Info_ChangeName - OnInfoChangeName
        C2G_INFO_CHANGENAME = 1110, 
        // G2C_Info_ChangeName - OnInfoChangeName
        G2C_INFO_CHANGENAME = 1111, 
        // C2G_Info_ChangeFlagClient - OnInfoChangeFlagClient
        C2G_INFO_CHANGEFLAGCLIENT = 1112, 
        // G2C_Info_ChangeFlagClient - OnInfoChangeFlagClient
        G2C_INFO_CHANGEFLAGCLIENT = 1113, 
        // C2G_Info_ChangeHeadIndex - OnInfoChangeHeadIndex
        C2G_INFO_CHANGEHEADINDEX = 1114, 
        // G2C_Info_ChangeHeadIndex - OnInfoChangeHeadIndex
        G2C_INFO_CHANGEHEADINDEX = 1115, 
        // C2G_Info_ChangeHeadData - OnInfoChangeHeadData
        C2G_INFO_CHANGEHEADDATA = 1116, 
        // G2C_Info_ChangeHeadData - OnInfoChangeHeadData
        G2C_INFO_CHANGEHEADDATA = 1117, 
        // C2G_Info_SubmitBug - OnInfoSubmitBug
        C2G_INFO_SUBMITBUG = 1118, 
        // G2C_Info_SubmitBug - OnInfoSubmitBug
        G2C_INFO_SUBMITBUG = 1119, 
        // G2C_Info_NotifyLevelUp - OnInfoNotifyLevelUp
        G2C_INFO_NOTIFYLEVELUP = 1120, 
        // C2G_Info_PlayerData - OnInfoPlayerData
        C2G_INFO_PLAYERDATA = 1121, 
        // G2C_Info_PlayerData - OnInfoPlayerData
        G2C_INFO_PLAYERDATA = 1122, 
        // C2G_Info_ChangeSignature - OnInfoChangeSignature
        C2G_INFO_CHANGESIGNATURE = 1123, 
        // G2C_Info_ChangeSignature - OnInfoChangeSignature
        G2C_INFO_CHANGESIGNATURE = 1124, 
        // C2G_Notice_System - OnNoticeSystem
        C2G_NOTICE_SYSTEM = 1200, 
        // G2C_Notice_System - OnNoticeSystem
        G2C_NOTICE_SYSTEM = 1201, 
        // C2G_Notice_Activity - OnNoticeActivity
        C2G_NOTICE_ACTIVITY = 1202, 
        // G2C_Notice_Activity - OnNoticeActivity
        G2C_NOTICE_ACTIVITY = 1203, 
        // G2C_Notice_Rolling - OnNoticeRolling
        G2C_NOTICE_ROLLING = 1204, 
        // C2G_Mail_List - OnMailList
        C2G_MAIL_LIST = 1300, 
        // G2C_Mail_List - OnMailList
        G2C_MAIL_LIST = 1301, 
        // C2G_Mail_Read - OnMailRead
        C2G_MAIL_READ = 1302, 
        // G2C_Mail_Read - OnMailRead
        G2C_MAIL_READ = 1303, 
        // C2G_Mail_Get - OnMailGet
        C2G_MAIL_GET = 1304, 
        // G2C_Mail_Get - OnMailGet
        G2C_MAIL_GET = 1305, 
        // C2G_Mail_GetAll - OnMailGetAll
        C2G_MAIL_GETALL = 1306, 
        // G2C_Mail_GetAll - OnMailGetAll
        G2C_MAIL_GETALL = 1307, 
        // C2G_Mail_Delete - OnMailDelete
        C2G_MAIL_DELETE = 1308, 
        // G2C_Mail_Delete - OnMailDelete
        G2C_MAIL_DELETE = 1309, 
        // C2G_Mail_DeleteReaded - OnMailDeleteReaded
        C2G_MAIL_DELETEREADED = 1310, 
        // G2C_Mail_DeleteReaded - OnMailDeleteReaded
        G2C_MAIL_DELETEREADED = 1311, 
        // C2G_Mail_Save - OnMailSave
        C2G_MAIL_SAVE = 1312, 
        // G2C_Mail_Save - OnMailSave
        G2C_MAIL_SAVE = 1313, 
        // C2G_Mail_Send - OnMailSend
        C2G_MAIL_SEND = 1314, 
        // G2C_Mail_Send - OnMailSend
        G2C_MAIL_SEND = 1315, 
        // C2G_Chat_Send - OnChatSend
        C2G_CHAT_SEND = 1400, 
        // G2C_Chat_Send - OnChatSend
        G2C_CHAT_SEND = 1401, 
        // G2C_Chat_Receive - OnChatReceive
        G2C_CHAT_RECEIVE = 1402, 
        // C2G_Chat_GetPrivateChat - OnChatGetPrivateChat
        C2G_CHAT_GETPRIVATECHAT = 1403, 
        // G2C_Chat_GetPrivateChat - OnChatGetPrivateChat
        G2C_CHAT_GETPRIVATECHAT = 1404, 
        // C2G_Chat_Remove - OnChatRemove
        C2G_CHAT_REMOVE = 1405, 
        // G2C_Chat_Remove - OnChatRemove
        G2C_CHAT_REMOVE = 1406, 
        // C2G_Friend_List - OnFriendList
        C2G_FRIEND_LIST = 1500, 
        // G2C_Friend_List - OnFriendList
        G2C_FRIEND_LIST = 1501, 
        // C2G_Friend_ListApply - OnFriendListApply
        C2G_FRIEND_LISTAPPLY = 1502, 
        // G2C_Friend_ListApply - OnFriendListApply
        G2C_FRIEND_LISTAPPLY = 1503, 
        // C2G_Friend_ListRecommend - OnFriendListRecommend
        C2G_FRIEND_LISTRECOMMEND = 1504, 
        // G2C_Friend_ListRecommend - OnFriendListRecommend
        G2C_FRIEND_LISTRECOMMEND = 1505, 
        // C2G_Friend_Apply - OnFriendApply
        C2G_FRIEND_APPLY = 1506, 
        // G2C_Friend_Apply - OnFriendApply
        G2C_FRIEND_APPLY = 1507, 
        // C2G_Friend_Add - OnFriendAdd
        C2G_FRIEND_ADD = 1508, 
        // G2C_Friend_Add - OnFriendAdd
        G2C_FRIEND_ADD = 1509, 
        // C2G_Friend_Remove - OnFriendRemove
        C2G_FRIEND_REMOVE = 1510, 
        // G2C_Friend_Remove - OnFriendRemove
        G2C_FRIEND_REMOVE = 1511, 
        // C2G_Friend_Give - OnFriendGive
        C2G_FRIEND_GIVE = 1512, 
        // G2C_Friend_Give - OnFriendGive
        G2C_FRIEND_GIVE = 1513, 
        // C2G_Friend_Receive - OnFriendReceive
        C2G_FRIEND_RECEIVE = 1514, 
        // G2C_Friend_Receive - OnFriendReceive
        G2C_FRIEND_RECEIVE = 1515, 
        // C2G_Friend_Screen - OnFriendScreen
        C2G_FRIEND_SCREEN = 1516, 
        // G2C_Friend_Screen - OnFriendScreen
        G2C_FRIEND_SCREEN = 1517, 
        // C2G_Map_ListCity - OnMapListCity
        C2G_MAP_LISTCITY = 1900, 
        // G2C_Map_ListCity - OnMapListCity
        G2C_MAP_LISTCITY = 1901, 
        // C2G_Map_CityInfo - OnMapCityInfo
        C2G_MAP_CITYINFO = 1903, 
        // G2C_Map_CityInfo - OnMapCityInfo
        G2C_MAP_CITYINFO = 1904, 
        // C2G_Map_ListMyCity - OnMapListMyCity
        C2G_MAP_LISTMYCITY = 1906, 
        // G2C_Map_ListMyCity - OnMapListMyCity
        G2C_MAP_LISTMYCITY = 1907, 
        // C2G_Item_List - OnItemList
        C2G_ITEM_LIST = 2000, 
        // G2C_Item_List - OnItemList
        G2C_ITEM_LIST = 2001, 
        // C2G_Item_Sell - OnItemSell
        C2G_ITEM_SELL = 2002, 
        // G2C_Item_Sell - OnItemSell
        G2C_ITEM_SELL = 2003, 
        // C2G_Item_Use - OnItemUse
        C2G_ITEM_USE = 2004, 
        // G2C_Item_Use - OnItemUse
        G2C_ITEM_USE = 2005, 
        // C2G_Item_ResourcesList - OnItemResourcesList
        C2G_ITEM_RESOURCESLIST = 2006, 
        // G2C_Item_ResourcesList - OnItemResourcesList
        G2C_ITEM_RESOURCESLIST = 2007, 
        // C2G_Item_ResourcesUse - OnItemResourcesUse
        C2G_ITEM_RESOURCESUSE = 2008, 
        // G2C_Item_ResourcesUse - OnItemResourcesUse
        G2C_ITEM_RESOURCESUSE = 2009, 
        // C2G_Item_ResourcesBuy - OnItemResourcesBuy
        C2G_ITEM_RESOURCESBUY = 2010, 
        // G2C_Item_ResourcesBuy - OnItemResourcesBuy
        G2C_ITEM_RESOURCESBUY = 2011, 
        // C2G_Item_CombatUse - OnItemCombatUse
        C2G_ITEM_COMBATUSE = 2012, 
        // G2C_Item_CombatUse - OnItemCombatUse
        G2C_ITEM_COMBATUSE = 2013, 
        // C2G_Equip_List - OnEquipList
        C2G_EQUIP_LIST = 2100, 
        // G2C_Equip_List - OnEquipList
        G2C_EQUIP_LIST = 2101, 
        // C2G_Equip_WarriorList - OnEquipWarriorList
        C2G_EQUIP_WARRIORLIST = 2102, 
        // G2C_Equip_WarriorList - OnEquipWarriorList
        G2C_EQUIP_WARRIORLIST = 2103, 
        // C2G_Equip_WarriorAll - OnEquipWarriorAll
        C2G_EQUIP_WARRIORALL = 2104, 
        // G2C_Equip_WarriorAll - OnEquipWarriorAll
        G2C_EQUIP_WARRIORALL = 2105, 
        // C2G_Equip_WarriorWield - OnEquipWarriorWield
        C2G_EQUIP_WARRIORWIELD = 2106, 
        // G2C_Equip_WarriorWield - OnEquipWarriorWield
        G2C_EQUIP_WARRIORWIELD = 2107, 
        // C2G_Equip_WarriorRemove - OnEquipWarriorRemove
        C2G_EQUIP_WARRIORREMOVE = 2108, 
        // G2C_Equip_WarriorRemove - OnEquipWarriorRemove
        G2C_EQUIP_WARRIORREMOVE = 2109, 
        // C2G_Equip_WarriorResolve - OnEquipWarriorResolve
        C2G_EQUIP_WARRIORRESOLVE = 2110, 
        // G2C_Equip_WarriorResolve - OnEquipWarriorResolve
        G2C_EQUIP_WARRIORRESOLVE = 2111, 
        // C2G_Equip_Rename - OnEquipRename
        C2G_EQUIP_RENAME = 2112, 
        // G2C_Equip_Rename - OnEquipRename
        G2C_EQUIP_RENAME = 2113, 
        // C2G_Equip_IntensifyInfo - OnEquipIntensifyInfo
        C2G_EQUIP_INTENSIFYINFO = 2114, 
        // G2C_Equip_IntensifyInfo - OnEquipIntensifyInfo
        G2C_EQUIP_INTENSIFYINFO = 2115, 
        // C2G_Equip_Intensify - OnEquipIntensify
        C2G_EQUIP_INTENSIFY = 2116, 
        // G2C_Equip_Intensify - OnEquipIntensify
        G2C_EQUIP_INTENSIFY = 2117, 
        // C2G_Warrior_WarriorList - OnWarriorWarriorList
        C2G_WARRIOR_WARRIORLIST = 2200, 
        // G2C_Warrior_WarriorList - OnWarriorWarriorList
        G2C_WARRIOR_WARRIORLIST = 2201, 
        // C2G_Warrior_Lock - OnWarriorLock
        C2G_WARRIOR_LOCK = 2202, 
        // G2C_Warrior_Lock - OnWarriorLock
        G2C_WARRIOR_LOCK = 2203, 
        // C2G_Warrior_Advance - OnWarriorAdvance
        C2G_WARRIOR_ADVANCE = 2204, 
        // G2C_Warrior_Advance - OnWarriorAdvance
        G2C_WARRIOR_ADVANCE = 2205, 
        // C2G_Warrior_Rename - OnWarriorRename
        C2G_WARRIOR_RENAME = 2206, 
        // G2C_Warrior_Rename - OnWarriorRename
        G2C_WARRIOR_RENAME = 2207, 
        // C2G_Warrior_UpLevel - OnWarriorUpLevel
        C2G_WARRIOR_UPLEVEL = 2208, 
        // G2C_Warrior_UpLevel - OnWarriorUpLevel
        G2C_WARRIOR_UPLEVEL = 2209, 
        // G2C_Warrior_NotifyLevelUp - OnWarriorNotifyLevelUp
        G2C_WARRIOR_NOTIFYLEVELUP = 2210, 
        // C2G_Warrior_ImproveInfo - OnWarriorImproveInfo
        C2G_WARRIOR_IMPROVEINFO = 2211, 
        // G2C_Warrior_ImproveInfo - OnWarriorImproveInfo
        G2C_WARRIOR_IMPROVEINFO = 2212, 
        // C2G_Warrior_Improve - OnWarriorImprove
        C2G_WARRIOR_IMPROVE = 2213, 
        // G2C_Warrior_Improve - OnWarriorImprove
        G2C_WARRIOR_IMPROVE = 2214, 
        // C2G_Warrior_Star - OnWarriorStar
        C2G_WARRIOR_STAR = 2215, 
        // G2C_Warrior_Star - OnWarriorStar
        G2C_WARRIOR_STAR = 2216, 
        // C2G_Warrior_Skill - OnWarriorSkill
        C2G_WARRIOR_SKILL = 2217, 
        // G2C_Warrior_Skill - OnWarriorSkill
        G2C_WARRIOR_SKILL = 2218, 
        // C2G_Warrior_WakeUnlock - OnWarriorWakeUnlock
        C2G_WARRIOR_WAKEUNLOCK = 2219, 
        // G2C_Warrior_WakeUnlock - OnWarriorWakeUnlock
        G2C_WARRIOR_WAKEUNLOCK = 2220, 
        // C2G_Warrior_WakeInfo - OnWarriorWakeInfo
        C2G_WARRIOR_WAKEINFO = 2221, 
        // G2C_Warrior_WakeInfo - OnWarriorWakeInfo
        G2C_WARRIOR_WAKEINFO = 2222, 
        // C2G_Warrior_WakeUp - OnWarriorWakeUp
        C2G_WARRIOR_WAKEUP = 2223, 
        // G2C_Warrior_WakeUp - OnWarriorWakeUp
        G2C_WARRIOR_WAKEUP = 2224, 
        // C2G_Warrior_Sell - OnWarriorSell
        C2G_WARRIOR_SELL = 2225, 
        // G2C_Warrior_Sell - OnWarriorSell
        G2C_WARRIOR_SELL = 2226, 
        // C2G_BuildingPlayer_List - OnBuildingPlayerList
        C2G_BUILDINGPLAYER_LIST = 2300, 
        // G2C_BuildingPlayer_List - OnBuildingPlayerList
        G2C_BUILDINGPLAYER_LIST = 2301, 
        // G2C_BuildingPlayer_PushInfoSimple - OnBuildingPlayerPushInfoSimple
        G2C_BUILDINGPLAYER_PUSHINFOSIMPLE = 2302, 
        // C2G_BuildingPlayer_Harvest - OnBuildingPlayerHarvest
        C2G_BUILDINGPLAYER_HARVEST = 2303, 
        // G2C_BuildingPlayer_Harvest - OnBuildingPlayerHarvest
        G2C_BUILDINGPLAYER_HARVEST = 2304, 
        // C2G_BuildingPlayer_HarvestAll - OnBuildingPlayerHarvestAll
        C2G_BUILDINGPLAYER_HARVESTALL = 2305, 
        // G2C_BuildingPlayer_HarvestAll - OnBuildingPlayerHarvestAll
        G2C_BUILDINGPLAYER_HARVESTALL = 2306, 
        // C2G_BuildingPlayer_Build - OnBuildingPlayerBuild
        C2G_BUILDINGPLAYER_BUILD = 2307, 
        // G2C_BuildingPlayer_Build - OnBuildingPlayerBuild
        G2C_BUILDINGPLAYER_BUILD = 2308, 
        // G2C_BuildingPlayer_NotifyBuilt - OnBuildingPlayerNotifyBuilt
        G2C_BUILDINGPLAYER_NOTIFYBUILT = 2309, 
        // C2G_Smith_Start - OnSmithStart
        C2G_SMITH_START = 2311, 
        // G2C_Smith_Start - OnSmithStart
        G2C_SMITH_START = 2312, 
        // C2G_Smith_Do - OnSmithDo
        C2G_SMITH_DO = 2313, 
        // G2C_Smith_Do - OnSmithDo
        G2C_SMITH_DO = 2314, 
        // C2G_Science_List - OnScienceList
        C2G_SCIENCE_LIST = 2316, 
        // G2C_Science_List - OnScienceList
        G2C_SCIENCE_LIST = 2317, 
        // C2G_Science_Learn - OnScienceLearn
        C2G_SCIENCE_LEARN = 2318, 
        // G2C_Science_Learn - OnScienceLearn
        G2C_SCIENCE_LEARN = 2319, 
        // C2G_Science_Info - OnScienceInfo
        C2G_SCIENCE_INFO = 2320, 
        // G2C_Science_Info - OnScienceInfo
        G2C_SCIENCE_INFO = 2321, 
        // C2G_Science_Cancel - OnScienceCancel
        C2G_SCIENCE_CANCEL = 2322, 
        // G2C_Science_Cancel - OnScienceCancel
        G2C_SCIENCE_CANCEL = 2323, 
        // G2C_Science_Notify - OnScienceNotify
        G2C_SCIENCE_NOTIFY = 2324, 
        // C2G_Recruit_Info - OnRecruitInfo
        C2G_RECRUIT_INFO = 2326, 
        // G2C_Recruit_Info - OnRecruitInfo
        G2C_RECRUIT_INFO = 2327, 
        // C2G_Recruit_Start - OnRecruitStart
        C2G_RECRUIT_START = 2328, 
        // G2C_Recruit_Start - OnRecruitStart
        G2C_RECRUIT_START = 2329, 
        // G2C_Recruit_NotifyComplete - OnRecruitNotifyComplete
        G2C_RECRUIT_NOTIFYCOMPLETE = 2330, 
        // C2G_Player_SpeedupInfo - OnPlayerSpeedupInfo
        C2G_PLAYER_SPEEDUPINFO = 2331, 
        // G2C_Player_SpeedupInfo - OnPlayerSpeedupInfo
        G2C_PLAYER_SPEEDUPINFO = 2332, 
        // C2G_BuildingPlayer_SpeedupComplete - OnBuildingPlayerSpeedupComplete
        C2G_BUILDINGPLAYER_SPEEDUPCOMPLETE = 2333, 
        // G2C_BuildingPlayer_SpeedupComplete - OnBuildingPlayerSpeedupComplete
        G2C_BUILDINGPLAYER_SPEEDUPCOMPLETE = 2334, 
        // C2G_Recruit_Speedup - OnRecruitSpeedup
        C2G_RECRUIT_SPEEDUP = 2335, 
        // G2C_Recruit_Speedup - OnRecruitSpeedup
        G2C_RECRUIT_SPEEDUP = 2336, 
        // C2G_Science_Fast - OnScienceFast
        C2G_SCIENCE_FAST = 2337, 
        // G2C_Science_Fast - OnScienceFast
        G2C_SCIENCE_FAST = 2338, 
        // C2G_Player_SpeedupBuy - OnPlayerSpeedupBuy
        C2G_PLAYER_SPEEDUPBUY = 2339, 
        // G2C_Player_SpeedupBuy - OnPlayerSpeedupBuy
        G2C_PLAYER_SPEEDUPBUY = 2340, 
        // C2G_Player_Speedup - OnPlayerSpeedup
        C2G_PLAYER_SPEEDUP = 2341, 
        // G2C_Player_Speedup - OnPlayerSpeedup
        G2C_PLAYER_SPEEDUP = 2342, 
        // C2G_Help_Fast - OnHelpFast
        C2G_HELP_FAST = 2343, 
        // G2C_Help_Fast - OnHelpFast
        G2C_HELP_FAST = 2344, 
        // C2G_City_CityInfo - OnCityCityInfo
        C2G_CITY_CITYINFO = 2400, 
        // G2C_City_CityInfo - OnCityCityInfo
        G2C_CITY_CITYINFO = 2401, 
        // C2G_City_ListCity - OnCityListCity
        C2G_CITY_LISTCITY = 2402, 
        // G2C_City_ListCity - OnCityListCity
        G2C_CITY_LISTCITY = 2403, 
        // C2G_City_DepotInfo - OnCityDepotInfo
        C2G_CITY_DEPOTINFO = 2404, 
        // G2C_City_DepotInfo - OnCityDepotInfo
        G2C_CITY_DEPOTINFO = 2405, 
        // C2G_CityBuilding_List - OnCityBuildingList
        C2G_CITYBUILDING_LIST = 2500, 
        // G2C_CityBuilding_List - OnCityBuildingList
        G2C_CITYBUILDING_LIST = 2501, 
        // C2G_CityBuilding_Build - OnCityBuildingBuild
        C2G_CITYBUILDING_BUILD = 2502, 
        // G2C_CityBuilding_Build - OnCityBuildingBuild
        G2C_CITYBUILDING_BUILD = 2503, 
        // C2G_Wall_Info - OnWallInfo
        C2G_WALL_INFO = 2600, 
        // G2C_Wall_Info - OnWallInfo
        G2C_WALL_INFO = 2601, 
        // C2G_Wall_Repair - OnWallRepair
        C2G_WALL_REPAIR = 2602, 
        // G2C_Wall_Repair - OnWallRepair
        G2C_WALL_REPAIR = 2603, 
        // C2G_Wall_MakeWork - OnWallMakeWork
        C2G_WALL_MAKEWORK = 2604, 
        // G2C_Wall_MakeWork - OnWallMakeWork
        G2C_WALL_MAKEWORK = 2605, 
        // C2G_Camp_Info - OnCampInfo
        C2G_CAMP_INFO = 2700, 
        // G2C_Camp_Info - OnCampInfo
        G2C_CAMP_INFO = 2701, 
        // C2G_City_ShopInfo - OnCityShopInfo
        C2G_CITY_SHOPINFO = 2800, 
        // G2C_City_ShopInfo - OnCityShopInfo
        G2C_CITY_SHOPINFO = 2801, 
        // C2G_City_ShopBuy - OnCityShopBuy
        C2G_CITY_SHOPBUY = 2802, 
        // G2C_City_ShopBuy - OnCityShopBuy
        G2C_CITY_SHOPBUY = 2803, 
        // C2G_Shop_List - OnShopList
        C2G_SHOP_LIST = 3000, 
        // G2C_Shop_List - OnShopList
        G2C_SHOP_LIST = 3001, 
        // C2G_Shop_Buy - OnShopBuy
        C2G_SHOP_BUY = 3002, 
        // G2C_Shop_Buy - OnShopBuy
        G2C_SHOP_BUY = 3003, 
        // C2G_Shop_QuickBuy - OnShopQuickBuy
        C2G_SHOP_QUICKBUY = 3004, 
        // G2C_Shop_QuickBuy - OnShopQuickBuy
        G2C_SHOP_QUICKBUY = 3005, 
        // C2G_Refresh_Diamond_Store - OnRefreshDiamond
        C2G_REFRESH_DIAMOND_STORE = 3006, 
        // G2C_Refresh_Diamond_Store - OnRefreshDiamond
        G2C_REFRESH_DIAMOND_STORE = 3007, 
        // C2G_Shop_BuyWarriorBag - OnShopBuyWarriorBag
        C2G_SHOP_BUYWARRIORBAG = 3008, 
        // G2C_Shop_BuyWarriorBag - OnShopBuyWarriorBag
        G2C_SHOP_BUYWARRIORBAG = 3009, 
        // C2G_Buy_Gold - OnBuyGold
        C2G_BUY_GOLD = 3010, 
        // G2C_Buy_Gold - OnBuyGold
        G2C_BUY_GOLD = 3011, 
        // C2G_Exchange_List - OnExchangeList
        C2G_EXCHANGE_LIST = 3100, 
        // G2C_Exchange_List - OnExchangeList
        G2C_EXCHANGE_LIST = 3101, 
        // C2G_Exchange_Shelves - OnExchangeShelves
        C2G_EXCHANGE_SHELVES = 3102, 
        // G2C_Exchange_Shelves - OnExchangeShelves
        G2C_EXCHANGE_SHELVES = 3103, 
        // C2G_Exchange_Revoke - OnExchangeRevoke
        C2G_EXCHANGE_REVOKE = 3104, 
        // G2C_Exchange_Revoke - OnExchangeRevoke
        G2C_EXCHANGE_REVOKE = 3105, 
        // C2G_Exchange_Transaction - OnExchangeTransaction
        C2G_EXCHANGE_TRANSACTION = 3106, 
        // G2C_Exchange_Transaction - OnExchangeTransaction
        G2C_EXCHANGE_TRANSACTION = 3107, 
        // C2G_GetTransactionLogList - 
        C2G_GETTRANSACTIONLOGLIST = 3109, 
        // G2C_GetTransactionLogList - 
        G2C_GETTRANSACTIONLOGLIST = 3110, 
        // C2G_Auction_ListItem - OnAuctionListItem
        C2G_AUCTION_LISTITEM = 3201, 
        // G2C_Auction_ListItem - OnAuctionListItem
        G2C_AUCTION_LISTITEM = 3202, 
        // C2G_Auction_SellItem - OnAuctionSellItem
        C2G_AUCTION_SELLITEM = 3203, 
        // G2C_Auction_SellItem - OnAuctionSellItem
        G2C_AUCTION_SELLITEM = 3204, 
        // C2G_Auction_ReturnItem - OnAuctionReturnItem
        C2G_AUCTION_RETURNITEM = 3205, 
        // G2C_Auction_ReturnItem - OnAuctionReturnItem
        G2C_AUCTION_RETURNITEM = 3206, 
        // C2G_Auction_BuyItem - OnAuctionBuyItem
        C2G_AUCTION_BUYITEM = 3207, 
        // G2C_Auction_BuyItem - OnAuctionBuyItem
        G2C_AUCTION_BUYITEM = 3208, 
        // C2G_Auction_ListEquip - OnAuctionListEquip
        C2G_AUCTION_LISTEQUIP = 3210, 
        // G2C_Auction_ListEquip - OnAuctionListEquip
        G2C_AUCTION_LISTEQUIP = 3211, 
        // C2G_Auction_SellEquip - OnAuctionSellEquip
        C2G_AUCTION_SELLEQUIP = 3212, 
        // G2C_Auction_SellEquip - OnAuctionSellEquip
        G2C_AUCTION_SELLEQUIP = 3213, 
        // C2G_Auction_ReturnEquip - OnAuctionReturnEquip
        C2G_AUCTION_RETURNEQUIP = 3214, 
        // G2C_Auction_ReturnEquip - OnAuctionReturnEquip
        G2C_AUCTION_RETURNEQUIP = 3215, 
        // C2G_Auction_BuyEquip - OnAuctionBuyEquip
        C2G_AUCTION_BUYEQUIP = 3216, 
        // G2C_Auction_BuyEquip - OnAuctionBuyEquip
        G2C_AUCTION_BUYEQUIP = 3217, 
        // C2G_Auction_ListWarrior - OnAuctionListWarrior
        C2G_AUCTION_LISTWARRIOR = 3219, 
        // G2C_Auction_ListWarrior - OnAuctionListWarrior
        G2C_AUCTION_LISTWARRIOR = 3220, 
        // C2G_Auction_SellWarrior - OnAuctionSellWarrior
        C2G_AUCTION_SELLWARRIOR = 3221, 
        // G2C_Auction_SellWarrior - OnAuctionSellWarrior
        G2C_AUCTION_SELLWARRIOR = 3222, 
        // C2G_Auction_ReturnWarrior - OnAuctionReturnWarrior
        C2G_AUCTION_RETURNWARRIOR = 3223, 
        // G2C_Auction_ReturnWarrior - OnAuctionReturnWarrior
        G2C_AUCTION_RETURNWARRIOR = 3224, 
        // C2G_Auction_BuyWarrior - OnAuctionBuyWarrior
        C2G_AUCTION_BUYWARRIOR = 3225, 
        // G2C_Auction_BuyWarrior - OnAuctionBuyWarrior
        G2C_AUCTION_BUYWARRIOR = 3226, 
        // C2G_Auction_Search - OnAuctionSearch
        C2G_AUCTION_SEARCH = 3227, 
        // G2C_Auction_Search - OnAuctionSearch
        G2C_AUCTION_SEARCH = 3228, 
        // C2G_Auction_GetLog - OnAuctionGetLog
        C2G_AUCTION_GETLOG = 3230, 
        // G2C_Auction_GetLog - OnAuctionGetLog
        G2C_AUCTION_GETLOG = 3231, 
        // C2G_Draw_GetInfo - OnDrawGetInfo
        C2G_DRAW_GETINFO = 3300, 
        // G2C_Draw_GetInfo - OnDrawGetInfo
        G2C_DRAW_GETINFO = 3301, 
        // C2G_Draw_Luck - OnDrawLuck
        C2G_DRAW_LUCK = 3302, 
        // G2C_Draw_Luck - OnDrawLuck
        G2C_DRAW_LUCK = 3303, 
        // C2G_Draw_GetAward - OnDrawGetAward
        C2G_DRAW_GETAWARD = 3304, 
        // G2C_Draw_GetAward - OnDrawGetAward
        G2C_DRAW_GETAWARD = 3305, 
        // C2G_Cdkey_Use - OnCdkeyUse
        C2G_CDKEY_USE = 3400, 
        // G2C_Cdkey_Use - OnCdkeyUse
        G2C_CDKEY_USE = 3401, 
        // C2G_Top_Toplist - OnTopToplist
        C2G_TOP_TOPLIST = 4000, 
        // G2C_Top_Toplist - OnTopToplist
        G2C_TOP_TOPLIST = 4001, 
        // C2G_Top_Info - OnTopInfo
        C2G_TOP_INFO = 4002, 
        // G2C_Top_Info - OnTopInfo
        G2C_TOP_INFO = 4003, 
        // C2G_Task_List - OnTaskList
        C2G_TASK_LIST = 4100, 
        // G2C_Task_List - OnTaskList
        G2C_TASK_LIST = 4101, 
        // C2G_Task_Get - OnTaskGet
        C2G_TASK_GET = 4102, 
        // G2C_Task_Get - OnTaskGet
        G2C_TASK_GET = 4103, 
        // C2G_Task_GetAll - OnTaskGetAll
        C2G_TASK_GETALL = 4104, 
        // G2C_Task_GetAll - OnTaskGetAll
        G2C_TASK_GETALL = 4105, 
        // C2G_Task_Everyday - OnTaskEveryday
        C2G_TASK_EVERYDAY = 4106, 
        // G2C_Task_Everyday - OnTaskEveryday
        G2C_TASK_EVERYDAY = 4107, 
        // C2G_Task_EverydayAward - OnTaskEverydayAward
        C2G_TASK_EVERYDAYAWARD = 4108, 
        // G2C_Task_EverydayAward - OnTaskEverydayAward
        G2C_TASK_EVERYDAYAWARD = 4109, 
        // C2G_Sign_Info - OnSignInfo
        C2G_SIGN_INFO = 4300, 
        // G2C_Sign_Info - OnSignInfo
        G2C_SIGN_INFO = 4301, 
        // C2G_Sign - 
        C2G_SIGN = 4302, 
        // G2C_Sign - 
        G2C_SIGN = 4303, 
        // C2G_ReSign - 
        C2G_RESIGN = 4304, 
        // G2C_ReSign - 
        G2C_RESIGN = 4305, 
        // C2G_Buff_Info - OnBuffInfo
        C2G_BUFF_INFO = 4400, 
        // G2C_Buff_Info - OnBuffInfo
        G2C_BUFF_INFO = 4401, 
        // C2G_Acitvity_List - OnAcitvityList
        C2G_ACITVITY_LIST = 5000, 
        // G2C_Acitvity_List - OnAcitvityList
        G2C_ACITVITY_LIST = 5001, 
        // C2G_Acitvity_RebateInfo - OnAcitvityRebateInfo
        C2G_ACITVITY_REBATEINFO = 5100, 
        // G2C_Acitvity_RebateInfo - OnAcitvityRebateInfo
        G2C_ACITVITY_REBATEINFO = 5101, 
        // C2G_Acitvity_7Day - OnAcitvity7Day
        C2G_ACITVITY_7DAY = 5200, 
        // G2C_Acitvity_7Day - OnAcitvity7Day
        G2C_ACITVITY_7DAY = 5201, 
        // C2G_Acitvity_7DayGet - OnAcitvity7DayGet
        C2G_ACITVITY_7DAYGET = 5202, 
        // G2C_Acitvity_7DayGet - OnAcitvity7DayGet
        G2C_ACITVITY_7DAYGET = 5203, 
        // C2G_Acitvity_7DayLoginInfo - OnAcitvity7DayLoginInfo
        C2G_ACITVITY_7DAYLOGININFO = 5204, 
        // G2C_Acitvity_7DayLoginInfo - OnAcitvity7DayLoginInfo
        G2C_ACITVITY_7DAYLOGININFO = 5205, 
        // C2G_Acitvity_7DayLoginGet - OnAcitvity7DayLoginGet
        C2G_ACITVITY_7DAYLOGINGET = 5206, 
        // G2C_Acitvity_7DayLoginGet - OnAcitvity7DayLoginGet
        G2C_ACITVITY_7DAYLOGINGET = 5207, 
        // C2G_Welfare_Info - OnWelfareInfo
        C2G_WELFARE_INFO = 5300, 
        // G2C_Welfare_Info - OnWelfareInfo
        G2C_WELFARE_INFO = 5301, 
        // C2G_Welfare_Award - OnWelfareAward
        C2G_WELFARE_AWARD = 5302, 
        // G2C_Welfare_Award - OnWelfareAward
        G2C_WELFARE_AWARD = 5303, 
        // C2G_Guild_List - OnGuildList
        C2G_GUILD_LIST = 6000, 
        // G2C_Guild_List - OnGuildList
        G2C_GUILD_LIST = 6001, 
        // C2G_Guild_ListDetails - OnGuildListDetails
        C2G_GUILD_LISTDETAILS = 6002, 
        // G2C_Guild_ListDetails - OnGuildListDetails
        G2C_GUILD_LISTDETAILS = 6003, 
        // C2G_Guild_Create - OnGuildCreate
        C2G_GUILD_CREATE = 6004, 
        // G2C_Guild_Create - OnGuildCreate
        G2C_GUILD_CREATE = 6005, 
        // C2G_Guild_TryLeave - OnGuildTryLeave
        C2G_GUILD_TRYLEAVE = 6006, 
        // G2C_Guild_TryLeave - OnGuildTryLeave
        G2C_GUILD_TRYLEAVE = 6007, 
        // C2G_Guild_TryKick - OnGuildTryKick
        C2G_GUILD_TRYKICK = 6008, 
        // G2C_Guild_TryKick - OnGuildTryKick
        G2C_GUILD_TRYKICK = 6009, 
        // C2G_Guild_Abdicate - OnGuildAbdicate
        C2G_GUILD_ABDICATE = 6010, 
        // G2C_Guild_Abdicate - OnGuildAbdicate
        G2C_GUILD_ABDICATE = 6011, 
        // C2G_Guild_TryJoin - OnGuildTryJoin
        C2G_GUILD_TRYJOIN = 6012, 
        // G2C_Guild_TryJoin - OnGuildTryJoin
        G2C_GUILD_TRYJOIN = 6013, 
        // C2G_Guild_ListApply - OnGuildListApply
        C2G_GUILD_LISTAPPLY = 6014, 
        // G2C_Guild_ListApply - OnGuildListApply
        G2C_GUILD_LISTAPPLY = 6015, 
        // C2G_Guild_ApplyAction - OnGuildApplyAction
        C2G_GUILD_APPLYACTION = 6016, 
        // G2C_Guild_ApplyAction - OnGuildApplyAction
        G2C_GUILD_APPLYACTION = 6017, 
        // C2G_Guild_ListMbs - OnGuildListMbs
        C2G_GUILD_LISTMBS = 6019, 
        // G2C_Guild_ListMbs - OnGuildListMbs
        G2C_GUILD_LISTMBS = 6020, 
        // C2G_Guild_ListLogRecord - OnGuildListLogRecord
        C2G_GUILD_LISTLOGRECORD = 6021, 
        // G2C_Guild_ListLogRecord - OnGuildListLogRecord
        G2C_GUILD_LISTLOGRECORD = 6022, 
        // C2G_Guild_Rename - OnGuildRename
        C2G_GUILD_RENAME = 6023, 
        // G2C_Guild_Rename - OnGuildRename
        G2C_GUILD_RENAME = 6024, 
        // C2G_Guild_JoinMode - OnGuildJoinMode
        C2G_GUILD_JOINMODE = 6025, 
        // G2C_Guild_JoinMode - OnGuildJoinMode
        G2C_GUILD_JOINMODE = 6026, 
        // C2G_Guild_Manifesto - OnGuildManifesto
        C2G_GUILD_MANIFESTO = 6027, 
        // G2C_Guild_Manifesto - OnGuildManifesto
        G2C_GUILD_MANIFESTO = 6028, 
        // C2G_Guild_Notice - OnGuildNotice
        C2G_GUILD_NOTICE = 6029, 
        // G2C_Guild_Notice - OnGuildNotice
        G2C_GUILD_NOTICE = 6030, 
        // C2G_Guild_DonateInfo - OnGuildDonateInfo
        C2G_GUILD_DONATEINFO = 6031, 
        // G2C_Guild_DonateInfo - OnGuildDonateInfo
        G2C_GUILD_DONATEINFO = 6032, 
        // C2G_Guild_Donate - OnGuildDonate
        C2G_GUILD_DONATE = 6033, 
        // G2C_Guild_Donate - OnGuildDonate
        G2C_GUILD_DONATE = 6034, 
        // C2G_Guild_ListDiplomacy - OnGuildListDiplomacy
        C2G_GUILD_LISTDIPLOMACY = 6035, 
        // G2C_Guild_ListDiplomacy - OnGuildListDiplomacy
        G2C_GUILD_LISTDIPLOMACY = 6036, 
        // C2G_Guild_SearchName - OnGuildSearchName
        C2G_GUILD_SEARCHNAME = 6037, 
        // G2C_Guild_SearchName - OnGuildSearchName
        G2C_GUILD_SEARCHNAME = 6038, 
        // C2G_Guild_ListAllianceApply - OnGuildListAllianceApply
        C2G_GUILD_LISTALLIANCEAPPLY = 6039, 
        // G2C_Guild_ListAllianceApply - OnGuildListAllianceApply
        G2C_GUILD_LISTALLIANCEAPPLY = 6040, 
        // C2G_Guild_AllianceApply - OnGuildAllianceApply
        C2G_GUILD_ALLIANCEAPPLY = 6041, 
        // G2C_Guild_AllianceApply - OnGuildAllianceApply
        G2C_GUILD_ALLIANCEAPPLY = 6042, 
        // C2G_Guild_AllianceRemove - OnGuildAllianceRemove
        C2G_GUILD_ALLIANCEREMOVE = 6043, 
        // G2C_Guild_AllianceRemove - OnGuildAllianceRemove
        G2C_GUILD_ALLIANCEREMOVE = 6044, 
        // C2G_Guild_AllianceApplyAction - OnGuildAllianceApplyAction
        C2G_GUILD_ALLIANCEAPPLYACTION = 6045, 
        // G2C_Guild_AllianceApplyAction - OnGuildAllianceApplyAction
        G2C_GUILD_ALLIANCEAPPLYACTION = 6046, 
        // C2G_Guild_ListCity - OnGuildListCity
        C2G_GUILD_LISTCITY = 6047, 
        // G2C_Guild_ListCity - OnGuildListCity
        G2C_GUILD_LISTCITY = 6048, 
        // C2G_Guild_SetCapitalCity - OnGuildSetCapitalCity
        C2G_GUILD_SETCAPITALCITY = 6049, 
        // G2C_Guild_SetCapitalCity - OnGuildSetCapitalCity
        G2C_GUILD_SETCAPITALCITY = 6050, 
        // C2G_Guild_SetCityLeader - OnGuildSetCityLeader
        C2G_GUILD_SETCITYLEADER = 6051, 
        // G2C_Guild_SetCityLeader - OnGuildSetCityLeader
        G2C_GUILD_SETCITYLEADER = 6052, 
        // C2G_Guild_RemoveCityLeader - OnGuildRemoveCityLeader
        C2G_GUILD_REMOVECITYLEADER = 6053, 
        // G2C_Guild_RemoveCityLeader - OnGuildRemoveCityLeader
        G2C_GUILD_REMOVECITYLEADER = 6054, 
        // C2G_Guild_ListLogSituation - OnGuildListLogSituation
        C2G_GUILD_LISTLOGSITUATION = 6055, 
        // G2C_Guild_ListLogSituation - OnGuildListLogSituation
        G2C_GUILD_LISTLOGSITUATION = 6056, 
        // C2G_Guild_ListTop - OnGuildListTop
        C2G_GUILD_LISTTOP = 6058, 
        // G2C_Guild_ListTop - OnGuildListTop
        G2C_GUILD_LISTTOP = 6059, 
        // C2G_Red_Packet_List - OnRedPacket
        C2G_RED_PACKET_LIST = 6200, 
        // G2C_Red_Packet_List - OnRedPacket
        G2C_RED_PACKET_LIST = 6201, 
        // C2G_Red_Packet_Info - OnRedPacket
        C2G_RED_PACKET_INFO = 6202, 
        // G2C_Red_Packet_Info - OnRedPacket
        G2C_RED_PACKET_INFO = 6203, 
        // C2G_Give_Red_Packet - OnGiveRed
        C2G_GIVE_RED_PACKET = 6204, 
        // G2C_Give_Red_Packet - OnGiveRed
        G2C_GIVE_RED_PACKET = 6205, 
        // G2C_Red_Packet_Receive - OnRedPacket
        G2C_RED_PACKET_RECEIVE = 6206, 
        // C2G_Get_Red_Packet - OnGetRed
        C2G_GET_RED_PACKET = 6207, 
        // G2C_Get_Red_Packet - OnGetRed
        G2C_GET_RED_PACKET = 6208, 
        // C2G_MansionBoss_Info - OnMansionBossInfo
        C2G_MANSIONBOSS_INFO = 6300, 
        // G2C_MansionBoss_Info - OnMansionBossInfo
        G2C_MANSIONBOSS_INFO = 6301, 
        // C2G_MansionBoss_Open - OnMansionBossOpen
        C2G_MANSIONBOSS_OPEN = 6302, 
        // G2C_MansionBoss_Open - OnMansionBossOpen
        G2C_MANSIONBOSS_OPEN = 6303, 
        // C2G_MansionBoss_Top - OnMansionBossTop
        C2G_MANSIONBOSS_TOP = 6305, 
        // G2C_MansionBoss_Top - OnMansionBossTop
        G2C_MANSIONBOSS_TOP = 6306, 
        // C2G_MansionBoss_Battle - OnMansionBossBattle
        C2G_MANSIONBOSS_BATTLE = 6307, 
        // G2C_MansionBoss_Battle - OnMansionBossBattle
        G2C_MANSIONBOSS_BATTLE = 6308, 
        // C2G_MansionBoss_Balance - OnMansionBossBalance
        C2G_MANSIONBOSS_BALANCE = 6309, 
        // G2C_MansionBoss_Balance - OnMansionBossBalance
        G2C_MANSIONBOSS_BALANCE = 6310, 
        // G2C_MansionBoss_TakeBalance - OnMansionBossTakeBalance
        G2C_MANSIONBOSS_TAKEBALANCE = 6311, 
        // C2G_MansionBoss_Buff - OnMansionBossBuff
        C2G_MANSIONBOSS_BUFF = 6312, 
        // G2C_MansionBoss_Buff - OnMansionBossBuff
        G2C_MANSIONBOSS_BUFF = 6313, 
        // C2G_Guild_GetActive - OnGuildGetActive
        C2G_GUILD_GETACTIVE = 6400, 
        // G2C_Guild_GetActive - OnGuildGetActive
        G2C_GUILD_GETACTIVE = 6401, 
        // C2G_Guild_ActiveAward - OnGuildActiveAward
        C2G_GUILD_ACTIVEAWARD = 6402, 
        // G2C_Guild_ActiveAward - OnGuildActiveAward
        G2C_GUILD_ACTIVEAWARD = 6403, 
        // C2G_Guild_ActiveAwardAll - OnGuildActiveAwardAll
        C2G_GUILD_ACTIVEAWARDALL = 6404, 
        // G2C_Guild_ActiveAwardAll - OnGuildActiveAwardAll
        G2C_GUILD_ACTIVEAWARDALL = 6405, 
        // C2G_Guild_ScienceInfo - OnGuildScienceInfo
        C2G_GUILD_SCIENCEINFO = 6500, 
        // G2C_Guild_ScienceInfo - OnGuildScienceInfo
        G2C_GUILD_SCIENCEINFO = 6501, 
        // C2G_Guild_ScienceLevelUp - OnGuildScienceLevelUp
        C2G_GUILD_SCIENCELEVELUP = 6502, 
        // G2C_Guild_ScienceLevelUp - OnGuildScienceLevelUp
        G2C_GUILD_SCIENCELEVELUP = 6503, 
        // C2G_Guild_ShopInfo - OnGuildShopInfo
        C2G_GUILD_SHOPINFO = 6505, 
        // G2C_Guild_ShopInfo - OnGuildShopInfo
        G2C_GUILD_SHOPINFO = 6506, 
        // C2G_Guild_ShopBuy - OnGuildShopBuy
        C2G_GUILD_SHOPBUY = 6507, 
        // G2C_Guild_ShopBuy - OnGuildShopBuy
        G2C_GUILD_SHOPBUY = 6508, 
        // C2G_Guild_ShopRefresh - OnGuildShopRefresh
        C2G_GUILD_SHOPREFRESH = 6509, 
        // G2C_Guild_ShopRefresh - OnGuildShopRefresh
        G2C_GUILD_SHOPREFRESH = 6510, 
        // C2G_GuildSalary_ListMbs - OnGuildSalaryListMbs
        C2G_GUILDSALARY_LISTMBS = 6600, 
        // G2C_GuildSalary_ListMbs - OnGuildSalaryListMbs
        G2C_GUILDSALARY_LISTMBS = 6601, 
        // C2G_GuildSalary_Pay - OnGuildSalaryPay
        C2G_GUILDSALARY_PAY = 6602, 
        // G2C_GuildSalary_Pay - OnGuildSalaryPay
        G2C_GUILDSALARY_PAY = 6603, 
        // C2G_GuildSalary_ListCity - OnGuildSalaryListCity
        C2G_GUILDSALARY_LISTCITY = 6605, 
        // G2C_GuildSalary_ListCity - OnGuildSalaryListCity
        G2C_GUILDSALARY_LISTCITY = 6606, 
        // C2G_Goddess_Seniority - OnGoddessSeniority
        C2G_GODDESS_SENIORITY = 6700, 
        // G2C_Goddess_Seniority - OnGoddessSeniority
        G2C_GODDESS_SENIORITY = 6701, 
        // C2G_Goddess_GetInfo - OnGoddessGetInfo
        C2G_GODDESS_GETINFO = 6702, 
        // G2C_Goddess_GetInfo - OnGoddessGetInfo
        G2C_GODDESS_GETINFO = 6703, 
        // C2G_Goddess_Choose - OnGoddessChoose
        C2G_GODDESS_CHOOSE = 6704, 
        // G2C_Goddess_Choose - OnGoddessChoose
        G2C_GODDESS_CHOOSE = 6705, 
        // C2G_Goddess_Donate - OnGoddessDonate
        C2G_GODDESS_DONATE = 6706, 
        // G2C_Goddess_Donate - OnGoddessDonate
        G2C_GODDESS_DONATE = 6707, 
        // C2G_Goddess_Save - OnGoddessSave
        C2G_GODDESS_SAVE = 6708, 
        // G2C_Goddess_Save - OnGoddessSave
        G2C_GODDESS_SAVE = 6709, 
        // C2G_Goddess_Defend - OnGoddessDefend
        C2G_GODDESS_DEFEND = 6710, 
        // G2C_Goddess_Defend - OnGoddessDefend
        G2C_GODDESS_DEFEND = 6711, 
        // C2G_Warrior_InBattle - OnWarriorInBattle
        C2G_WARRIOR_INBATTLE = 8000, 
        // G2C_Warrior_InBattle - OnWarriorInBattle
        G2C_WARRIOR_INBATTLE = 8001, 
        // C2G_Pve_ArmyInfo - OnPveArmyInfo
        C2G_PVE_ARMYINFO = 8004, 
        // G2C_Pve_ArmyInfo - OnPveArmyInfo
        G2C_PVE_ARMYINFO = 8005, 
        // C2G_Pve_ArmyChange - OnPveArmyChange
        C2G_PVE_ARMYCHANGE = 8006, 
        // G2C_Pve_ArmyChange - OnPveArmyChange
        G2C_PVE_ARMYCHANGE = 8007, 
        // C2G_Pve_GoBattle - OnPveGoBattle
        C2G_PVE_GOBATTLE = 8008, 
        // G2C_Pve_GoBattle - OnPveGoBattle
        G2C_PVE_GOBATTLE = 8009, 
        // G2C_Pve_BattleBalance - OnPveBattleBalance
        G2C_PVE_BATTLEBALANCE = 8010, 
        // C2G_GameLevelStory_Info - OnGameLevelStoryInfo
        C2G_GAMELEVELSTORY_INFO = 8100, 
        // G2C_GameLevelStory_Info - OnGameLevelStoryInfo
        G2C_GAMELEVELSTORY_INFO = 8101, 
        // C2G_GameLevelStory_Battle - OnGameLevelStoryBattle
        C2G_GAMELEVELSTORY_BATTLE = 8102, 
        // G2C_GameLevelStory_Battle - OnGameLevelStoryBattle
        G2C_GAMELEVELSTORY_BATTLE = 8103, 
        // C2G_GameLevelStory_Balance - OnGameLevelStoryBalance
        C2G_GAMELEVELSTORY_BALANCE = 8104, 
        // G2C_GameLevelStory_Balance - OnGameLevelStoryBalance
        G2C_GAMELEVELSTORY_BALANCE = 8105, 
        // C2G_GameLevelStory_Reward - OnGameLevelStoryReward
        C2G_GAMELEVELSTORY_REWARD = 8106, 
        // G2C_GameLevelStory_Reward - OnGameLevelStoryReward
        G2C_GAMELEVELSTORY_REWARD = 8107, 
        // C2G_GameLevelStoryBuyPower - 
        C2G_GAMELEVELSTORYBUYPOWER = 8108, 
        // G2C_GameLevelStoryBuyPower - 
        G2C_GAMELEVELSTORYBUYPOWER = 8109, 
        // C2G_GameLevelStory - 
        C2G_GAMELEVELSTORY = 8110, 
        // G2C_GameLevelStory - 
        G2C_GAMELEVELSTORY = 8111, 
        // C2G_Tower_Info - OnTowerInfo
        C2G_TOWER_INFO = 8200, 
        // G2C_Tower_Info - OnTowerInfo
        G2C_TOWER_INFO = 8201, 
        // C2G_Tower_Battle - OnTowerBattle
        C2G_TOWER_BATTLE = 8202, 
        // G2C_Tower_Battle - OnTowerBattle
        G2C_TOWER_BATTLE = 8203, 
        // C2G_Tower_BattleEnd - OnTowerBattleEnd
        C2G_TOWER_BATTLEEND = 8204, 
        // G2C_Tower_BattleEnd - OnTowerBattleEnd
        G2C_TOWER_BATTLEEND = 8205, 
        // C2G_Arena_Info - OnArenaInfo
        C2G_ARENA_INFO = 8300, 
        // G2C_Arena_Info - OnArenaInfo
        G2C_ARENA_INFO = 8301, 
        // C2G_Arena_TOP - OnArenaTOP
        C2G_ARENA_TOP = 8302, 
        // G2C_Arena_TOP - OnArenaTOP
        G2C_ARENA_TOP = 8303, 
        // C2G_ArenaMatch_Refresh - OnArenaMatchRefresh
        C2G_ARENAMATCH_REFRESH = 8304, 
        // G2C_ArenaMatch_Refresh - OnArenaMatchRefresh
        G2C_ARENAMATCH_REFRESH = 8305, 
        // C2G_ArenaMatch_Battle - OnArenaMatchBattle
        C2G_ARENAMATCH_BATTLE = 8306, 
        // G2C_ArenaMatch_Battle - OnArenaMatchBattle
        G2C_ARENAMATCH_BATTLE = 8307, 
        // C2G_ArenaMatch_Balance - OnArenaMatchBalance
        C2G_ARENAMATCH_BALANCE = 8308, 
        // G2C_ArenaMatch_Balance - OnArenaMatchBalance
        G2C_ARENAMATCH_BALANCE = 8309, 
        // C2G_ArenaBattleReport - 
        C2G_ARENABATTLEREPORT = 8311, 
        // G2C_ArenaBattleReport - 
        G2C_ARENABATTLEREPORT = 8312, 
        // C2G_ArenaMatch_Buy - OnArenaMatchBuy
        C2G_ARENAMATCH_BUY = 8313, 
        // G2C_ArenaMatch_Buy - OnArenaMatchBuy
        G2C_ARENAMATCH_BUY = 8314, 
        // C2G_Arena_Defense - OnArenaDefense
        C2G_ARENA_DEFENSE = 8315, 
        // G2C_Arena_Defense - OnArenaDefense
        G2C_ARENA_DEFENSE = 8316, 
        // C2G_Arena_SetDefense - OnArenaSetDefense
        C2G_ARENA_SETDEFENSE = 8317, 
        // G2C_Arena_SetDefense - OnArenaSetDefense
        G2C_ARENA_SETDEFENSE = 8318, 
        // C2G_Bank_Info - OnBankInfo
        C2G_BANK_INFO = 8400, 
        // G2C_Bank_Info - OnBankInfo
        G2C_BANK_INFO = 8401, 
        // C2G_Bank_SignIn - OnBankSignIn
        C2G_BANK_SIGNIN = 8402, 
        // G2C_Bank_SignIn - OnBankSignIn
        G2C_BANK_SIGNIN = 8403, 
        // C2G_Bank_WarZone - OnBankWarZone
        C2G_BANK_WARZONE = 8405, 
        // G2C_Bank_WarZone - OnBankWarZone
        G2C_BANK_WARZONE = 8406, 
        // C2G_Bank_WarZoneAward - OnBankWarZoneAward
        C2G_BANK_WARZONEAWARD = 8407, 
        // G2C_Bank_WarZoneAward - OnBankWarZoneAward
        G2C_BANK_WARZONEAWARD = 8408, 
        // C2G_Bank_WarZoneFight - OnBankWarZoneFight
        C2G_BANK_WARZONEFIGHT = 8409, 
        // G2C_Bank_WarZoneFight - OnBankWarZoneFight
        G2C_BANK_WARZONEFIGHT = 8410, 
        // C2G_Bank_WarZoneBalance - OnBankWarZoneBalance
        C2G_BANK_WARZONEBALANCE = 8411, 
        // G2C_Bank_WarZoneBalance - OnBankWarZoneBalance
        G2C_BANK_WARZONEBALANCE = 8412, 
        // C2G_Bank_WarZoneHurtHp - OnBankWarZoneHurtHp
        C2G_BANK_WARZONEHURTHP = 8413, 
        // G2C_Bank_WarZoneHurtHp - OnBankWarZoneHurtHp
        G2C_BANK_WARZONEHURTHP = 8414, 
        // C2G_Bank_RobberFight - OnBankRobberFight
        C2G_BANK_ROBBERFIGHT = 8415, 
        // G2C_Bank_RobberFight - OnBankRobberFight
        G2C_BANK_ROBBERFIGHT = 8416, 
        // C2G_Bank_RobberBalance - OnBankRobberBalance
        C2G_BANK_ROBBERBALANCE = 8417, 
        // G2C_Bank_RobberBalance - OnBankRobberBalance
        G2C_BANK_ROBBERBALANCE = 8418, 
        // C2G_Bank_Top - OnBankTop
        C2G_BANK_TOP = 8420, 
        // G2C_Bank_Top - OnBankTop
        G2C_BANK_TOP = 8421, 
        // C2G_Bank_TopCountry - OnBankTopCountry
        C2G_BANK_TOPCOUNTRY = 8423, 
        // G2C_Bank_TopCountry - OnBankTopCountry
        G2C_BANK_TOPCOUNTRY = 8424, 
        // C2G_Affairs_List - OnAffairsList
        C2G_AFFAIRS_LIST = 8500, 
        // G2C_Affairs_List - OnAffairsList
        G2C_AFFAIRS_LIST = 8501, 
        // C2G_Affairs_Begin - OnAffairsBegin
        C2G_AFFAIRS_BEGIN = 8502, 
        // G2C_Affairs_Begin - OnAffairsBegin
        G2C_AFFAIRS_BEGIN = 8503, 
        // C2G_Affairs_Award - OnAffairsAward
        C2G_AFFAIRS_AWARD = 8504, 
        // G2C_Affairs_Award - OnAffairsAward
        G2C_AFFAIRS_AWARD = 8505, 
        // G2C_Affairs_Notify - OnAffairsNotify
        G2C_AFFAIRS_NOTIFY = 8506, 
        // C2G_Grab_List - OnGrabList
        C2G_GRAB_LIST = 8600, 
        // G2C_Grab_List - OnGrabList
        G2C_GRAB_LIST = 8601, 
        // C2G_Grab_Battle - OnGrabBattle
        C2G_GRAB_BATTLE = 8602, 
        // G2C_Grab_Battle - OnGrabBattle
        G2C_GRAB_BATTLE = 8603, 
        // C2G_Grab_Fight - OnGrabFight
        C2G_GRAB_FIGHT = 8604, 
        // G2C_Grab_Fight - OnGrabFight
        G2C_GRAB_FIGHT = 8605, 
        // C2G_Grab_Info - OnGrabInfo
        C2G_GRAB_INFO = 8606, 
        // G2C_Grab_Info - OnGrabInfo
        G2C_GRAB_INFO = 8607, 
        // C2G_Grab_GiveUp - OnGrabGiveUp
        C2G_GRAB_GIVEUP = 8608, 
        // G2C_Grab_GiveUp - OnGrabGiveUp
        G2C_GRAB_GIVEUP = 8609, 
        // C2G_Grab_Mine - OnGrabMine
        C2G_GRAB_MINE = 8610, 
        // G2C_Grab_Mine - OnGrabMine
        G2C_GRAB_MINE = 8611, 
        // C2G_Grab_Buy - OnGrabBuy
        C2G_GRAB_BUY = 8612, 
        // G2C_Grab_Buy - OnGrabBuy
        G2C_GRAB_BUY = 8613, 
        // C2G_Bandits_Info - OnBanditsInfo
        C2G_BANDITS_INFO = 8700, 
        // G2C_Bandits_Info - OnBanditsInfo
        G2C_BANDITS_INFO = 8701, 
        // C2G_Bandits_Battle - OnBanditsBattle
        C2G_BANDITS_BATTLE = 8702, 
        // G2C_Bandits_Battle - OnBanditsBattle
        G2C_BANDITS_BATTLE = 8703, 
        // C2G_Bandits_BattleEnd - OnBanditsBattleEnd
        C2G_BANDITS_BATTLEEND = 8704, 
        // G2C_Bandits_BattleEnd - OnBanditsBattleEnd
        G2C_BANDITS_BATTLEEND = 8705, 
        // C2G_Bandits_Buy - OnBanditsBuy
        C2G_BANDITS_BUY = 8706, 
        // G2C_Bandits_Buy - OnBanditsBuy
        G2C_BANDITS_BUY = 8707, 
        // C2G_Bandits_Reset - OnBanditsReset
        C2G_BANDITS_RESET = 8708, 
        // G2C_Bandits_Reset - OnBanditsReset
        G2C_BANDITS_RESET = 8709, 
        // C2G_Supply_Supply - OnSupplySupply
        C2G_SUPPLY_SUPPLY = 8900, 
        // G2C_Supply_Supply - OnSupplySupply
        G2C_SUPPLY_SUPPLY = 8901, 
        // C2G_Supply_SupplyAuto - OnSupplySupplyAuto
        C2G_SUPPLY_SUPPLYAUTO = 8902, 
        // G2C_Supply_SupplyAuto - OnSupplySupplyAuto
        G2C_SUPPLY_SUPPLYAUTO = 8903, 
        // C2G_Strategy_Map - OnStrategyMap
        C2G_STRATEGY_MAP = 9100, 
        // G2C_Strategy_Map - OnStrategyMap
        G2C_STRATEGY_MAP = 9101, 
        // C2G_Strategy_CityInfo - OnStrategyCityInfo
        C2G_STRATEGY_CITYINFO = 9102, 
        // G2C_Strategy_CityInfo - OnStrategyCityInfo
        G2C_STRATEGY_CITYINFO = 9103, 
        // C2G_Strategy_FightInfo - OnStrategyFightInfo
        C2G_STRATEGY_FIGHTINFO = 9106, 
        // G2C_Strategy_FightInfo - OnStrategyFightInfo
        G2C_STRATEGY_FIGHTINFO = 9107, 
        // G2C_Strategy_NotifyRefreshWallHp - OnStrategyNotifyRefreshWallHp
        G2C_STRATEGY_NOTIFYREFRESHWALLHP = 9108, 
        // G2C_Strategy_NotifyRefreshCityInfo - OnStrategyNotifyRefreshCityInfo
        G2C_STRATEGY_NOTIFYREFRESHCITYINFO = 9109, 
        // G2C_Strategy_NotifyRefreshCitys - OnStrategyNotifyRefreshCitys
        G2C_STRATEGY_NOTIFYREFRESHCITYS = 9110, 
        // C2G_Strategy_MatchingCancel - OnStrategyMatchingCancel
        C2G_STRATEGY_MATCHINGCANCEL = 9111, 
        // G2C_Strategy_MatchingCancel - OnStrategyMatchingCancel
        G2C_STRATEGY_MATCHINGCANCEL = 9112, 
        // C2G_Strategy_Defense - OnStrategyDefense
        C2G_STRATEGY_DEFENSE = 9113, 
        // G2C_Strategy_Defense - OnStrategyDefense
        G2C_STRATEGY_DEFENSE = 9114, 
        // C2G_Strategy_Attack - OnStrategyAttack
        C2G_STRATEGY_ATTACK = 9115, 
        // G2C_Strategy_Attack - OnStrategyAttack
        G2C_STRATEGY_ATTACK = 9116, 
        // G2C_Strategy_NotifyMatchingEndDefense - OnStrategyNotifyMatchingEndDefense
        G2C_STRATEGY_NOTIFYMATCHINGENDDEFENSE = 9117, 
        // G2C_Strategy_NotifyMatchingAttackNpc - OnStrategyNotifyMatchingAttackNpc
        G2C_STRATEGY_NOTIFYMATCHINGATTACKNPC = 9118, 
        // G2C_Strategy_NotifyMatchingAttackWall - OnStrategyNotifyMatchingAttackWall
        G2C_STRATEGY_NOTIFYMATCHINGATTACKWALL = 9119, 
        // C2G_Strategy_AttackNpcBalance - OnStrategyAttackNpcBalance
        C2G_STRATEGY_ATTACKNPCBALANCE = 9122, 
        // G2C_Strategy_AttackNpcBalance - OnStrategyAttackNpcBalance
        G2C_STRATEGY_ATTACKNPCBALANCE = 9123, 
        // C2G_Strategy_AttackWallBalance - OnStrategyAttackWallBalance
        C2G_STRATEGY_ATTACKWALLBALANCE = 9124, 
        // G2C_Strategy_AttackWallBalance - OnStrategyAttackWallBalance
        G2C_STRATEGY_ATTACKWALLBALANCE = 9125, 
        // G2C_Strategy_NotifyMatchingAttackPlayer - OnStrategyNotifyMatchingAttackPlayer
        G2C_STRATEGY_NOTIFYMATCHINGATTACKPLAYER = 9126, 
        // C2G_Strategy_AttackPlayerBalance - OnStrategyAttackPlayerBalance
        C2G_STRATEGY_ATTACKPLAYERBALANCE = 9127, 
        // G2C_Strategy_AttackPlayerBalance - OnStrategyAttackPlayerBalance
        G2C_STRATEGY_ATTACKPLAYERBALANCE = 9128, 
        // G2C_Metro_NotifyRefreshInfo - OnMetroNotifyRefreshInfo
        G2C_METRO_NOTIFYREFRESHINFO = 9200, 
        // C2G_Metro_TopScore - OnMetroTopScore
        C2G_METRO_TOPSCORE = 9202, 
        // G2C_Metro_TopScore - OnMetroTopScore
        G2C_METRO_TOPSCORE = 9203, 
        // C2G_Metro_Matching - OnMetroMatching
        C2G_METRO_MATCHING = 9204, 
        // G2C_Metro_Matching - OnMetroMatching
        G2C_METRO_MATCHING = 9205, 
        // C2G_Metro_MatchingCancel - OnMetroMatchingCancel
        C2G_METRO_MATCHINGCANCEL = 9206, 
        // G2C_Metro_MatchingCancel - OnMetroMatchingCancel
        G2C_METRO_MATCHINGCANCEL = 9207, 
        // G2C_Metro_NotifyMatchingEnd - OnMetroNotifyMatchingEnd
        G2C_METRO_NOTIFYMATCHINGEND = 9208, 
        // G2C_Metro_NotifyMatchingMetro - OnMetroNotifyMatchingMetro
        G2C_METRO_NOTIFYMATCHINGMETRO = 9209, 
        // C2G_Metro_AttackPlayerBalance - OnMetroAttackPlayerBalance
        C2G_METRO_ATTACKPLAYERBALANCE = 9210, 
        // G2C_Metro_AttackPlayerBalance - OnMetroAttackPlayerBalance
        G2C_METRO_ATTACKPLAYERBALANCE = 9211, 
        // C2G_Battle_Demo - OnBattleDemo
        C2G_BATTLE_DEMO = 15000, 
        // G2C_Battle_Demo - OnBattleDemo
        G2C_BATTLE_DEMO = 15001, 
        // C2G_Battle_Ready - OnBattleReady
        C2G_BATTLE_READY = 15002, 
        // G2C_Battle_Ready - OnBattleReady
        G2C_BATTLE_READY = 15003, 
        // G2C_Battle_NotifyReady - OnBattleNotifyReady
        G2C_BATTLE_NOTIFYREADY = 15004, 
        // C2G_Battle_ForwardData - OnBattleForwardData
        C2G_BATTLE_FORWARDDATA = 15006, 
        // G2C_Battle_ForwardData - OnBattleForwardData
        G2C_BATTLE_FORWARDDATA = 15007, 
        // G2A_Load_SetLoad - OnLoadSetLoad
        G2A_LOAD_SETLOAD = 27000, 
        // B2T_GM_Start - OnGMStart
        B2T_GM_START = 28000, 
        // B2T_GM_Login - OnGMLogin
        B2T_GM_LOGIN = 28001, 
        // T2B_GM_Login - OnGMLogin
        T2B_GM_LOGIN = 28002, 
        // B2G_GM_Cmd - OnGMCmd
        B2G_GM_CMD = 28003, 
        // G2B_GM_Cmd - OnGMCmd
        G2B_GM_CMD = 28004, 
        // T2B_Mail_GlobalList - OnMailGlobalList
        T2B_MAIL_GLOBALLIST = 28005, 
        // B2T_Mail_GlobalList - OnMailGlobalList
        B2T_MAIL_GLOBALLIST = 28006, 
        // B2T_GmMail_Send - OnGmMailSend
        B2T_GMMAIL_SEND = 28008, 
        // T2B_GmMail_Send - OnGmMailSend
        T2B_GMMAIL_SEND = 28009, 
        // B2T_Edit_Player - OnEditPlayer
        B2T_EDIT_PLAYER = 28010, 
        // T2B_Edit_Player - OnEditPlayer
        T2B_EDIT_PLAYER = 28011, 
        // B2T_Bank_Conf - OnBankConf
        B2T_BANK_CONF = 28012, 
        // T2B_Bank_Conf - OnBankConf
        T2B_BANK_CONF = 28013, 
        // B2T_Bank_Info - OnBankInfo
        B2T_BANK_INFO = 28014, 
        // T2B_Bank_Info - OnBankInfo
        T2B_BANK_INFO = 28015, 
        // B2T_GM_End - OnGMEnd
        B2T_GM_END = 28016, 

    }
}

