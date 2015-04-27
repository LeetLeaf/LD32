using UnityEngine;
using System.Collections;

public class BearFuArm2 : MonoBehaviour 
{

    public Transform Player;
    public Vector3 dir;
    public float angle;
    public bool direction;
    public bool changeDir;
	// Use this for initialization
	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        dir = Player.position - transform.position;
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (!direction)
            transform.rotation = Quaternion.AngleAxis(angle + 90.0f, Vector3.forward);
        else
            transform.rotation = Quaternion.AngleAxis(angle - 90.0f, Vector3.back);
        if (transform.position.x == Player.position.x)
        {

        }
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
                transform.localScale = new Vector3(-1, -1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            changeDir = false;
        }
	}
}
