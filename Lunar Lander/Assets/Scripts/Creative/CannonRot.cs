using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRot : MonoBehaviour
{
    public float speed;
    public GameObject laserInstantiation;
    public AudioSource audio1;
    bool canShoot = true;
    public float laserCooldown;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //rotate right
            transform.Rotate(Vector3.forward * speed * Time.deltaTime * -1);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //rotate left
            this.transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }

        //check for action 1 button changes
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftCommand) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            if (canShoot == true)
            {
                //sound
                audio1.Play();
                //fire/instantiate laser
                Instantiate(laserInstantiation, this.transform);
                canShoot = false;
                StartCoroutine(Cooldown());
            }
        }

        //LIMIT THE ROTATION OF THE CANNON
        Vector3 eulerLimit = transform.eulerAngles;
        if (eulerLimit.z > 180)
        {
            eulerLimit.z = eulerLimit.z - 360;
        }
        eulerLimit.z = Mathf.Clamp(eulerLimit.z, -80, 80);
        transform.eulerAngles = eulerLimit;
    }

    public IEnumerator Cooldown ()
    {
        yield return new WaitForSeconds(laserCooldown);
        canShoot = true;
    }
}
