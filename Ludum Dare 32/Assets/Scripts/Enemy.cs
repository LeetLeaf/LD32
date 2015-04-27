using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
    public int health;
    public float speed;
    public GameObject target;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (health <= 0)
        {
            Destroy(gameObject);
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
