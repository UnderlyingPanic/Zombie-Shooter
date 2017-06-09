using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodsplat : MonoBehaviour {

    public GameObject bloodsplat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnBloodsplat ()
    {
        Instantiate(bloodsplat, transform.position, Quaternion.identity);
    }
}
