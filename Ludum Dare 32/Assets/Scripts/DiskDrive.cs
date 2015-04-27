using UnityEngine;
using System.Collections;

public class DiskDrive : MonoBehaviour 
{
    public float speed;
    public GameObject PlayerArm;
	// Use this for initialization
	void Start () 
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreLayerCollision(10,9);
        Physics2D.IgnoreLayerCollision(10, 15);
        Physics2D.IgnoreLayerCollision(8,15);

	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.rotation = PlayerArm.transform.rotation;
        if (Input.GetMouseButton(1))
        {
            GetComponent<Rigidbody2D>().AddForce(PlayerArm.GetComponent<ArmScript>().diskVelocity * speed * Time.deltaTime);
            Debug.Log("Add Force");
        }
        else
        {
            GetComponent<Rigidbody2D>().inertia = 0;
        }
	}
}
