using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour 
{
    public float speed;
    public Vector3 spawnPoint;
    public float timePasted;
    public float spawnTime;
    public GameObject wolf;
    public GameObject bear;
    public GameObject lion;
    public int enemy;
    public int whichPoint;
    public Transform[] MovePoint;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        for (int i = 0; i < MovePoint.Length;i++)
        {
            if (transform.position == MovePoint[i].position)
            {
                whichPoint++;
            }
        }
        if (whichPoint >= MovePoint.Length)
        {
            whichPoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, MovePoint[whichPoint].position, speed * Time.deltaTime);
        timePasted += Time.deltaTime;
        spawnPoint = transform.position;
        if (timePasted > spawnTime)
        {
            enemy = Random.Range(0,9);
            switch (enemy)
            { 
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    Instantiate(wolf, spawnPoint, Quaternion.identity);
                    //enemy++;
                    break;
                case 5:
                case 6:
                    Instantiate(bear, spawnPoint, Quaternion.identity);
                    //enemy++;
                    break;
                case 7:
                case 8:
                case 9:
                    Instantiate(lion, spawnPoint, Quaternion.identity);
                    //enemy = 0;
                    break;
            }
            timePasted = 0;
        }

       
	}
}
