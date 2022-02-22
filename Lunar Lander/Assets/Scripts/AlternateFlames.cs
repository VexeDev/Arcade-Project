using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternateFlames : MonoBehaviour
{
    public GameObject flame1;
    public GameObject flame2;
    public bool shouldFlame = false;

    private void Update()
    {
        if (shouldFlame)
        {
            StartCoroutine(Alternative());
        } else
        {
            StopCoroutine(Alternative());
            flame1.SetActive(false);
            flame2.SetActive(false);
        }
    }

    public IEnumerator Alternative ()
    {
        flame1.SetActive(true);
        flame2.SetActive(false);
        yield return new WaitForSeconds(.25f);
        flame1.SetActive(false);
        flame2.SetActive(true);
        yield return new WaitForSeconds(.25f);
    }
}
