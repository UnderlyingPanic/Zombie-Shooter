﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorekeeper : MonoBehaviour {
    [HideInInspector]
    public int timesDodged=0;
    [HideInInspector]
    public int zombiesKilled =0;
    public Text killedText;
    public Text youKilledXZombies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        killedText.text = zombiesKilled.ToString();
        youKilledXZombies.text = "You Killed " + zombiesKilled.ToString() + " Zombies.";
	}
}
