using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerSpawn : MonoBehaviour
{
    public Transform UISpawn;
    /// <summary>
    /// Íæ¼ÒÉú³É
    /// </summary>
    private void Start()
    {
        //for (int i = 0; i < 3; i++)
        //{
        //    GameManager.Instance.roles.Add((Characters)i);
        //}
        for (int i = 0; i < GameManager.Instance.roles.Count; i++)
        {
            Role role = GameObject.Instantiate(Resources.Load<GameObject>("Player")).GetComponent<Role>();
          
            GameManager.rolesList.Add(role);
            role.transform.SetParent(transform.GetChild(i));
            role.transform.localEulerAngles = Vector3.zero;
            role.transform.localPosition = Vector3.zero;

            //Init UI info
            PlayerUIInfo playerUIInfo = UISpawn.GetChild(i).GetComponent<PlayerUIInfo>();
            playerUIInfo.Init(role.character);
            playerUIInfo.gameObject.SetActive(true);
            RectTransform rectTransform = (playerUIInfo.transform as RectTransform);
            rectTransform.localScale = Vector3.zero;
            rectTransform.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack).SetDelay(i*0.3f);
            role.Init(i, GameManager.Instance.roles[i], playerUIInfo);
        }

    }
}
