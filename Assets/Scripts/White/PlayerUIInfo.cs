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

    /// <summary>
    /// 根据ID确定位置
    /// </summary>
    /// <param name="id"></param>
    public void Init(Characters character)
    {
        //坐标。。。。
        nameTxt.text = character.ToString();
    }

    public void SetPanel(PlayerInfo info)
    {
        Debug.Log(info.repletion);
        repletionBar.DOFillAmount((float)info.repletion / 100.0f, 0.5f);
        appetite.text = info.appetite.ToString();

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
