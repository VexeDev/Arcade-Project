using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Flash", 0f, 2f);
    }

    void Flash ()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink ()
    {
        this.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(1);
    }
}
