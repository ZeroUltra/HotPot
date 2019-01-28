using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerSpawn : MonoBehaviour
{
    public Transform UISpawn;
    /// <summary>
    /// �������
    /// </summary>
    private void Start()
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    GameManager.Instance.roles.Add((Characters)i);
        //}
        for (int i = 0; i < GameManager.Instance.roles.Count; i++)
        {
            Role role = GameObject.Instantiate(Resources.Load<GameObject>("Roles/" + GameManager.Instance.roles[i].ToString())).GetComponent<Role>();
            role.transform.SetParent(this.transform.GetChild(i));
            role.transform.localPosition = Vector3.zero;
            role.transform.localEulerAngles = Vector3.zero;
            role.transform.localScale = Vector3.one;

            GameManager.Instance.rolesList.Add(role);

            role.Init(i, GameManager.Instance.roles[i], UISpawn);
            //Init UI info
            //PlayerUIInfo playerUIInfo = UISpawn.GetChild(i).GetComponent<PlayerUIInfo>();
            //playerUIInfo.gameObject.SetActive(true);
            //RectTransform rectTransform = (playerUIInfo.transform as RectTransform);
            //rectTransform.localScale = Vector3.zero;
            //rectTransform.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack).SetDelay(i * 0.3f);
            // playerUIInfo.Init(role.character);
        }

    }
  
}
