using UnityEngine;
using System.Collections;

public class BearFUShotRange : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<BearFU>().shootRange = true;    
        }
    }
    void OnTriggerExit2D(Collider2D other)
    { 
        if (other.gameObject.tag == "Player")
        {
            transform.parent.GetComponent<BearFU>().shootRange = false;    
        }
    }
}
