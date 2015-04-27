using UnityEngine;
using System.Collections;

public class BearFU : MonoBehaviour 
{
    public Transform Player;
    public GameObject bullet;
    public float speed;
    public int health;
    public bool direction;
    public bool changeDir;
    public bool shootRange;

    public float shotTime;
    public float shotFade;
    public AnimationClip Walk;

    public float knockBack;
    public bool knockBool;
    public float knockTime;
    public float knockFade = 0.5f;
	// Use this for initialization
	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	void Update () 
    {

        if (GetComponent<Rigidbody2D>().velocity.x > Vector2.zero.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - 1.0f * health * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y - 1.0f * health * Time.deltaTime);
            //GetComponent<Rigidbody2D>().velocity.x
        }
        if (knockBool)
        {
            knockTime += Time.deltaTime;
            if (knockTime > knockFade)
            {
                knockTime = 0;
                knockBool = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        if (shootRange)
        {
            shotTime += Time.deltaTime;
            if (shotTime > shotFade)
            {
                Instantiate(bullet, transform.GetChild(0).transform.position, transform.GetChild(0).transform.rotation);
                shotTime = 0;
            }
            GetComponent<Animation>().Stop();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position,Player.position,speed*Time.deltaTime);
            GetComponent<Animation>().Play("Walk");
        }
        if (transform.position.x < Player.position.x && direction)
        {
            direction = false;
            changeDir = true;
            Debug.Log("CHANGED: " + changeDir + direction);
        }
        else if (transform.position.x > Player.position.x && !direction)
        {
            direction = true;
            changeDir = true;
            Debug.Log("CHANGED: " + changeDir + direction);
        }
        if (changeDir)
        {
            if (direction)
            {
                transform.localScale = new Vector3(-6.5f, transform.localScale.y, 1);
            }
            else
            {
                transform.localScale = new Vector3(6.5f, transform.localScale.y, 1);
            }
            changeDir = false;
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floppy")
        {
            Destroy(other.gameObject);
            health--;

        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        /*
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().health--;
            other.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.up,transform.position);
        }
         */
        if (other.gameObject.tag == "Floppy")
        {
            health--;
        }
    }
}
