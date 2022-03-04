using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanderMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float thrust;
    public float torqueThrust;
    public float velocityThreshold;
    public bool canMove = true;
    public GameObject eventHandler;
    public GameObject flameCaster;
    public Sprite deathSprite;
    public GameObject explosionObj;

    public AudioSource audio1; //crash
    public AudioSource audio2; //land
    public AudioSource audio3; //failMus
    public AudioSource audio4; //thrust

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            /* KEYBOARD/CABINET */
            //check for rotation button changes
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //add right rotation using addTorque (-1 is to get it going the opposite direction)
                rb.AddTorque(torqueThrust * -1);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //add right rotation using addTorque 
                rb.AddTorque(torqueThrust);
            }

            //check for action 1 button changes
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.Joystick1Button2))
            {
                //apply thrust using addForce
                rb.AddForce(transform.up * thrust);
                flameCaster.GetComponent<AlternateFlames>().shouldFlame = true;
                if (audio4.isPlaying == false)
                {
                    audio4.Play();
                }
            }
            else
            {
                flameCaster.GetComponent<AlternateFlames>().shouldFlame = false;
                audio4.Stop();
            }

            /* NON RELATED KEY BINDINGS */
            //to prevent the ship from gaining too much liftoff speed, throttle it down if it is both going upwards and above x speed
            if (rb.velocity.magnitude >= velocityThreshold)
            {
                rb.velocity = rb.velocity.normalized * velocityThreshold;
            }
        }
    }

    public void Land ()
    {
        //lives
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);

        //stop movement fix rotation
        canMove = false;
        flameCaster.GetComponent<AlternateFlames>().shouldFlame = false;
        audio4.Stop();
        rb.Sleep();

        //score
        PlayerPrefs.SetInt("currentScore", PlayerPrefs.GetInt("currentScore") + 1000);
        if(PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highScore"))
        {
            PlayerPrefs.SetInt("highScore", PlayerPrefs.GetInt("currentScore"));
        }
        eventHandler.GetComponent<UIManagement>().UpdateScore();
        eventHandler.GetComponent<UIManagement>().UpdateLives();

        //fancy camera zoom & load bonus level
        StopAllCoroutines();
        StartCoroutine(Landing());
    }

    public void CrashLand()
    {
        //lives
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
        eventHandler.GetComponent<UIManagement>().UpdateLives();

        canMove = false;
        flameCaster.GetComponent<AlternateFlames>().shouldFlame = false;
        audio4.Stop();
        rb.Sleep();
        StopAllCoroutines();
        StartCoroutine(Crashing());
    }

    public IEnumerator Landing()
    {
        //play sound
        audio2.Play();
        //cam prep
        Camera.main.GetComponent<CamZooming>().snap = false;
        Camera.main.GetComponent<CamZooming>().canZoom = false;
        //move cam
        StartCoroutine(CamMove(4));
        //zoom cam
        StartCoroutine(Camera.main.gameObject.GetComponent<CamZooming>().resizeRoutine(Camera.main.orthographicSize, 2, 4));
        yield return new WaitForSeconds(1);
        //end
        yield return new WaitForSeconds(3);
        //load new scene
        if (PlayerPrefs.GetInt("lives") < 1)
        {
            SceneManager.LoadScene("Bonus");
        } else
        {
            SceneManager.LoadScene(1);
        }
        
    }

    public IEnumerator Crashing()
    {
        //play sound
        audio1.Play();
        //respawn explosion
        
        this.GetComponent<SpriteRenderer>().sprite = null;
        GameObject z = Instantiate(explosionObj, this.gameObject.transform);
        z.transform.localScale = new Vector2(5, 5);
        //cam prep
        Camera.main.GetComponent<CamZooming>().snap = false;
        Camera.main.GetComponent<CamZooming>().canZoom = false;
        //move cam
        StartCoroutine(CamMove(4));
        //play fail sound
        //zoom cam
        StartCoroutine(Camera.main.gameObject.GetComponent<CamZooming>().resizeRoutine(Camera.main.orthographicSize, 2, 4));
        yield return new WaitForSeconds(1);
        //end
        audio3.Play();
        yield return new WaitForSeconds(2);
        if (PlayerPrefs.GetInt("lives") < 1)
        {
            SceneManager.LoadScene("Bonus");
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    public IEnumerator CamMove(float time)
    {
        float elapsed = 0;
        while (elapsed <= time)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / time);

            Vector3 oldPos = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, -10);
            Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y, -10);
            Camera.main.transform.position = Vector3.Lerp(oldPos, newPos, t);
            yield return null;
        }
    }
}
