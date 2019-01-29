using System.Collections.Generic;
using UnityEngine;
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
    //private void OnLevelWasLoaded(int level)
    //{
    //    if (level > 3)
    //    {
    //        GetComponent<AudioSource>().Stop();
    //    }
    //}


    // public GameObject father;

    public List<Role> rolesList = new List<Role>();


    // test
    void Awake()
    {
        Screen.SetResolution(1920, 1080, true);
        DontDestroyOnLoad(this.gameObject);
        LoadScene("01Start");
    }
    /// <summary>
    /// 场景跳转
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        GameTools.LoadScene(sceneName);
    }
}
