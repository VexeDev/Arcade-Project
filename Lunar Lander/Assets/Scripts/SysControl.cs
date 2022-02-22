using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SysControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
