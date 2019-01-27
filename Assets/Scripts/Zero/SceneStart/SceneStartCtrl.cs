using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ��ɫѡ��
/// </summary>
public class SceneStartCtrl : MonoBehaviour
{
    public RoleItem[] roleItems;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.RoleCount++;
            roleItems[GameManager.RoleCount - 1].Init();
            //GameManager.Instance.roles=new List<Characters>[]
            Debug.Log(GameManager.RoleCount);
        }
        //���һѡ��
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChooseRole(1);
        }
        //��Ҷ�ѡ��
        if (Input.GetKeyDown(KeyCode.H))
        {
            ChooseRole(2);
        }
        //�����ѡ��
        if (Input.GetKeyDown(KeyCode.K))
        {
            ChooseRole(3);
        }
        //�����ѡ��
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChooseRole(4);
        }
        //---------------------------------
        if (Input.GetKeyDown(KeyCode.S))
        {
            ConfirmRoleItem(1);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            ConfirmRoleItem(2);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ConfirmRoleItem(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
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

            GameManager.Instance.LoadScene("03Main");
        }
        else
        {
            Debug.Log("��ʾû�н��н�ɫȷ��");
        }
    }

}
