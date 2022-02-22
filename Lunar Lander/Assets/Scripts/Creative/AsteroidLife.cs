using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidLife : MonoBehaviour
{
    GameObject eventHandler;
    public int scoreAdd;
    public GameObject explosionObj;

    private void Start()
    {
        eventHandler = GameObject.FindGameObjectWithTag("Respawn");
    }

    public void Destroy ()
    {
        //change score
        PlayerPrefs.SetInt("currentScore", PlayerPrefs.GetInt("currentScore") + scoreAdd);
        if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("currentScore"));
        }
        eventHandler.GetComponent<UIManagement>().UpdateScore();

        //instantiate explosion
        GameObject explosion = Instantiate(explosionObj, this.transform);
        explosion.GetComponent<Explosion>().playSound = true;
        explosion.transform.parent = null;

        //destroy
        Destroy(this.gameObject);
    }
}
