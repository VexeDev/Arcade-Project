using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManagement : MonoBehaviour
{
    public TextMeshProUGUI velocity_xText;
    public TextMeshProUGUI velocity_yText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI altitudeText;
    public TextMeshProUGUI livesText;
    GameObject lander;
    public bool isMainLevel = true;

    // Start is called before the first frame update
    void Start()
    {
        if (isMainLevel == true)
        {
            lander = GameObject.FindWithTag("Player");
        }
        if(SceneManager.sceneCount == 0)
        {
            PlayerPrefs.SetInt("currentScore", 0);
        }
        UpdateScore();
        UpdateLives();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMainLevel == true)
        {
            if (lander.GetComponent<Rigidbody2D>().velocity.magnitude >= 250)
            {
                velocity_yText.text = "Current Velocity: 1000";
                velocity_xText.text = "Current Velocity: 1000";
            }
            else
            {
                velocity_yText.text = "Vertical Velocity: " + Mathf.Abs(lander.GetComponent<Rigidbody2D>().velocity.y * 100).ToString("F0");
                velocity_xText.text = "Horizontal Velocity: " + Mathf.Abs(lander.GetComponent<Rigidbody2D>().velocity.x * 100).ToString("F0");
            }
        } 
        else
        {
            float timerGrab = this.gameObject.GetComponent<AstGeneration>().timer;
            timerGrab = Mathf.Round(timerGrab);
            timerText.text = "Time: " + timerGrab.ToString();
            
        }
    }

    void LateUpdate()
    {
        Vector3 pos = lander.GetComponent<Rigidbody2D>().position;
        float altitude = (pos.y * 10f) + 25;
        altitudeText.text = "altitude: " + altitude.ToString("F0");
    }

    public void UpdateScore ()
    {
        currentScoreText.text = "Score: " + PlayerPrefs.GetInt("currentScore").ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void UpdateLives ()
    {
        livesText.text = "Lives: " + PlayerPrefs.GetInt("lives").ToString();
    }
}
