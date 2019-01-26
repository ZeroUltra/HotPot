using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Arm : MonoBehaviour
{
    float angle = 0.0f;
    float speed = 1.0f;
    float maxAngle = 30.0f;
    bool isShaking = true;
    //float dir = 1.0f;
    
    Tweener tw;
    Sequence quence;
    // Start is called before the first frame update
    void Start()
    {
        //quence = DOTween.Sequence();
        quence.Append(transform.DORotate(Vector3.forward * 30, 2)).SetEase(Ease.Linear);
        //quence.Append(transform.DORotate(Vector3.forward * 0, 2)).SetEase(Ease.Linear);
        //quence.Append(transform.DORotate(Vector3.forward * -30, 2)).SetEase(Ease.Linear);
        //quence.Append(transform.DORotate(Vector3.forward * 0, 2)).SetEase(Ease.Linear);
        //quence.SetLoops(-1);
        //  transform.localEulerAngles = new Vector3(0, 0, 0);
        //tw = transform.DOShakeRotation(4,new Vector3(0,0,60)).SetLoops(-1);


    }

    // Update is called once per frame
    float timer =0;
    void Update()
    {
        //timer += Time.deltaTime;

        //angle += Time.deltaTime * speed;
        //angle = Mathf.Clamp(angle, -maxAngle, maxAngle);
        keyControl();
        ////tw.Pause();

        if (isShaking)
        {
            if (angle > -maxAngle && angle < maxAngle)
            {
                transform.Rotate(new Vector3(0, 0, speed));
                angle += speed;
            }
            else
            {
                speed = -speed;
                transform.Rotate(new Vector3(0, 0, speed));
                angle += speed;
            }
        }

    }
    public void Test1()
    {

    }
    private void keyControl()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            tw.Pause();
            isShaking = !isShaking;
            fetch();
        }
    }
    private void fetch()
    {
        Tweener tw = transform.DOScaleY(2,1);
        tw.OnComplete(() =>
        {
            isShaking = !isShaking;
            
        });

    }
}
