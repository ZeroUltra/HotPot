using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// �����ڽ�ɫ�ֱ���
/// ���ֶ�������ʳ��
/// </summary>
public class Arm : MonoBehaviour
{
    [SerializeField]
    KeyCode fetchKey;

    float rotSpeed = 30.0f;
    float curAngle = 0.0f;
    float maxAngle = 30.0f;
    float timer; // �ӡ����֡��������������ʱ������

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

        // �ֱ��쳤������
        fetchFoodSeq = DOTween.Sequence();
        fetchFoodSeq.Append(transform.DOScaleY(4.0f, 1.0f).SetEase(Ease.Linear));
        Tweener back = transform.DOScaleY(1.48f, 1.0f).SetEase(Ease.Linear);
        back.OnComplete(() => { isIdle = true; });
        fetchFoodSeq.Append(back);

        isIdle = false;
    }

    void Rotate()
    {
        // ����ҡ���ֱۡ� �������Ƕȸı�ҡ�ڷ���
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
                    Destroy(food.gameObject); // �����ʳ�ö�����

                    // ���½�ɫ��ʳ�ȵ�
                    // Stats.EatFood(int playerId, int foodId)
                    // ==>Stats.UpdateStats()
                    Debug.Log("��ʳ��++");
                }
            });
        }
    }
}
