using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
/// <summary>
/// 挂载在角色手臂下
/// 伸手动作、夹食物
/// </summary>
public class Arm : MonoBehaviour
{
    private Dictionary<int, KeyCode> DicIdKeyCode = new Dictionary<int, KeyCode>
    {
        [0] = KeyCode.Q,
        [1] = KeyCode.J,
        [2] = KeyCode.L,
        [3] = KeyCode.Keypad2,
    };
    /// <summary>
    /// 这个不能写在这
    /// </summary>
    private Dictionary<Characters, float> DicIdSpeed = new Dictionary<Characters, float>
    {
        [Characters.Grandma] = 30f,
        [Characters.Grandpa] = 29f,
        [Characters.Father] = 42f,
        [Characters.Mother] = 44f,
        [Characters.Brother] = 46f,
        [Characters.Sister] = 38f,
    };
    [SerializeField]
    KeyCode fetchKey;

    float rotSpeed = 45.0f;
    float curAngle = 0;
    float maxAngle = 45;
    float timer; // 从“伸手”到“触碰事物”的时间间隔。

    Sequence fetchFoodSeq;
    bool isIdle;

    Transform hand;
    
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxcollider;
    private float rate;
    
    public event Action<int> OnEat;

    /// <summary>
    /// 根据id设置伸手出发按键
    /// </summary>
    /// <param name="id"></param>
    public void Init(int id,Characters characters)
    {
        this.fetchKey = DicIdKeyCode[id];
        this.rotSpeed = DicIdSpeed[characters];
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        timer = 0;
        isIdle = true;
        transform.localEulerAngles = Vector3.zero;
        boxcollider = GetComponent<BoxCollider2D>();
        rate = boxcollider.size.x / boxcollider.offset.x;
    }

    void Update()
    {
        //随着图片的宽度 更改boxcollider
        boxcollider.size = spriteRenderer.size;
        boxcollider.offset = new Vector2(boxcollider.size.x/rate, boxcollider.offset.y);

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
        fetchFoodSeq.Append(DOTween.To(() => spriteRenderer.size, x => spriteRenderer.size = x, new Vector2(5.20f, spriteRenderer.size.y), 1f).SetEase(Ease.Linear));
        Tweener back = DOTween.To(() => spriteRenderer.size, x => spriteRenderer.size = x, new Vector2(2f, spriteRenderer.size.y), 1f).SetEase(Ease.Linear);
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
        if (boxcollider.enabled == false)// 防止夹取多个食物
            return;
        Food food = collision.gameObject.GetComponent<Food>();
        if (food != null)
        {
            food.transform.SetParent(this.transform);   
            fetchFoodSeq.Kill();
           // Tweener back = transform.DOScaleY(1.48f, timer).SetEase(Ease.Linear);
            Tweener back = DOTween.To(() => spriteRenderer.size, x => spriteRenderer.size = x, new Vector2(2f, spriteRenderer.size.y), 1f).SetEase(Ease.Linear);
            back.OnUpdate(()=>
            {
                food.Follow(spriteRenderer.size.x);
            });
            boxcollider.enabled = false; // 防止夹取多个食物
            back.OnComplete(() =>
            {
                isIdle = true;
                boxcollider.enabled = true;
                if (transform.childCount > 0)
                {
                    if (OnEat != null) OnEat.Invoke(food.foodType);
                    Destroy(food.gameObject); // 或添加食用动作？
                    Debug.Log("饱食度++");
                }
            });
        }
    }
}
