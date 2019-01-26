using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
public class GameTools
{

    /// <summary>
    /// 显示隐藏物体
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="isOpen">是否显示</param>
    /// <param name="duartion">持续时间</param>
    /// <param name="openEase">打开时的ease</param>
    /// <param name="closeEase">关闭时的ease</param>
    /// <param name="OnOpenEnd">打开结束回调</param>
    /// <param name="OnCloseEnd">关闭结束回调</param>
    public static void ShowOrHideUI(Transform trans, bool isOpen, float duartion = 0.4f, Ease openEase = Ease.OutBack, Ease closeEase = Ease.InBack, UnityAction OnOpenEnd = null, UnityAction OnCloseEnd = null)
    {
        if (isOpen)
        {
            trans.gameObject.SetActive(true);
            trans.localScale = Vector3.zero;
            trans.DOScale(Vector3.one, duartion).SetEase(openEase).OnComplete(() =>
                {
                    if (OnOpenEnd != null) OnOpenEnd.Invoke();
                });
        }
        else
        {
            trans.DOScale(Vector3.zero, duartion).SetEase(closeEase).OnComplete(() =>
            {
                trans.gameObject.SetActive(false);
                if (OnCloseEnd != null) OnCloseEnd.Invoke();
            });
        }
    }

    /// <summary>
    /// 等待x事件之后执行某事
    /// </summary>
    /// <param name="mono">MonoBehaviour</param>
    /// <param name="duartion">等待时长</param>
    /// <param name="action">回调</param>
    public static void WaitDoSomeThing(MonoBehaviour mono, float duartion, System.Action action)
    {
        mono.StartCoroutine(IEWait(mono, duartion, action));
    }
    private static IEnumerator IEWait(MonoBehaviour mono, float duartion, System.Action action)
    {
        yield return new WaitForSeconds(duartion);
        if (action != null) action();
    }

    /// <summary>
    /// 淡入淡出
    /// </summary>
    /// <param name="uiGo"></param>
    /// <param name="fadeToHide">是否fade到0（然后关闭该物体）</param>
    /// <param name="duartion">持续时间</param>
    /// <param name="zeroCallback">fade到0回调</param>
    /// <param name="oneCallback">fade到1回到</param>
    public static void FadeUI(GameObject uiGo, bool fadeToHide, float duartion = 0.5f, UnityAction zeroCallback = null, UnityAction oneCallback = null)
    {
        SpriteRenderer spriteRenderer = uiGo.GetComponent<SpriteRenderer>();
        CanvasGroup canvasGroup = uiGo.GetComponent<CanvasGroup>();
        Image image = uiGo.GetComponent<Image>();
        if (uiGo.gameObject.activeInHierarchy) uiGo.SetActive(true);
        if (canvasGroup != null)
        {
            if (fadeToHide)
            {
                canvasGroup.DOFade(0, duartion).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (canvasGroup.alpha <= 0.1f)
                    {
                        uiGo.gameObject.SetActive(false);
                        if (zeroCallback != null)
                            zeroCallback.Invoke();
                    }
                });
            }
            else
            {
                uiGo.gameObject.SetActive(true);
                canvasGroup.alpha = 0f;
                canvasGroup.DOFade(1, duartion).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (canvasGroup.alpha >= 0.9f)
                    {
                        if (oneCallback != null)
                            oneCallback.Invoke();
                    }
                });
            }

        }
        else if (image != null)
        {
            if (fadeToHide)
            {
                image.DOFade(0, duartion).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (image.color.a <= 0.1f)
                    {
                        uiGo.gameObject.SetActive(false);
                        if (zeroCallback != null)
                            zeroCallback.Invoke();
                    }
                });
            }
            else
            {

                uiGo.gameObject.SetActive(true);
                image.color = new Color(1, 1, 1, 0f);
                image.DOFade(1, duartion).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (image.color.a >= 0.9f)
                    {
                        if (oneCallback != null)
                            oneCallback.Invoke();
                    }
                });
            }
        }
        else if (spriteRenderer != null)
        {
            if (fadeToHide)
            {
                spriteRenderer.color = Color.white;
                spriteRenderer.DOFade(0, duartion).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (spriteRenderer.color.a <= 0.1f)
                    {
                        uiGo.gameObject.SetActive(false);
                        if (zeroCallback != null)
                            zeroCallback.Invoke();
                    }
                });
            }
            else
            {
                spriteRenderer.color = new Color(1, 1, 1, 0);
                uiGo.gameObject.SetActive(true);
                spriteRenderer.DOFade(1, duartion).SetEase(Ease.Linear).OnComplete(() =>
                {
                    if (spriteRenderer.color.a >= 0.9f)
                    {
                        if (oneCallback != null)
                            oneCallback.Invoke();
                    }
                });
            }
        }
    }


    /// <summary>
    /// 主画布
    /// </summary>
    /// <returns></returns>
    private static Transform mainCanvas;
    public static Transform MainCanvas
    {
        get
        {
            if (mainCanvas == null)
                mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;
            return mainCanvas;
        }
    }
    public static string GetCurrentTime()
    {
        return System.DateTime.Now.ToString("HH.mm.ss");
    }

    public static void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
