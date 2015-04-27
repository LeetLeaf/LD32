using UnityEngine;
using System.Collections;

public class NinjaWolf : MonoBehaviour 
{
    public int health;
    public float speed;
    public Transform Player;
    public bool direction;
    public bool changeDir;
    public float knockBack;
    public bool knockBool;
    public float knockTime;
    public float knockFade = 0.5f;

    public bool superKick;
    public float superKickTime;
    public float superKickFade;
    public float superKickSpeed;

    public bool superKickWait;
    public float superKickWaitTime;
    public float superKickWaitFade;


    public bool superKickCooldown;

    public Vector2 wolfVelocity;
    public Vector2 wolf;

	// Use this for initialization
	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        superKick = false;
        superKickCooldown = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        wolfVelocity = transform.GetComponent<Rigidbody2D>().velocity;
        if (superKickCooldown)
        { 
            superKickTime+=Time.deltaTime;
            if (superKickTime > 1.0f)
            {
                superKickCooldown = false;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                wolf = Vector2.zero;
                GetComponent<Rigidbody2D>().fixedAngle = false;

                superKickTime = 0;
            }
        }
        if (health < 1)
        {
            health = 1;
        }
        
        if(!superKick&&!superKickCooldown)
        {
            
            if (GetComponent<Rigidbody2D>().velocity.x > Vector2.zero.x)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - 1.0f * health *Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y - 1.0f *health* Time.deltaTime);
                //GetComponent<Rigidbody2D>().velocity.x
            }
            
            transform.position = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
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
                    transform.localScale = new Vector3(-5.5f, transform.localScale.y, 1);
                }
                else
                {
                    transform.localScale = new Vector3(5.5f, transform.localScale.y, 1);
                }
                changeDir = false;
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
            
        }
        else if (superKick)
        {
            /*superKickTime += Time.deltaTime;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().fixedAngle = true;
            transform.rotation=Quaternion.identity;
            if(superKickTime > superKickFade)
            {
                
                //GetComponent<Rigidbody2D>().isKinematic = false;
                wolf = Vector2.MoveTowards(gameObject.transform.position,GameObject.FindGameObjectWithTag("Player").transform.localPosition,superKickSpeed * Time.deltaTime);
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
               //GetComponent<Rigidbody2D>().fixedAngle = true;
                wolfVelocity = Vector3.zero;


                //transform.position = Vector2.MoveTowards(gameObject.transform.position, Player.position, superKickSpeed * Time.deltaTime);
                //GetComponent<Rigidbody2D>().AddForce(transform.position);

                
                //GetComponent<Rigidbody2D>().AddForce(new Vector2(wolf.x*100,wolf.y*100));
                GetComponent<Rigidbody2D>().velocity = wolf;
                superKick = false;
                superKickTime = 0;
                superKickCooldown = true;
            }
             */
            superKickWaitTime += Time.deltaTime;
            if (superKickWaitTime > superKickWaitFade)
            {
                superKickWait = false;
            }
            else
            {
                superKickWait = true;
            }
            if (!superKickWait)
            {
                transform.position = Vector2.MoveTowards(transform.position,Player.position,superKickSpeed * Time.deltaTime);
                superKickTime += Time.deltaTime;
                if (superKickTime > superKickFade)
                {
                    superKick = false;
                    superKickTime = 0;
                    superKickCooldown = true;
                    superKickWaitTime = 0;
                }
            }
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floppy")
        {
            Destroy(other.gameObject);
            health--;

        }

    }
}
