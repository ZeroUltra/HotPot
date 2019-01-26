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
    [SerializeField]
    int id;

    float rotSpeed = 45.0f;
    float curAngle = 0.0f;
    float maxAngle = 45.0f;
    float timer; // 从“伸手”到“触碰事物”的时间间隔。

    Sequence fetchFoodSeq;
    bool isIdle;

    Transform hand;
    BoxCollider2D collider;

    void Start()
    {
        timer = 0;
        isIdle = true;
        transform.localEulerAngles = Vector3.zero;
        collider = GetComponent<BoxCollider2D>();
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
        if (collider.enabled == false)// 防止夹取多个食物
            return;
        Food food = collision.gameObject.GetComponent<Food>();
        if (food != null)
        {
            food.target = hand;
            fetchFoodSeq.Kill();
            Tweener back = transform.DOScaleY(1.48f, timer).SetEase(Ease.Linear);
            collider.enabled = false; // 防止夹取多个食物
            back.OnComplete(() => {
                isIdle = true;
                collider.enabled = true;
                if (food.target == hand)
                {
                    // 更新角色饱食度等
                    //Stats.UpdateInfo(id, Stats.playerInfos[id].getFoodSatie(),)
                    Stats.UpdateInfo(id, food.foodType);

                    Destroy(food.gameObject); // 或添加食用动作？
                    Debug.Log("饱食度++");
                }
            });
        }
    }
}
