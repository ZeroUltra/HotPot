using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RoleItem : MonoBehaviour
{
    public Sprite[] sps;

    private bool isConfirm;
    public bool IsConfirm { get => isConfirm; private set => isConfirm = value; }
    private int index;
    public int Index
    {
        get => index;
        set
        {
            index = value;
            if (index > sps.Length - 1)
            { index = 0; }

            image.sprite = sps[index];
        }
    }

    private Image image;

    private Toggle toggle;
    void Start()
    {
        sps = Resources.LoadAll<Sprite>("Roleavatar");
        image = GetComponent<Image>();
        toggle = GetComponentInChildren<Toggle>();
        toggle.isOn = false;
        toggle.gameObject.SetActive(false);
        toggle.transform.localScale = Vector3.zero;
    }
    
    public void Init()
    {
        Index = 0;
        toggle.gameObject.SetActive(true);
        toggle.transform.DOScale(Vector3.one,0.6f).SetEase(Ease.OutBack);
        toggle.image.color = new Color(Random.value, Random.value, Random.value);
    }
    public void ChangeSp()
    {
        Index++;
    }

    public Characters Confirm()
    {
        //¶¯Ð§
        toggle.isOn = true;
        IsConfirm = true;
        return (Characters)Index;
    }
}
