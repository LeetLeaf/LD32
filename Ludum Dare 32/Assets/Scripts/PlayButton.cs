using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	}
    void OnMouseDown()
    {
        if (Application.loadedLevel == 2)
        {
            Application.LoadLevel(0);
        }
        else
        {
            Application.LoadLevel(1); 
        }
    }
}
