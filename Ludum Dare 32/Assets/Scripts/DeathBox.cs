using UnityEngine;
using System.Collections;

public class DeathBox : MonoBehaviour 
{
    public AudioClip deathSound;
    public GameObject explosion;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Player>().Score > PlayerPrefs.GetInt("topScore"))
            {
                PlayerPrefs.SetInt("topScore", other.gameObject.GetComponent<Player>().Score);
            }
            Application.LoadLevel(2);
        }
        else
        {
            Destroy(other.gameObject);
        }
        //GetComponent<AudioSource>().PlayOneShot(deathSound);
        Instantiate(explosion, other.transform.position, other.transform.rotation);
        
        if (other.gameObject.tag != "chair")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Score++;
        }
    }
}
