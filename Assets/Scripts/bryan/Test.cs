using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame updat
    public Button button;
    void Start()
    {
        //Tweener tweener= GetComponent<Text>().DOText("hello world", 3).SetEase(Ease.Linear);
        //tweener.SetDelay(2f);
        //tweener.OnComplete(() =>
        //{
        //    GetComponent<Text>().color = Color.red;

        //});
      Tweener tweener=  transform.DOMove(Vector3.one * 2, 2);
        // tweener.
        button.onClick.AddListener(delegate()
        {
            Debug.Log("11");
        });
    }

    //private void OnClick()
    //{
    //    Debug.Log("11");
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
   
}
