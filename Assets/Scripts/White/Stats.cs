using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// ������
/// ���������������
/// </summary>
public class Stats : MonoBehaviour
{

    // ��ѡ���ɫ�󣬽�����Ϸǰ����ֵ��list
    public static List<PlayerInfo> playerInfos = new List<PlayerInfo>();
    public static Action<PlayerInfo> updateInfo;

    // test
    void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            playerInfos.Add(new PlayerInfo(i, 1));
        }
    }

    public static void UpdateInfo(int id, int foodType)
    {
        PlayerInfo info = playerInfos[id];
        // update info
        info.repletion += 10;// test

        // if(info.repletion >= 100)
        //     gameover
        updateInfo(info);
    }
}

//public class PlayerInfo
//{
//    public int repletion;
//    public int appetiet;
//}