using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PageMotion : MonoBehaviour
{
    float stepLen = -15.0f;
    float steps = 0;

    bool isMoving;
    void Start()
    {
        Move();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
            Move();
    }

    void Move()
    {
        isMoving = true;
        steps++;

        if(steps > 3)
        {
            Debug.Log("game over");
            return;
        }

        Tweener tw = transform.DOLocalMoveX(15.0f + steps * stepLen, 1f).SetEase(Ease.Linear);
        tw.OnComplete(() =>
        {
            isMoving = false;
        });
    }
}
