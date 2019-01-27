using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    public Characters character;
    private Arm arm;
    private Vomit vomit;
    private PlayerInfo playerInfo;
    private PlayerUIInfo playerUIInfo;
    public void Init(int id, Characters characters, PlayerUIInfo playerUIInfo)
    {
        character = characters;
        playerInfo = new PlayerInfo(id, this.character);
        arm = GetComponentInChildren<Arm>();
        arm.Init(id, characters);
        arm.OnEat += Arm_OnEat;
        this.playerUIInfo = playerUIInfo;
    }
    /// <summary>
    /// 当玩家迟到食物
    /// </summary>
    /// <param name="food"></param>
    private void Arm_OnEat(int food)
    {
        playerInfo.updateInfo(food);
        playerUIInfo.SetPanel(this.playerInfo);
        Debug.Log("跟新信息");
    }

}
