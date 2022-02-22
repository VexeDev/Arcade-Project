using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement1 : MonoBehaviour
{
    //for position of asteroids in minigame (creative element)
    //public GameObject Asteroid1;
    private float AsteroidX;
    private float AsteroidY;

    private Rigidbody2D rb;
    private float speed;
    private float angle;

    void Start()
    {
       
        //randomized start position (certain bounds)
        AsteroidX = Random.Range(-7.2f, -6.2f);
        AsteroidY = Random.Range(-3.8f, -3.3f);
        
        //random vector for position, which is set to transform
        Vector2 random_position = new Vector2(AsteroidX,AsteroidY);
        gameObject.transform.position = random_position;

        //sets velocity of asteroid
        speed = Random.Range(1f,2f);
        rb = GetComponent<Rigidbody2D>();
        angle = Random.Range(30f, 60f) * Mathf.Deg2Rad;
        
        
    }

    void Update()
    {
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        rb.velocity = direction * speed;
        //Debug.Log(rb.velocity);
    }
}

