using UnityEngine;
using System.Collections;

public class FloppyDisk : MonoBehaviour 
{
    public Vector3 dest;
    public float speed;
    public static float travelTimeMax = 1.0f;
    public float travelTime = 0;
	// Use this for initializationa
	void Start () 
    {
        dest = Input.mousePosition;
        dest = Camera.main.ScreenToWorldPoint(dest);
        Physics2D.IgnoreLayerCollision(12,11);
        Physics2D.IgnoreLayerCollision(11,8);
        Physics2D.IgnoreLayerCollision(11, 10);
        Physics2D.IgnoreLayerCollision(13,11);
        Physics2D.IgnoreLayerCollision(11, 15);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //DONT FORGET TO FIX THE SPEED OF THE DISK WHEN MOVING TOWARDS THE MOUSE CLOSE TO THE CHARACTER!!!!!!!!!!!!!!
        //
        //                           o               o
        //                          OOO             OOO
        ///                          o               o
        ////
        ///                          \               /
        //                            \_____________/

        //gameObject.transform.position= Vector3.MoveTowards(gameObject.transform.position,dest,speed*Time.deltaTime);
        GetComponent<Rigidbody2D>().AddForce(transform.up * -speed * Time.deltaTime);
        travelTime+=Time.deltaTime;
        if(travelTime > travelTimeMax)
        {
            Destroy(gameObject);
        }
	}
}
