using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    GameObject player;
    GameObject scene;
    Camera cam;
    float initialGravityScale;

    public LandingPiece[] landingZones;

    // Start is called before the first frame update
    void Start()
    {
        //landing zones
        landingZones = FindObjectsOfType<LandingPiece>();
        int landingZone = Random.Range(0, landingZones.Length);
        LandingPiece selectedZone = landingZones[landingZone];
        for (int i = 0; i < landingZones.Length; i++)
        {
            landingZones[i].gameObject.SetActive(false);
        }
        selectedZone.gameObject.SetActive(true);

        //camera
        player = GameObject.FindGameObjectWithTag("Player");
        initialGravityScale = player.GetComponent<Rigidbody2D>().gravityScale;
        player.GetComponent<Rigidbody2D>().gravityScale = 0;
        player.GetComponent<LanderMovement>().canMove = false;
        scene = GameObject.FindGameObjectWithTag("Scene");
        scene.GetComponent<SceneFollow>().enabled = false;
        cam = Camera.main;
        cam.GetComponent<CamZooming>().enabled = false;
        cam.transform.position = new Vector3(0, 0, -10);
    }

    // Update is called once per frame
    void Update()
    {
        //commit zoom
        //reenable zoom
    }

    public void initialZoom ()
    {
        StartCoroutine(resizeRoutine(2f));
    }

    private IEnumerator resizeRoutine(float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            Vector3 finishPos;
            finishPos.x = player.transform.position.x;
            finishPos.y = player.transform.position.y-2f;
            finishPos.z = -10;
            scene.GetComponent<SceneFollow>().enabled = true;
            cam.gameObject.transform.position = Vector3.Lerp(cam.gameObject.transform.position, finishPos, t);
            if(t == 1)
            {
                cam.GetComponent<CamZooming>().enabled = true;
                player.GetComponent<Rigidbody2D>().gravityScale = initialGravityScale;
                player.GetComponent<LanderMovement>().canMove = true;
                yield return null;
            }
            yield return null;
        }
    }
}
