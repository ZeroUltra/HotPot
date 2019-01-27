using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class RoleItem : MonoBehaviour
{
    public Sprite[] roleImage;

    private bool isConfirm;
    public bool IsConfirm { get => isConfirm; private set => isConfirm = value; }
    private int index;
    private bool canChoose;
    public int Index
    {
        get => index;
        set
        {
            // 改变头像图片
            index = value;
            Debug.Log(index);
            if (index > roleImage.Length - 1)
            { index = 0; }

            image.sprite = roleImage[index];
            image.SetNativeSize();

            canChoose = false;
            // 隐藏立绘并向左偏移一段距离
            float localX = image.transform.localPosition.x;
            float offsetX = -50.0f;
            image.transform.position += new Vector3(offsetX, 0, 0);
            image.transform.DOScale(0.25f, 0);
            image.DOFade(0, 0);

            // 出现新的立绘，从左侧渐入
            Tweener tw = image.DOFade(1, 0.3f);
            tw.OnComplete(() =>
            {
                // 等待动画效果结束
                canChoose = true;
            });
            image.transform.DOLocalMoveX(localX, 0.3f).SetEase(Ease.Linear);

            // 播放switch音效
            audioSource.clip = switchAudio;
            audioSource.loop = false;
            audioSource.Play();
        }
    }

    private Image image;//立绘

    public Sprite playerId;
    private GameObject hint;
    private Image toggle;

    public AudioClip switchAudio;
    public AudioClip confirmAudio;
    AudioSource audioSource;

    void Start()
    {
        canChoose = true;
        //roleAvatar = Resources.LoadAll<Sprite>("Roleavatar");
        roleImage = Resources.LoadAll<Sprite>("UI/startScene/role");
        audioSource = gameObject.AddComponent<AudioSource>();


        toggle = transform.GetChild(0).GetComponent<Image>();
        image = transform.GetChild(1).GetComponent<Image>();
        hint = transform.GetChild(2).gameObject;



        //toggle.isOn = false;
        //toggle.gameObject.SetActive(false);
        //toggle.transform.localScale = Vector3.zero;
    }

    public void Init()
    {
        image.enabled = true;
        hint.SetActive(true);
        Index = 0;

        toggle.sprite = playerId;
        toggle.SetNativeSize();
        toggle.transform.localScale = Vector3.zero;
        toggle.transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBack);

        //toggle.gameObject.SetActive(true);
        //toggle.transform.localScale = Vector3.zero;


    }
    public void ChangeSp()
    {
        if (!canChoose)
            return;
        Index++;
    }

    public Characters Confirm()
    {
        //动效
        // 改变P1，P2..
        toggle.DOFade(0.2f, 0.5f);
        toggle.transform.DOScale(Vector3.one * 0.8f, 0.5f);

        IsConfirm = true;


        audioSource.clip = confirmAudio;
        audioSource.loop = false;
        audioSource.Play();

        return (Characters)Index;
    }
}
