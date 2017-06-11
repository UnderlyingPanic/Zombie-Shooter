using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public GameObject upgradeTextGameObject;
    public int minZombiesNeededForMod=1;
    public int maxZombiesNeededForMod=5;
    
    private int zombiesNeededForMod;
    private Zombie[] zombies;
    private float upgradeTime;

    private Scorekeeper scoreKeeper;
    private StatModifier statMod;

	// Use this for initialization
	void Start () {
        scoreKeeper = FindObjectOfType<Scorekeeper>();
        zombies = FindObjectsOfType<Zombie>();
        zombiesNeededForMod = Random.Range(minZombiesNeededForMod, maxZombiesNeededForMod);
        statMod = FindObjectOfType<StatModifier>();
       
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= upgradeTime+4 && upgradeTextGameObject.activeSelf)
        {
            upgradeTextGameObject.SetActive(false);
        }
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

    public void ZombieKilled()
    {
        UpdateZombieArray();
        if (scoreKeeper.zombiesKilled >= zombiesNeededForMod)
        {
            RecieveModification();
            zombiesNeededForMod = zombiesNeededForMod + Random.Range(minZombiesNeededForMod, maxZombiesNeededForMod);
        }
    }

    public void RecieveModification ()
    {
        upgradeTextGameObject.SetActive(true);
        upgradeTime = Time.time;
        statMod.ModifyRandomStat();
    }
}
