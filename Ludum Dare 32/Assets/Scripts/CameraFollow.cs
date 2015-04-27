using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public GUISkin gameGUI;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            //Debug.Break();
            Application.LoadLevel(2);
            //Debug.Break();
        }
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, -10);
	}
    void OnGUI()
    {
        GUI.Label(new Rect(0,0,100,100),"Kills: "+GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().Score,gameGUI.customStyles[0]);
    }
}
