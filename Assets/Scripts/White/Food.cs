using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [HideInInspector]
    public Transform target; // 食物跟随目标(角色的手掌位置)

    void Awake()
    {
        target = null;
    }

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.transform.position;
    }
}
