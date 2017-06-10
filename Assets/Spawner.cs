using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float minSpawnTime=0f;
    public float maxSpawnTime=10f;
    public int maxZombies;
    public float nextSpawnTime;

    public GameObject[] Zombies;
    private Scorekeeper scoreKeeper;

    // Use this for initialization
	void Start () {
        nextSpawnTime = Time.time + RandomiseSpawnTime();
        scoreKeeper = FindObjectOfType<Scorekeeper>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + RandomiseSpawnTime();
            if (scoreKeeper.zombiesInPlay < maxZombies)
            {
                Debug.Log("Spawning zombie");
                SpawnZombie();
            } else
            {
                Debug.Log("Cannot spawn anymore zombies.");
            }
            
        }
	}

    public void SpawnZombie ()
    {
        int i = Random.Range(0, Zombies.Length);
        GameObject zombie = Zombies[i];
        GameObject newZombie = Instantiate(zombie, transform.position, Quaternion.identity);
    }

    public float RandomiseSpawnTime ()
    {
        float randomisedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        return randomisedSpawnTime;
    }
}
