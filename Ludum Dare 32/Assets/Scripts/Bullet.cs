using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
    public Vector3 dir;
    public float angle;
    public float speed;
    public static float travelTimeMax = 0.5f;
    public float travelTime = 0;
	// Use this for initialization
	void Start () 
    {
        Physics2D.IgnoreLayerCollision(13,14);
        Physics2D.IgnoreLayerCollision(15,14);
        dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
	}
	
	// Update is called once per framew
	void Update () 
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * speed * Time.deltaTime);
        travelTime += Time.deltaTime;
        if (travelTime > travelTimeMax)
        {
            Destroy(gameObject);
        }
	}
}
