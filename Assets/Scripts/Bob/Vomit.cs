using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Vomit : MonoBehaviour
{
    public Transform[] enemyPointerOffset = new Transform[3];
    public GameObject[] enemy = new GameObject[3];
    public KeyCode switchKey;
    public KeyCode vomitKey;
    public GameObject pointer;
    public Transform selfOffset;
    public Transform vomitOffset;
    public GameObject shitPrefab;
    public float speed;

    private Dictionary<int, KeyCode> DicSwitchKey = new Dictionary<int, KeyCode>()
    {
        [0] = KeyCode.S,
        [1] = KeyCode.K,
        [2] = KeyCode.DownArrow,
        [3] = KeyCode.Keypad8
    };
    private Dictionary<int, KeyCode> DicVomitKey = new Dictionary<int, KeyCode>()
    {
        [0] = KeyCode.D,
        [1] = KeyCode.L,
        [2] = KeyCode.RightArrow,
        [3] = KeyCode.Keypad9
    };
    int index;
    ArrayList pointerAtSelf = new ArrayList();
    bool flag;
    GameObject shit;
    PlayerInfo enemyInfo;
    PlayerInfo thisinfo;
    public int id;
    IEnumerator Start()
    {
        yield return new WaitForEndOfFrame();
        index = 0;

        pointer.transform.position = enemyPointerOffset[index].position;
        //Debug.Log(pointer.transform.position);
        enemy[index].GetComponent<Vomit>().Pointed(pointer);
        thisinfo = GetComponent<Role>().playerInfo;
        ArrangePos();

        flag = false;
        switchKey = DicSwitchKey[id];
        vomitKey = DicVomitKey[id];
    }


    void Update()
    {
        if (Input.GetKeyDown(switchKey) && flag == false)
        {
            enemy[index].GetComponent<Vomit>().RemovePoint(pointer);

            if (index == 2)
                index = 0;
            else
                index++;

            pointer.transform.position = enemyPointerOffset[index].position;

            enemy[index].GetComponent<Vomit>().Pointed(pointer);
        }

        enemyInfo = enemy[index].GetComponent<Role>().playerInfo;


        if (Input.GetKeyDown(vomitKey) && thisinfo.getRepletion() >= 5)
        {
            thisinfo.vomit(5);
            shit = Instantiate(shitPrefab, vomitOffset.position, vomitOffset.rotation) as GameObject;
            Shit shi = shit.GetComponent<Shit>();
            shi.target = enemy[index].transform;
            shi.OnTrigger += Shi_OnTrigger;
            shit.transform.DOMove(enemy[index].transform.position, 1.2f);
            Destroy(shit, 3f);
          
        }
       
        ArrangePos();
    }

    private void Shi_OnTrigger()
    {
        enemyInfo.beVomitted();
        Destroy(shit);
    }

    public void Pointed(GameObject pt)
    {
        pointerAtSelf.Add(pt);
    }

    public void RemovePoint(GameObject pt)
    {
        pointerAtSelf.Remove(pt);
    }

    void ArrangePos()
    {

        if (pointerAtSelf.Count == 1)
        {
            GameObject pt0 = (GameObject)pointerAtSelf[0];

            pt0.transform.position = selfOffset.position;

        }

        else if (pointerAtSelf.Count == 2)
        {
            GameObject pt0 = (GameObject)pointerAtSelf[0];
            GameObject pt1 = (GameObject)pointerAtSelf[1];
            pt0.transform.position = new Vector3(selfOffset.position.x - 0.2f, selfOffset.position.y, selfOffset.position.z);
            pt1.transform.position = new Vector3(selfOffset.position.x + 0.2f, selfOffset.position.y, selfOffset.position.z);
        }

        else if (pointerAtSelf.Count == 3)
        {
            //Debug.Log(test + ":" + selfOffset.position);
            GameObject pt0 = (GameObject)pointerAtSelf[0];
            GameObject pt1 = (GameObject)pointerAtSelf[1];
            GameObject pt2 = (GameObject)pointerAtSelf[2];
            pt0.transform.position = new Vector3(selfOffset.position.x - 0.4f, selfOffset.position.y, selfOffset.position.z);
            pt1.transform.position = new Vector3(selfOffset.position.x, selfOffset.position.y, selfOffset.position.z);
            pt2.transform.position = new Vector3(selfOffset.position.x + 0.4f, selfOffset.position.y, selfOffset.position.z);
        }
    }
}
