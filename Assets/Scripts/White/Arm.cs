using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 挂载在角色手臂下
/// 伸手动作、夹食物
/// </summary>
public class Arm : MonoBehaviour
{
    [SerializeField]
    KeyCode fetchKey;

    float rotSpeed = 30.0f;
    float curAngle = 0.0f;
    float maxAngle = 30.0f;
    float timer; // 从“伸手”到“触碰事物”的时间间隔。

    Sequence fetchFoodSeq;
    bool isIdle;

    Transform hand;

    void Awake()
    {
        timer = 0;
        isIdle = true;
        transform.localEulerAngles = Vector3.zero;
        hand = transform.GetChild(0);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isIdle)
            return;

        if (Input.GetKeyDown(fetchKey))
            Fetch();

        Rotate();
    }

    void Fetch()
    {
        timer = 0.0f;

        // 手臂伸长动画。
        fetchFoodSeq = DOTween.Sequence();
        fetchFoodSeq.Append(transform.DOScaleY(4.0f, 1.0f).SetEase(Ease.Linear));
        Tweener back = transform.DOScaleY(1.48f, 1.0f).SetEase(Ease.Linear);
        back.OnComplete(() => { isIdle = true; });
        fetchFoodSeq.Append(back);

        isIdle = false;
    }

    void Rotate()
    {
        // 来回摇摆手臂。 到达最大角度改变摇摆方向。
        curAngle += rotSpeed * Time.deltaTime;
        curAngle = Mathf.Clamp(curAngle, -maxAngle, maxAngle);
        if (Mathf.Abs(curAngle) >= maxAngle)
            rotSpeed *= -1;

        transform.localEulerAngles = new Vector3(0, 0, curAngle);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Food food = collision.gameObject.GetComponent<Food>();
        if (food != null)
        {
            food.target = hand;
            fetchFoodSeq.Kill();
            Tweener back = transform.DOScaleY(1.48f, timer).SetEase(Ease.Linear);
            back.OnComplete(() => {
                isIdle = true;
                if(food.target == hand)
                {
                    Destroy(food.gameObject); // 或添加食用动作？

                    // 更新角色饱食度等
                    // Stats.EatFood(int playerId, int foodId)
                    // ==>Stats.UpdateStats()
                    Debug.Log("饱食度++");
                }
            });
        }
    }
}
