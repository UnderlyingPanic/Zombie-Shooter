using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float minSpawnTime=0f;
    public float maxSpawnTime=10f;
    public int maxZombies;
    public float nextSpawnTime;

    public GameObject[] Zombies;
    private GameManager gameManager;

    // Use this for initialization
	void Start () {
        nextSpawnTime = Time.time + RandomiseSpawnTime();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + RandomiseSpawnTime();
            if (gameManager.CountZombies() < maxZombies)
            {
                SpawnZombie();
            } else
            {
                // DO NOTHING.
            }
            
        }
	}

    public void SpawnZombie ()
    {
        int i = Random.Range(0, Zombies.Length);
        GameObject zombie = Zombies[i];
        // GameObject newZombie = Instantiate(zombie, transform.position, Quaternion.identity) as GameObject; //Commented out for now, as no need to catch new zombie as variable yet
        Instantiate(zombie, transform.position, Quaternion.identity);
    }

    public float RandomiseSpawnTime ()
    {
        float randomisedSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        return randomisedSpawnTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + new Vector3 (0,5,0), new Vector3 (10,10,10));
    }
}
