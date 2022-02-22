using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPosition : MonoBehaviour
{
    public float speed;

    Vector2 startPos;
    Vector2 finalPos;

    //do left or right
    //if left start at a random height on the left position
    //if right start at a random height on the right position
    //move to startpos
    //then decide the next position it will move to
    //lerp or velocity to it

    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;

        speed = Random.Range(3f,6f);
        //start pos
        bool startLeft = false;
        float ranNum = Random.Range(0f, 100f);
        if(ranNum > 50f)
        {
            startLeft = true;
        }


        if(startLeft == true)
        {
            startPos = new Vector2(-10f, Random.Range(-250f, 400f)/100f);
        } else
        {
            startPos = new Vector2(10f, Random.Range(-250f, 400f)/100f);
        }
        this.transform.position = startPos;

        //final pos
        if(startLeft == true)
        {
            finalPos = new Vector2(10f, Random.Range(-1f, 5f));
        } else
        {
            finalPos = new Vector2(-10f, Random.Range(-1f, 5f));
        }
    }

    private void Update()
    {
        //move towards finalpos
        transform.position = Vector3.MoveTowards(transform.position, finalPos, Time.deltaTime * speed);
    }

}
