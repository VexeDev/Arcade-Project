using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public List<GameObject> explosionItems;
    public float changeSpriteTimer;
    public bool playSound = false;
    public AudioSource audio1;

    // Start is called before the first frame update
    void Start()
    {
        if(playSound == true)
        {
            audio1.Play();
        }
        foreach (Transform child in gameObject.transform)
        {
            explosionItems.Add(child.gameObject);
        }

        StartCoroutine(DoExplosion());
        StartCoroutine(GoAway());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator DoExplosion ()
    {
        while (this.gameObject != null)
        {
            explosionItems[0].SetActive(true);
            explosionItems[1].SetActive(false);
            yield return new WaitForSeconds(changeSpriteTimer);
            explosionItems[0].SetActive(false);
            explosionItems[1].SetActive(true);
            yield return new WaitForSeconds(changeSpriteTimer);
        }
    }

    public IEnumerator GoAway()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
