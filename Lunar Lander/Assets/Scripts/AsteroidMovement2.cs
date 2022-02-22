using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement2 : MonoBehaviour
{
    //for position of asteroids in minigame (creative element)
    public GameObject Asteroid2;
    private float AsteroidX;
    private float AsteroidY;

    void Start()
    {
       
        //randomized start position (certain bounds)
        AsteroidX = Random.Range(-7.2f, -6.2f);
        AsteroidY = Random.Range(-3.8f, -3.3f);
        
        //random vector for position, which is set to transform
        Vector2 random_position = new Vector2(AsteroidX,AsteroidY);
        Asteroid2.transform.position = random_position;

        
    }

    void Awake()
    {
        
    }
}
