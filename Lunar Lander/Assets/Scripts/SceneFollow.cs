using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFollow : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position != player.transform.position)
        {
            StartCoroutine(resizeRoutine(1));
        }
    }

    private IEnumerator resizeRoutine(float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(player.transform.position.x, player.transform.position.y - 2f, player.transform.position.z), t);
            yield return null;
        }
    }
}
