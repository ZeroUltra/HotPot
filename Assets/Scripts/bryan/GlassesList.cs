using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassesList : MonoBehaviour
{
    List<GameObject> items;
    public Image winner;
    public Text winnerScore;
    public Text winnerName;

    int maxScore = 100;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
        int id = 0;
        for (int i = 0; i < GameManager.Instance.rolesList.Count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
            BindData(i,transform.GetChild(i));

        }
    }

    void BindData(int id, Transform obj)
    {
        PlayerInfo info = GameManager.Instance.rolesList[id].playerInfo;
        Text glasses = obj.GetChild(2).GetComponent<Text>();

        int score = info.Repletion;

        //glasses.text = (info.getGlass()).ToString();
        glasses.text = score.ToString();

        // 头像
        int roleType = (int)info.type; // 读取类型
        //int roleType = 0;
        Sprite avatar = Resources.Load<Sprite>("UI/face/" + roleType.ToString() + "_0");
        Image image = obj.GetChild(3).GetComponent<Image>();
        image.sprite = avatar;


        // 分数
        if (score >= maxScore)
        {
            winner.sprite = avatar;
            winnerScore.text = score.ToString();
            winnerName.text = "Player" + (id + 1).ToString();
        }
    }
    public void ResetGame()
    {
        GameManager.RoleCount = 0;
        GameManager.Instance.roles.Clear();
        GameManager.Instance.rolesList.Clear();
        GameTools.LoadScene("01Start");
    }
}
