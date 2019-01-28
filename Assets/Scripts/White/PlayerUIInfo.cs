using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUIInfo : MonoBehaviour
{
    public Text nameTxt;
    public Image repletionBar;
    public Text appetite;
    public Text prefs;
    public Image head;
    private float appetiteNum = 0;
    /// <summary>
    /// 根据ID确定位置
    /// </summary>
    /// <param name="id"></param>
    public void Init(Characters character)
    {
        this.gameObject.SetActive(true);
        RectTransform rectTransform = (transform as RectTransform);
        rectTransform.localScale = Vector3.zero;
        rectTransform.DOScale(Vector3.one, 0.8f).SetEase(Ease.OutBack).SetDelay(transform.GetSiblingIndex() * 0.3f);
        nameTxt.text = character.ToString();
        head.sprite = Resources.Load<Sprite>("head/" + character.ToString());
    }

    public void SetPanel(PlayerInfo info)
    {
        //Debug.Log(info.repletion);
        repletionBar.DOFillAmount((float)info.Repletion / 100.0f, 0.8f);
        appetite.text = info.appetite.ToString();
        DOTween.To(() => appetiteNum, x => appetiteNum = x, (float)info.Repletion, 0.8f).OnUpdate(()=>
        {
            appetite.text = appetiteNum.ToString("f0")+ "%";
        });
       
        List<string> preferList = info.getPreferLists();
        string preferStr = "";
        foreach (string name in preferList)
            preferStr += (name + "\n");
        prefs.text = preferStr;
    }


    //void OnDestroy()
    //{
    //    try
    //    {
    //        Stats.updateInfo -= SetPanel;
    //    }
    //    catch (System.Exception) { };
    //}
}
