using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUIInfo : MonoBehaviour
{
    public Text nameTxt;
    public Image repletionBar; //饱和
    public Text repletionText;
    public Text appetite;//食欲
    public Text prefs;
    public Image head;
    private float repletionNum = 0;
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
        repletionText.text = info.Repletion.ToString();
        DOTween.To(() => repletionNum, x => repletionNum = x, (float)info.Repletion, 0.8f).OnUpdate(() =>
        {
            repletionText.text = repletionNum.ToString("f0") + "%";
        });
        appetite.text = (1 + ((info.getCombo()-1) * 0.5f)).ToString();
        //List<string> preferList = info.getPreferLists();
        //string preferStr = "";
        //foreach (string name in preferList)
        //    preferStr += (name + "\n");
        //prefs.text = preferStr;
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
