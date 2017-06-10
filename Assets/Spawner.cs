using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float minSpawnTime=0f;
    public float maxSpawnTime=10f;

    public float nextSpawnTime;

    public GameObject zombie;

    // Use this for initialization
	void Start () {
        nextSpawnTime = Time.time + RandomiseSpawnTime();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextSpawnTime)
        {
            SpawnZombie();
            nextSpawnTime = Time.time + RandomiseSpawnTime();
        }
	}

    public void SpawnZombie ()
    {
        GameObject newZombie = Instantiate(zombie, transform.position, Quaternion.identity);
    }

    public float RandomiseSpawnTime ()
    {
        float randomisedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        return randomisedSpawnTime;
    }
}
