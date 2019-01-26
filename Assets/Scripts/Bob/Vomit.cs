using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vomit : MonoBehaviour
{

    //public GameObject[] enemy = new GameObject[3];
    public Transform[] enemyPointerOffset = new Transform[3];
    public GameObject[] enemy = new GameObject[3];
    public KeyCode switchKey;
    public KeyCode vomitKey;
    public GameObject pointer;
    public Transform selfOffset;
    public Transform vomitOffset;
    public GameObject shitPrefab;
    public float speed;

    
    int index;
    ArrayList pointerAtSelf = new ArrayList();
    bool flag;
    GameObject shit;
    PlayerInfo enemyInfo;

    // Start is called before the first frame update
    void Start()
    {

        index = 0;
       
        pointer.transform.position = enemyPointerOffset[index].position;

        enemy[index].GetComponent<Vomit>().Pointed(pointer);

        ArrangePos();

        flag = false;
    }

    // Update is called once per frame
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

        enemyInfo = enemy[index].GetComponent<PlayerInfo>();


        if (Input.GetKeyDown(vomitKey) && enemyInfo.getRepletion() >= 5 && flag == false)
        {
            shit = Instantiate(shitPrefab, vomitOffset.position, vomitOffset.rotation) as GameObject;
            Debug.Log(shit.transform.position);
            Debug.Log(enemy[index].transform.position);

            flag = true;
        }

        if (flag)
        {
            shit.transform.position = Vector3.MoveTowards(shit.transform.position, enemy[index].transform.position, speed * Time.fixedDeltaTime);
        }

        //vomit splash on face
        if (shit != null && shit.transform.position == enemy[index].transform.position && flag)
        {
            enemyInfo.beVomitted();
            enemyInfo.vomit(5);
            flag = false;
            Destroy(shit, 2.0f);
        }
        

        ArrangePos();

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
            GameObject pt0 = (GameObject) pointerAtSelf[0];

            pt0.transform.position = selfOffset.position;

        }
            
        else if (pointerAtSelf.Count == 2)
        {
            GameObject pt0 = (GameObject) pointerAtSelf[0];
            GameObject pt1 = (GameObject) pointerAtSelf[1];
            pt0.transform.position = new Vector3(selfOffset.position.x-0.2f, selfOffset.position.y, selfOffset.position.z);
            pt1.transform.position = new Vector3(selfOffset.position.x+0.2f, selfOffset.position.y, selfOffset.position.z);
        }

        else if (pointerAtSelf.Count == 3)
        {
            //Debug.Log(test + ":" + selfOffset.position);
            GameObject pt0 = (GameObject) pointerAtSelf[0];
            GameObject pt1 = (GameObject) pointerAtSelf[1];
            GameObject pt2 = (GameObject) pointerAtSelf[2];
            pt0.transform.position = new Vector3(selfOffset.position.x - 0.4f, selfOffset.position.y, selfOffset.position.z);
            pt1.transform.position = new Vector3(selfOffset.position.x, selfOffset.position.y, selfOffset.position.z);
            pt2.transform.position = new Vector3(selfOffset.position.x + 0.4f, selfOffset.position.y, selfOffset.position.z);
        }
    }
}
