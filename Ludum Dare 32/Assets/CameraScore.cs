using UnityEngine;
using System.Collections;

public class CameraScore : MonoBehaviour 
{
    public GUISkin gameGUI;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

	
	}
    void OnGUI()
    {
        if (Application.loadedLevel == 0)
        {
            GUI.Label(new Rect(Screen.width / 2.6f, Screen.height / 1.15f + 2, 100, 100), "TopScore: " + PlayerPrefs.GetInt("topScore"), gameGUI.customStyles[2]);
            GUI.Label(new Rect(Screen.width / 2.6f, Screen.height / 1.15f, 100, 100), "TopScore: " + PlayerPrefs.GetInt("topScore"), gameGUI.customStyles[1]);
        }
        if (Application.loadedLevel == 2)
        {
            GUI.Label(new Rect(Screen.width / 4.6f, Screen.height / 7.0f + 4, 100, 100), "TopScore: " + PlayerPrefs.GetInt("topScore"), gameGUI.customStyles[4]);
            GUI.Label(new Rect(Screen.width / 4.6f, Screen.height / 7.0f, 100, 100), "TopScore: " + PlayerPrefs.GetInt("topScore"), gameGUI.customStyles[3]);
        }
    }
}
