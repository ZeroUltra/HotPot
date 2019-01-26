using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [HideInInspector]
    public Transform target; // 食物跟随目标(角色的手掌位置)

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
        // 添加对应的图片
    }

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.transform.position;
    }
}
