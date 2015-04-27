using UnityEngine;
using System.Collections;

public class Lion : MonoBehaviour 
{
    public GameObject armLeft;
    public GameObject armRight;
    public GameObject gernade;

    public float speed;
    public int health;
   
    public Transform Player;
    public Vector3 dir;
    public float throwSpeed;

    public float angleLeft;
    public Vector2 angleLeftMod;

    public float angleRight;
    public Vector2 angleRightMod;

    public Quaternion throwAngle;
    public Quaternion leftANGLE;

    public float throwTimeLeft;
    public float throwFadeLeft;

    public float throwTimeRight;
    public float throwFadeRight;

    public bool leftThrow;
    public bool rightThrow;

    public bool walkRange;
    public bool throwRange;
	// Use this for initialization
	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        /*
        if (!leftThrow)
        {

            angleLeftMod = Vector2.MoveTowards(angleLeftMod, new Vector2(-90, 0), throwSpeed * Time.deltaTime);
        }
        if (!rightThrow)
        {
            angleRightMod = Vector2.MoveTowards(angleRightMod, new Vector2(-90, 0), throwSpeed * Time.deltaTime);
        }
        */
        if (GetComponent<Rigidbody2D>().velocity.x > Vector2.zero.x)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - 1.0f * health * Time.deltaTime, GetComponent<Rigidbody2D>().velocity.y - 1.0f * health * Time.deltaTime);
            //GetComponent<Rigidbody2D>().velocity.x
        }
        else if(GetComponent<Rigidbody2D>().velocity.x < Vector2.zero.x)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().inertia = 0;
        }
        if (walkRange)
        {
            GetComponent<Animation>().Stop();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            GetComponent<Animation>().Play("Walk");
        }
        if (throwRange)
        {
            dir = Player.position - armLeft.transform.position;
            angleLeft = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //armLeft.transform.rotation = Quaternion.AngleAxis(angleLeft + 90.0f, Vector3.forward);
            throwAngle = Quaternion.AngleAxis(angleLeft + 90.0f, Vector3.forward);
            /*
            dir = Player.position - armRight.transform.position;
            angleRight = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            armRight.transform.rotation = Quaternion.AngleAxis(angleRight + 90.0f, Vector3.forward);
            */

            dir = Player.position - armLeft.transform.position;
            angleLeft = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            armLeft.transform.rotation = Quaternion.AngleAxis(angleLeft + angleLeftMod.x, Vector3.forward);
            throwTimeLeft += Time.deltaTime;
            angleLeftMod = Vector2.MoveTowards(angleLeftMod, new Vector2(270, 0), throwSpeed * Time.deltaTime);
            if (angleLeftMod.x >= 270)
            {
                angleLeftMod = new Vector2(-90, 0);
            }
            if (throwTimeLeft > throwFadeLeft)
            {
                leftThrow = true;
            }
            dir = Player.position - armRight.transform.position;
            angleRight = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            armRight.transform.rotation = Quaternion.AngleAxis(angleRight + angleRightMod.x, Vector3.forward);
            throwTimeRight += Time.deltaTime;
            angleRightMod = Vector2.MoveTowards(angleRightMod, new Vector2(180, 0), throwSpeed * Time.deltaTime);
            if (angleRightMod.x >= 180)
            {
                angleRightMod = new Vector2(-180, 0);
            }
            if (throwTimeRight > throwFadeRight)
            {
                rightThrow = true;
            }

            if (Mathf.Round(throwAngle.z * Mathf.Rad2Deg) + 5 >= Mathf.Round(armLeft.transform.rotation.z * Mathf.Rad2Deg) && (Mathf.Round(throwAngle.z * Mathf.Rad2Deg) - 5 <= Mathf.Round(armLeft.transform.rotation.z * Mathf.Rad2Deg)))
            {
                if (leftThrow)
                {
                    Instantiate(gernade, armLeft.transform.GetChild(0).transform.position, Quaternion.identity);
                    leftThrow = false;
                    throwTimeLeft = 0;
                }

            }
            if (Mathf.Round(throwAngle.z * Mathf.Rad2Deg) + 5 >= Mathf.Round(armRight.transform.rotation.z * Mathf.Rad2Deg) && (Mathf.Round(throwAngle.z * Mathf.Rad2Deg) - 5 <= Mathf.Round(armRight.transform.rotation.z * Mathf.Rad2Deg)))
            {
                if (rightThrow)
                {
                    Instantiate(gernade, armRight.transform.GetChild(0).transform.position, Quaternion.identity);
                    rightThrow = false;
                    throwTimeRight = 0;
                }
            }
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
