using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public int foodType;
    private bool isFollow = false; 
    void Awake()
    {
        // random
        foodType = FoodType.beaf;
    }

    public void SetFoodType(int _foodType)
    {
        foodType = _foodType;
        // GetFoodImage();
        // ��Ӷ�Ӧ��ͼƬ
    }

    public void Follow(float offx)
    {
        transform.localPosition = new Vector3(offx,0,0);
    }
   
}
