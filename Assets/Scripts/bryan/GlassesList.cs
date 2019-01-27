using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassesList : MonoBehaviour
{
    List<GameObject> items;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<GameObject>();
        int id = 0;
        foreach (Transform obj in transform)
        {
            Debug.Log(id);
            BindData(id++, obj);
        }
    }
    
    void BindData(int id, Transform obj)
    {
        //PlayerInfo info = GameManager.rolesList[id].playerInfo;
        Text glasses = obj.GetChild(2).GetComponent<Text>();
        //glasses.text = (info.getGlass()).ToString();

        int test = 0;
        glasses.text = test.ToString();
    }

}
