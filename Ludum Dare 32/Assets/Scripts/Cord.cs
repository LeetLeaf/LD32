using UnityEngine;
using System.Collections;

public class Cord : MonoBehaviour 
{
    public GameObject start;
    public GameObject end;
    public GameObject connectPoint;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.rotation = new Quaternion(0, 0, transform.rotation.z, transform.rotation.w);
	}
}
