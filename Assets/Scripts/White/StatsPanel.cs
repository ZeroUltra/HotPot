using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsPanel : MonoBehaviour
{
    public Image repletionBar;
    public Text appetite;
    public Text prefs;

    public int id;

    void Start()
    {
        PlayerInfo info = Stats.playerInfos[id];

    }

    void SetPanel(PlayerInfo info)
    {
        //repletionBar.fillAmount = info.repletion;
    }

    void Update()
    {
        
    }
}
