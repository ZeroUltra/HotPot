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
    public static Action<PlayerInfo> updateInfo;
    public static List<PlayerInfo> playerInfos; // ��ѡ���ɫ�󣬽�����Ϸǰ����ֵ��list

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