using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public event System.Action OnBeEat;
    public int foodType;

    public void Follow(float offx)
    {
        transform.localPosition = new Vector3(offx,0,0);
    }
    /// <summary>
    /// ±»³Ôµô
    /// </summary>
    public void BeEat()
    {
        OnBeEat.Invoke();
        Destroy(this.gameObject);
    }
}
