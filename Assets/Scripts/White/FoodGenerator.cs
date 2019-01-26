using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public GameObject[] foodPrefs;
    public float maxRange;

    float nextGenerateTime; 

    float timer;

    void Start()
    {
        timer = 0;
        nextGenerateTime = Random.Range(0.5f, 1.5f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextGenerateTime)
            Generate();
    }

    void Generate()
    {
        timer = 0;
        nextGenerateTime = Random.Range(0.5f, 3f);
        Vector3 dir = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f),0).normalized;
        Debug.Log(dir);

        Food newFood = Instantiate(foodPrefs[0]).GetComponent<Food>();
        newFood.transform.parent = transform;
        newFood.transform.position = transform.position + dir * Random.Range(0,maxRange);
    }
}
