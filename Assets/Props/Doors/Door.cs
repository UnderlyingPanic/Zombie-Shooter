using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour {

    public Text doorText;
    public string textToDisplay;
    public int levelToLoad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenDoor()
    {
        print("Door Opened");
        SceneManager.LoadScene(levelToLoad);
    }

    public void DisplayText()
    {
        doorText.text = textToDisplay;
    }
}
