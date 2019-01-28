using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageMotion : MonoBehaviour
{
    public Image curtain;

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
            curtain.gameObject.SetActive(true);
            Tweener t = curtain.DOFade(1.0f, 0.5f);
            t.OnComplete(() =>
            {
                GameManager.Instance.LoadScene("00Init");
            });
            return;
        }

        float offset = 0;
        if (steps == 3)
            offset = -1.3f;
        Tweener tw = transform.DOLocalMoveX(15.0f + steps * stepLen + offset, 1f).SetEase(Ease.Linear);
        tw.OnComplete(() =>
        {
            isMoving = false;
        });
    }
}
