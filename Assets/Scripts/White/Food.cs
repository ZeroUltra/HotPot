using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [HideInInspector]
    public Transform target; // ʳ�����Ŀ��(��ɫ������λ��)

    public int foodType;

    void Awake()
    {
        // random
        foodType = FoodType.beaf;
        target = null;
    }

    public void SetFoodType(int _foodType)
    {
        foodType = _foodType;
        // GetFoodImage();
        // ��Ӷ�Ӧ��ͼƬ
    }

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.transform.position;
    }
}
