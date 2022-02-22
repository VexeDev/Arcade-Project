using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPiece : MonoBehaviour
{
    GameObject[] landingPieces;

    // Start is called before the first frame update
    void Start()
    {
        landingPieces = GameObject.FindGameObjectsWithTag("LandingPlatform");
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Blink ()
    {
        for (int i = 0; i < landingPieces.Length; i++)
        {
            if (landingPieces[i].GetComponent<SpriteRenderer>() != null && landingPieces[i].activeInHierarchy == true)
            {
                landingPieces[i].GetComponent<SpriteRenderer>().color = Color.red;
                yield return new WaitForSeconds(1);
                landingPieces[i].GetComponent<SpriteRenderer>().color = Color.white;
                yield return new WaitForSeconds(1);
                landingPieces[i].GetComponent<SpriteRenderer>().color = Color.red;
                yield return new WaitForSeconds(1);
                landingPieces[i].GetComponent<SpriteRenderer>().color = Color.white;
                yield return new WaitForSeconds(1);
                landingPieces[i].GetComponent<SpriteRenderer>().color = Color.red;
                yield return new WaitForSeconds(1);
                landingPieces[i].GetComponent<SpriteRenderer>().color = Color.white;
                GameObject es = GameObject.FindGameObjectWithTag("Respawn");
                es.GetComponent<LevelStart>().initialZoom();
            }
        }
        yield return new WaitForSeconds(1);
    }
}
