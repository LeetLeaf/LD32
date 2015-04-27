using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour 
{
    public Sprite[] parts = new Sprite[4];
    public GameObject piece;

    public float explosionTime;
    public float nextStep;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        explosionTime += Time.deltaTime;
        transform.Rotate(Vector3.forward,180*Time.deltaTime);
        for (int i = 0; i < 4;i++)
        {
            if (explosionTime > nextStep * i)
            {
                GetComponent<SpriteRenderer>().sprite = parts[i];
            }
        }
        if (explosionTime > nextStep * 5)
        {
            Destroy(gameObject);
        }
	}
}
