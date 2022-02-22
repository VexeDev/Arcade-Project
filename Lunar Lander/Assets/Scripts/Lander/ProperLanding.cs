using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProperLanding : MonoBehaviour
{
    Vector2 upwards;
    GameObject mainLander;

    public void Start()
    {
        mainLander = GameObject.FindWithTag("Player");
        upwards = mainLander.transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LandingPlatform" && mainLander.GetComponent<Rigidbody2D>().velocity.magnitude <= .1f)
        {
            mainLander.GetComponent<LanderMovement>().Land();
        } else
        {
            mainLander.GetComponent<LanderMovement>().CrashLand();
        }
    }
}
