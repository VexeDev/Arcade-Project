using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    AsyncOperation async;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI loadingText;

    AudioSource menuAudio;

    private void Start()
    {
        //audio
        menuAudio = this.GetComponent<AudioSource>();
        //score
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();

        //lives
        PlayerPrefs.SetInt("lives", 3);
        //loading
        loadingText.text = "loading...";
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;
    }

    public void Play ()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        StartCoroutine(LoadingScene());
    }

    public void Quit ()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            //sound
            menuAudio.Play();
            //wait then play
            StartCoroutine(PlayDelay());
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            //sound
            menuAudio.Play();
            //wait then quit
            StartCoroutine(QuitDelay());
        }
        Debug.Log(async.progress);
        if(async.progress >= .9f)
        {
            loadingText.text = "loaded!";
        }
    }

    public IEnumerator LoadingScene()
    {
        async.allowSceneActivation = true;
        yield return async;
    }

    public IEnumerator PlayDelay ()
    {
        yield return new WaitForSeconds(1);
        Play();
    }
    public IEnumerator QuitDelay()
    {
        yield return new WaitForSeconds(1);
        Quit();
    }
}
