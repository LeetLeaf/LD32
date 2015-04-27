using UnityEngine;
using System.Collections;

public class ArmScript : MonoBehaviour 
{
    public Vector3 mousePos;
    public Vector3 objPos;
    public float angle;
    public GameObject start;
    public GameObject end;
    public Vector3 lastPos;
    public Vector3 currentPos;
    public float distance;
    public int dirLeftorRight;
    public int dirUporDown;
    public Vector2 diskVelocity;
    public int spinDirection;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        lastPos = end.transform.position;


        mousePos = Input.mousePosition;
        mousePos = new Vector3(mousePos.x, mousePos.y, 1);
        objPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = new Vector3(mousePos.x - objPos.x, mousePos.y - objPos.y, mousePos.z);
        angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90.0f));

        currentPos = end.transform.position;
        distance = Vector3.Distance(lastPos, currentPos);
        diskVelocity = new Vector2();
        if (lastPos.x > currentPos.x)
        {
            dirLeftorRight = -1;
        }
        else
        {
            dirLeftorRight = 1;
        }
        if (lastPos.y > currentPos.y)
        {
            dirUporDown = -1;
        }
        else
        {
            dirUporDown = 1;
        }
        diskVelocity = new  Vector2(dirLeftorRight*distance,dirUporDown*distance);

        if (distance > 0.2f)
        {
            spinDirection = dirLeftorRight;
        }
        JointMotor2D motor = gameObject.GetComponent<HingeJoint2D>().motor;
        motor.motorSpeed = 800 * spinDirection;
        
        gameObject.GetComponent<HingeJoint2D>().motor = motor;
        if (Input.GetMouseButton(1))
        {
            gameObject.GetComponent<HingeJoint2D>().useMotor = true;
        }
        else
        {
            gameObject.GetComponent<HingeJoint2D>().useMotor = false;
        }

        /*
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        end.transform.position = new Vector3(mousePos.x,mousePos.y,0);
        start.transform.LookAt(end.transform.position);
        //start.transform.rotation = new Quaternion(start.transform.rotation.x, 0, start.transform.rotation.z+0.5f, start.transform.rotation.w);
        gameObject.transform.rotation = start.transform.rotation;
        Debug.Log("START:  "+start.transform.rotation);
        Debug.Log("ARM:   "+gameObject.transform.rotation);
        */
        
        //rotation = new Quaternion(0, 0, rotation.y, rotation.w);
        //transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime * 100000);
	}
}
