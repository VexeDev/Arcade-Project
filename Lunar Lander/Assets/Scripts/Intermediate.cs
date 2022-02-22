using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Intermediate : MonoBehaviour
{
    public TextMeshProUGUI loadingText;
    AsyncOperation async;

    int lives;

    public GameObject noOpen;
    public GameObject oneOpen;
    public GameObject twoOpen;
    public GameObject threeOpen;

    public GameObject oneRocket;
    public GameObject twoRocket;
    public GameObject threeRocket;

    // Start is called before the first frame update
    void Start()
    {
        //loading
        loadingText.text = "loading...";
        async = SceneManager.LoadSceneAsync(SceneManager.sceneCount+1);
        async.allowSceneActivation = false;

        lives = PlayerPrefs.GetInt("lives");

        if (lives == 3)
        {
            //no doors to 1 door
            StartCoroutine(NoToOne());
        } else if (lives == 2)
        {
            //1 door to 2 doors
            StartCoroutine(OneToTwo());
        } else if (lives == 1)
        {
            //2 doors to 3
            StartCoroutine(TwoToThree());
        }
    }

    private void Update()
    {
        if(async.progress == .9)
        {
            loadingText.text = "loaded";
        }
    }

    public IEnumerator NoToOne ()
    {
        noOpen.SetActive(true);
        yield return new WaitForSeconds(1);
        //open noise?
        noOpen.SetActive(false);
        oneOpen.SetActive(true);
        yield return new WaitForSeconds(1);
        oneRocket.SetActive(true);
        //drop sounds?
        yield return new WaitForSeconds(8.5f);
        StartCoroutine(LoadingScene());
    }

    public IEnumerator OneToTwo ()
    {
        oneOpen.SetActive(true);
        yield return new WaitForSeconds(1);
        oneOpen.SetActive(false);
        twoOpen.SetActive(true);
        yield return new WaitForSeconds(1);
        twoRocket.SetActive(true);
        yield return new WaitForSeconds(8.5f);
        StartCoroutine(LoadingScene());
    }

    public IEnumerator TwoToThree ()
    {
        twoOpen.SetActive(true);
        yield return new WaitForSeconds(1);
        twoOpen.SetActive(false);
        threeOpen.SetActive(true);
        yield return new WaitForSeconds(1);
        threeRocket.SetActive(true);
        yield return new WaitForSeconds(8.5f);
        StartCoroutine(LoadingScene());
    }

    public IEnumerator LoadingScene ()
    {
        async.allowSceneActivation = true;
        yield return async;
    }
}
