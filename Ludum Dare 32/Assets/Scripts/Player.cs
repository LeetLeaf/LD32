using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
    public int health;
    public float speed;
    public int ammo;
    public Object floppy;
    public GameObject PlayerArm;
    public Vector3 mousePos;
    public GameObject diskDrive;
    public Sprite PlayerFront;
    public Sprite PlayerBack;
    public float knockBack;
    public bool knockBool;
    public float knockTime;
    public float knockFade;
    public int Score;
	// Use this for initialization
	void Start () 
    {
        Physics2D.IgnoreLayerCollision(8, 9);
        Physics2D.IgnoreLayerCollision(9,11);
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.lockState = CursorLockMode.Confined;
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            GetComponent<Animation>().Stop();
        }
        else
        {
            GetComponent<Animation>().Play();
        }


        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(new Vector3(0,speed*Time.deltaTime,0));
            GetComponent<SpriteRenderer>().sprite = PlayerBack;
            PlayerArm.transform.localPosition = new Vector3(0.072f, 0.035f, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            
            GetComponent<SpriteRenderer>().sprite = PlayerFront;
            PlayerArm.transform.localPosition = new Vector3(-0.102f,0.043f,0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(new Vector3(-speed*Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.Translate(new Vector3(speed * Time.deltaTime,0, 0));
        }
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(floppy,diskDrive.transform.position,diskDrive.transform.rotation);
            if (!Input.GetMouseButtonUp(1))
            {
                diskDrive.transform.position = Vector2.MoveTowards(diskDrive.transform.position, mousePos, 1000 * Time.deltaTime);
            }
        }

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OWW GOT HIT!!");
        if (other.gameObject.tag == "bullet")
        {
            Destroy(other.gameObject);
            knockBool = true;
        }
        if (other.gameObject.tag == "Wolf")
        {
            GetComponent<AudioSource>().Play();
                Vector2 enemy = new Vector2(other.transform.position.x, other.transform.position.y);
                Vector2 player = new Vector2(transform.position.x, transform.position.y);
            if (other.gameObject.GetComponent<NinjaWolf>().superKickCooldown || other.gameObject.GetComponent<NinjaWolf>().superKick)
            {
                knockBool = true;
                GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(player, enemy, knockBack*2 * Time.deltaTime), ForceMode2D.Force);
                other.gameObject.GetComponent<NinjaWolf>().superKickTime = other.gameObject.GetComponent<NinjaWolf>().superKickFade;
                
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(enemy, player, knockBack * Time.deltaTime), ForceMode2D.Force);
            }
            else
            {
                knockBool = true;
                other.gameObject.GetComponent<NinjaWolf>().knockBool = true;
                


                GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(player, enemy, knockBack * Time.deltaTime), ForceMode2D.Force);
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(enemy, player, knockBack * Time.deltaTime), ForceMode2D.Force);
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("TRIGGER!!!!");
        if (other.gameObject.tag == "super kick")
        {
            if (!other.transform.parent.GetComponent<NinjaWolf>().superKickCooldown || !other.transform.parent.GetComponent<NinjaWolf>().superKick)
            {
                //other.transform.parent.GetComponent<Rigidbody2D>().isKinematic = true;
                other.transform.parent.GetComponent<NinjaWolf>().superKick = true;
            }
        }
        if (other.gameObject.tag == "walkRange")
        {
            other.transform.parent.GetComponent<Lion>().walkRange = true;
        }
        if (other.gameObject.tag == "throwRange")
        {
            other.transform.parent.GetComponent<Lion>().throwRange = true;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootRange")
        {
            other.gameObject.transform.parent.GetComponent<BearFU>().shootRange = true;
        }
        if (other.gameObject.tag == "throwRange")
        {
            other.transform.parent.GetComponent<Lion>().throwRange = true;
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "shootRange")
        {
            other.gameObject.transform.parent.GetComponent<BearFU>().shootRange = false;
        }
        if (other.gameObject.tag == "walkRange")
        {
            other.transform.parent.GetComponent<Lion>().walkRange = false;
        }
        if (other.gameObject.tag == "throwRange")
        {
            other.transform.parent.GetComponent<Lion>().throwRange = false;
        }
    }

}
