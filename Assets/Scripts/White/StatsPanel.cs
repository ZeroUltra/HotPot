using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StatsPanel : MonoBehaviour
{
    public Image repletionBar;
    public Text appetite;
    public Text prefs;

    public int id;

    void Start()
    {
        PlayerInfo info = Stats.playerInfos[id];
        SetPanel(info);

        Stats.updateInfo += SetPanel;
    }

    void SetPanel(PlayerInfo info)
    {
        if (info.id != id)
            return;

        repletionBar.DOFillAmount(info.repletion / 100.0f, 0.5f);
        appetite.text = info.appetite.ToString();

        List<string> preferList = info.getPreferLists();
        string preferStr = "";
        foreach (string name in preferList)
            preferStr += (name + "\n");
        prefs.text = preferStr;
    }

    void OnDestroy()
    {
        try
        {
            Stats.updateInfo -= SetPanel;
        }
        catch (System.Exception){};
    }
}
