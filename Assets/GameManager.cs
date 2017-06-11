using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public float speedIncreaseMultiplier;
    public Text upgradeText;

    private Zombie[] zombies;

	// Use this for initialization
	void Start () {
        zombies = FindObjectsOfType<Zombie>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UpdateZombieArray()
    {
        zombies = FindObjectsOfType<Zombie>();
    }

    public int CountZombies()
    {
        UpdateZombieArray();
        return zombies.Length;
    }


    public void UpdateAISpeed(float multiplier)
    {
        UpdateZombieArray();

        foreach (Zombie zombie in zombies)
        {
            zombie.GetComponent<UnityEngine.AI.NavMeshAgent>().speed *= multiplier;
        }
    }
}
