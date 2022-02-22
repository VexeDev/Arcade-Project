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
        if(collision.tag == "Ground")
        {
            lander.GetComponent<LanderMovement>().CrashLand();
        }
    }
}
