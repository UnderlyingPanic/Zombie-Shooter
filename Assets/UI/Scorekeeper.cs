using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {

    public int timesDodged=0;
    public int zombiesKilled =0;
    public Text dodge;
    public Text youKilledXZombies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dodge.text = zombiesKilled.ToString();
        youKilledXZombies.text = "You Killed " + zombiesKilled.ToString() + " Zombies.";
	}
}
