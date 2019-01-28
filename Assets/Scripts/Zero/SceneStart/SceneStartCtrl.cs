using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// 角色选择
/// </summary>
public class SceneStartCtrl : MonoBehaviour
{
    public RoleItem[] roleItems;
    public Image curtain;
    public Button gotitBtn;
    public GameObject guide;

    void Start()
    {
        gotitBtn.onClick.AddListener(() =>
        {
            // 屏幕变黑
            curtain.gameObject.SetActive(true);
            Tweener tw = curtain.DOFade(1.0f, 0.5f);
            tw.OnComplete(() =>
            {
                GameManager.Instance.LoadScene("03Main");
            });
        });
    }

    private void Update()
    {
        if (GameManager.RoleCount < 4)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GameManager.RoleCount++;
                roleItems[GameManager.RoleCount - 1].Init();
            }
        }
        //玩家一选择
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChooseRole(1);
        }
        //玩家二选择
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChooseRole(2);
        }
        //玩家三选择
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChooseRole(3);
        }
        //玩家四选择
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            ChooseRole(4);
        }
        //---------------------------------
        if (Input.GetKeyDown(KeyCode.S))
        {
            ConfirmRoleItem(1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            ConfirmRoleItem(2);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ConfirmRoleItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            ConfirmRoleItem(4);
        }
    }

    private void ChooseRole(int count)
    {
        if (GameManager.RoleCount >= count)
        {
            if (!roleItems[count - 1].IsConfirm)
                roleItems[count - 1].ChangeSp();
        }
    }
    private void ConfirmRoleItem(int index)
    {
        if (GameManager.RoleCount >= index)
        {
            if (!roleItems[index - 1].IsConfirm)
                GameManager.Instance.roles.Add(roleItems[index - 1].Confirm());
        }
    }
    //--------playbtn--------
    public void PlayBtnClick()
    {
        bool isAllConfirm = true;
        if (GameManager.RoleCount < 2)
        {
            Debug.Log("提示人数不足");
            return;
        }

        for (int i = 0; i < GameManager.RoleCount; i++)
        {
            if (!roleItems[i].IsConfirm)
            {
                isAllConfirm = false;
                break;
            }
        }
        if (isAllConfirm)
        {
            guide.SetActive(true);
        }
        else
        {
            Debug.Log("提示没有进行角色确认");
        }
    }

}
