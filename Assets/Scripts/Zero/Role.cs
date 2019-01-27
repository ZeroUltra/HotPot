using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Role : MonoBehaviour
{
    public int id;
    public Characters character;
    private Arm arm;
    private Vomit vomit;
    public PlayerInfo playerInfo;
    public PlayerUIInfo playerUIInfo;
    public Sprite headImg;//头像贴图
    public GameObject shitPrefab;
   
    private KeyCode switchKey;
    private KeyCode vomitKey;

    public List<Role> otherRoleList = new List<Role>();
    private int otherIndex;

    public int OtherIndex
    {
        get { return otherIndex; }
        set
        {
            otherIndex = value;
            if (otherIndex >= otherRoleList.Count)
            {
                otherIndex = 0;
            }
        }
    }

    public void Init(int id, Characters characters, PlayerUIInfo playerUIInfo)
    {
        this.id = id;
        character = characters;
        playerInfo = new PlayerInfo(id, this.character);
        arm = GetComponentInChildren<Arm>();
        arm.Init(id, characters);
        arm.OnEat += Arm_OnEat;
        this.playerUIInfo = playerUIInfo;
        headImg = Resources.Load<Sprite>("Roleavatar/" + characters.ToString());
        this.playerUIInfo.Init(characters);
        //vomit = GetComponent<Vomit>();
        //vomit.Init(id);
       

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

    ////public void Vomit(Role target)
    ////{
    ////    playerInfo.vomit(5);
    ////    target.BeVomitted();
    ////}
    ////public void BeVomitted()
    ////{
    ////    playerInfo.beVomitted();
    ////}
    ////private void Update()
    ////{
    ////    //if (Input.GetKeyDown(switchKey))
    ////    //{
    ////    //    otherRoleList
    ////    //}
    ////    //if (Input.GetKeyDown(vomitKey) && playerInfo.getRepletion() >= 5)
    ////    //{
    ////    //    shit = Instantiate(shitPrefab, vomitOffset.position, vomitOffset.rotation) as GameObject;
    ////    //}
    ////}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Destroy(collision.gameObject);
    //}
}
