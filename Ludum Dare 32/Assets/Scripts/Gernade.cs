using UnityEngine;
using System.Collections;

public class Gernade : MonoBehaviour
{
    public Vector3 player;
    public GameObject explosion;
    public float speed;
    public float boom;
    public float alive;
    public bool spawnBoom;
	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        spawnBoom = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        
        if (transform.position == player || alive > 1.0f)
        {
            boom += Time.deltaTime;
            GetComponent<Rigidbody2D>().isKinematic = true;
            
            if (!GetComponent<AudioSource>().isPlaying)
            {
                //GetComponent<AudioSource>().Play();
            }
            if (boom < 0.1f)
            {
                if(spawnBoom)
                    Instantiate(explosion, transform.position, transform.rotation);
                spawnBoom = false;
                GetComponent<CircleCollider2D>().radius = boom * 20;
            }
            if (boom > 0.4f)
            {
                Destroy(gameObject);
            }
        }
        else
        { 
            alive += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, player, speed * Time.deltaTime);
        }
	}
    void OnCollision2DEnter(Collision2D other)
    {
        if (other.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(Vector2.one * 10000, transform.position);
        }
    }
}
