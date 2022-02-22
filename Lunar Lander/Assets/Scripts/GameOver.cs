using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        currentScoreText.text = "Score: " + PlayerPrefs.GetInt("currentScore").ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SceneManager.LoadScene(0);
        }
    }
}
