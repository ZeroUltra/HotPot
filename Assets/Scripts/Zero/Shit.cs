using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Shit : MonoBehaviour
{
    public Transform target;
    public event Action OnTrigger;
    public Sprite[] sps; //shit«–ªª
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer; //
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = UnityEngine.Random.Range(2f, 2.4f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sps[0];
        GameTools.WaitDoSomeThing(this, 0.3f, () =>
          {
              spriteRenderer.sprite = sps[1];
          });
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform == target)
        {
            spriteRenderer.sprite = sps[2];
            OnTrigger.Invoke();
        }
    }
}
