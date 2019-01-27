using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    public Vector2 aeraV2 = new Vector2(-10, 10);
    public Vector2 nextGenRateTime = new Vector2(0.5f, 3f);
    private float nextGenerateTime;

    public GameObject[] foodPrefs;
    public List<Food> foodList = new List<Food>();
    private float timer;
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
        nextGenerateTime = Random.Range(nextGenRateTime.x, nextGenRateTime.y);
        Vector3 dir = new Vector3(Random.Range(aeraV2.x, aeraV2.y), Random.Range(aeraV2.x, aeraV2.y), 0).normalized;

        Food newFood = Instantiate(foodPrefs[0]).GetComponent<Food>();

        newFood.transform.parent = transform;
        newFood.transform.position = transform.position + dir;

        foodList.Add(newFood);
    }
}
