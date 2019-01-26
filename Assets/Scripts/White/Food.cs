using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [HideInInspector]
    public Transform target; // ʳ�����Ŀ��(��ɫ������λ��)

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
