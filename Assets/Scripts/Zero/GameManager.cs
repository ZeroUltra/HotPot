using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 游戏管理器
/// </summary>
public class GameManager : Singleton<GameManager>
{
    public List<Characters> roles = new List<Characters>();
    private static int roleCount = 0;
    public static int RoleCount
    {
        get => roleCount;
        set
        {
            roleCount = value;
            if (roleCount > 4)
            {
                roleCount = 4;
            }
        }
    }


    // 在选择角色后，进入游戏前，赋值该list
    //public static List<PlayerInfo> playerInfos = new List<PlayerInfo>();
    //public static Action<PlayerInfo> updateInfo;

    public static List<Role> rolesList = new List<Role>();


    // test
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
      LoadScene("01Start");
    }
    /// <summary>
    /// 人物 吃到食物更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="foodType"></param>
    //public static void UpdateInfo(int id, int foodType)
    //{
    //    PlayerInfo info = playerInfos[id];
    //    // update info
    //    info.repletion += 10;// test

    //    // if(info.repletion >= 100)
    //    //     gameover
    //    updateInfo(info);
    //}

    /// <summary>
    /// 场景跳转
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        GameTools.LoadScene(sceneName);
    }
}
