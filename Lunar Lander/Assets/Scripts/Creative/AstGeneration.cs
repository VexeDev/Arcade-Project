using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AstGeneration : MonoBehaviour
{
    public GameObject asteroid;
    public float initialDelay;
    public float cooldownDelay;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeAst", initialDelay, cooldownDelay);
    }

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            StartCoroutine(EndTheLevel());
        }
    }

    public void MakeAst ()
    {
        if (timer >= 0)
        {
            Instantiate(asteroid, gameObject.transform);
        } 
    }

    public IEnumerator EndTheLevel()
    {
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}
