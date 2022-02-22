using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //movement
        this.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * speed);
        this.transform.parent = null;
    }

    //collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy rock
        if (collision.tag == "Asteroid")
        {
            collision.GetComponent<AsteroidLife>().Destroy();
            Destroy(this.gameObject);
        }
        //despawn
        else if (collision.tag == "Bound")
        {
            Destroy(this.gameObject);
        }
    }
}
