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

    // Start is called before the first frame update
    void Start()
    {

        index = 0;
       
        pointer.transform.position = enemyPointerOffset[index].position;

        enemy[index].GetComponent<Vomit>().Pointed(pointer);

        ArrangePos();
    }

    // Update is called once per frame
    void Update()
    {

        //switch target logic
        if (Input.GetKeyDown(switchKey))
        {
            enemy[index].GetComponent<Vomit>().RemovePoint(pointer);

            if (index == 2)
                index = 0;
            else
                index++;

            pointer.transform.position = enemyPointerOffset[index].position;

            enemy[index].GetComponent<Vomit>().Pointed(pointer);
        }

        //vomit logic
        if (Input.GetKeyDown(vomitKey))
        {
            GameObject shit = Instantiate(shitPrefab, vomitOffset.position, vomitOffset.rotation) as GameObject;
            Debug.Log(shit.transform.position);
            Debug.Log(enemy[index].transform.position);
            shit.transform.position = Vector3.MoveTowards(shit.transform.position, enemy[index].transform.position, 10f * Time.fixedDeltaTime);
            Debug.Log(speed * Time.deltaTime);
            Destroy(shit, 2);
        }

        ArrangePos();

    }

    //keep track of arrow pointers on top
    public void Pointed(GameObject pt)
    {
        pointerAtSelf.Add(pt);
    }

    public void RemovePoint(GameObject pt)
    {
        pointerAtSelf.Remove(pt);
    }


    //arrange arrow position when there is multiple ones on top
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
