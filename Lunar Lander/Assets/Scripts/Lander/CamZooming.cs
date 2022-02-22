using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZooming : MonoBehaviour
{
    GameObject player;
    GameObject cam;

    public float zoomDuration = 1f;
    public float elapsed;
    public float zoomHeight = 2.5f;
    public float initialZoomAmount = 3f;
    public float zoomAmount = 2f;
    public bool snap = false;
    public bool canZoom = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed = Time.deltaTime / zoomDuration;
        //position
        Vector3 playerPosition = new Vector3(player.transform.position.x, player.transform.position.y-2f, -10);
        if (snap == true)
        {
            transform.position = (playerPosition);
        }
        //zoom
        if(canZoom == true)
        {
            if (playerPosition.y+2f > zoomHeight)
            {
                StartCoroutine(resizeRoutine(cam.GetComponent<Camera>().orthographicSize, initialZoomAmount, 1));
            }
            else if(playerPosition.y+2f <= zoomHeight)
            {
                StartCoroutine(resizeRoutine(cam.GetComponent<Camera>().orthographicSize, zoomAmount, 2));
                canZoom = false;
            }
        }
    }

    public IEnumerator resizeRoutine(float oldSize, float newSize, float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            cam.GetComponent<Camera>().orthographicSize = Mathf.Lerp(oldSize, newSize, t);
            yield return null;
            if (t == 1 && snap == false)
            {
                snap = true;
            }
        }
    }
}
