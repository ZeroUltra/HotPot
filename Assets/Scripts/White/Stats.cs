using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 数据类
/// 储存所有玩家数据
/// </summary>
public class Stats : MonoBehaviour
{
    public static Action<PlayerInfo> updateInfo;
    public static List<PlayerInfo> playerInfos; // 在选择角色后，进入游戏前，赋值该list

    void UpdateInfo(int playerId, int repletion, int appetite)
    {
        updateInfo(playerInfos[playerId]);
    }
}

//public class PlayerInfo
//{
//    public int repletion;
//    public int appetiet;
//}