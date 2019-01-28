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

    // 在选择角色后，进入游戏前，赋值该list
    public static List<PlayerInfo> playerInfos = new List<PlayerInfo>();
    public static Action<PlayerInfo> updateInfo;

    // test
    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            playerInfos.Add(new PlayerInfo(i, Characters.Brother));
        }
    }

    public static void UpdateInfo(int id, int foodType)
    {
        PlayerInfo info = playerInfos[id];
        // update info
        info.Repletion += 10;// test

        // if(info.repletion >= 100)
        //     gameover
        updateInfo(info);
    }
}

