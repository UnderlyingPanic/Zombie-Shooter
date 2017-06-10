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
        GameObject splat = Instantiate(bloodsplat, transform.position, Quaternion.identity) as GameObject;

        Destroy(splat.gameObject, 2.0f);
    }
}
