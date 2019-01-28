using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// ��ɫѡ��
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
            // ��Ļ���
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
        //���һѡ��
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChooseRole(1);
        }
        //��Ҷ�ѡ��
        if (Input.GetKeyDown(KeyCode.J))
        {
            ChooseRole(2);
        }
        //�����ѡ��
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChooseRole(3);
        }
        //�����ѡ��
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
            Debug.Log("��ʾ��������");
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
            Debug.Log("��ʾû�н��н�ɫȷ��");
        }
    }

}
