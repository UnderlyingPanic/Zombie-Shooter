using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public GameObject upgradeTextGameObject;
    public int minZombiesNeededForMod=1;
    public int maxZombiesNeededForMod=5;
    public int ZombiesNeededToStopSpawning;
    public int maxZombiesAllowed;
    public int minZombieSpawnTime;
    public int maxZombieSpawnTime;
    public GameObject doors;
    public GameObject arrow;

    private int zombiesNeededForMod;
    private Zombie[] zombies;
    private float upgradeTime;

    private bool spawningZombies;
    private Scorekeeper scoreKeeper;
    private StatModifier statMod;
    

	// Use this for initialization
	void Start () {
        scoreKeeper = FindObjectOfType<Scorekeeper>();
        zombies = FindObjectsOfType<Zombie>();
        zombiesNeededForMod = Random.Range(minZombiesNeededForMod, maxZombiesNeededForMod);
        statMod = FindObjectOfType<StatModifier>();
        spawningZombies = true;       
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= upgradeTime+4 && upgradeTextGameObject.activeSelf) // THE NUMBER HERE TELLS US HOW LONG TO LEAVE THE MESSAGE UP
        {
            upgradeTextGameObject.SetActive(false);
        } else
        {

        }
	}

    public void UpdateZombieArray()
    {
        zombies = FindObjectsOfType<Zombie>();
    }

    public int CountZombies()
    {
        UpdateZombieArray();
        return zombies.Length-1;
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

        if (scoreKeeper.zombiesKilled >= ZombiesNeededToStopSpawning && spawningZombies == true)
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(false);
                spawningZombies = false;
                Debug.Log("Stopping Zombie Spawn");
            }
        }

        int zombiesLeft = CountZombies();
        print(zombiesLeft);
        if (zombiesLeft <= 0 && spawningZombies == false)
        {
            doors.SetActive(true);
            arrow.SetActive(true);
            TellPlayerGameHasEnded();
            FindObjectOfType<Player>().PassStatsToStatManager();
        }
    }

    public void RecieveModification ()
    {
        upgradeTextGameObject.SetActive(true);
        upgradeTime = Time.time;
        statMod.ModifyRandomStat();
    }

    public void TellPlayerGameHasEnded()
    {
        print("GameManager: Telling player that the game has ended!");
        Player player = FindObjectOfType<Player>();
        player.endGame = true;
    }
}
