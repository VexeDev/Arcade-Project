using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashLanding : MonoBehaviour
{
    GameObject lander;

    private void Start()
    {
        lander = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if(collision.tag == "Ground")
        {
            lander.GetComponent<LanderMovement>().CrashLand();
        } else if(collision.tag == "LandingPlatform" && (Vector2.Dot(transform.up, Vector2.down) > 0) == true)
        {
            lander.GetComponent<LanderMovement>().CrashLand();
        }
    }
}
