using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StatModifier : MonoBehaviour {

    public Text upgradeText;
    public float bulletDamage = 5;

    private GameManager gameManager; //Zombie Speed is changed here
    private Player player;
    private FirstPersonController playerController;

    //PlayerController
    //walkSpeed;
    //runSpeed;
    //jumpSpeed;

    //Player
    //fireRate;
    //bulletSpread;
    //maxHealthPoints;
    //currentHealthPoints;

    //Zombie
    //zombieSpeedMultiplier;
    // Zombie Damage
    //Zombie HP
    
    // Use this for initialization
	void Start () {
        gameManager = GetComponent<GameManager>();
        player = FindObjectOfType<Player>();
        playerController = FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void ModifyRandomStat ()
    {
        int statNumber = Random.Range(1, 13); // THIS WILL NEED TO BE AMMENDED TO REFLECT LIST
        int reroll = Random.Range (0,3);
        print("We've rolled " + reroll);

        switch (statNumber)
        {
            case 1:
                //Increase Walkspeed & RunSpeed by random amount
                float amount = Random.Range(0.1f, 3);
                playerController.m_WalkSpeed += amount;
                playerController.m_RunSpeed += amount;
                upgradeText.text = "You feel faster.";
                break;
            case 2:

                if (reroll == 1)
                {
                    ModifyRandomStat();
                    break;
                }
                else
                {
                    amount = Random.Range(0.1f, 3);
                    playerController.m_WalkSpeed -= amount;
                    playerController.m_RunSpeed -= amount;
                    upgradeText.text = "You feel tired and less agile.";
                    break;
                }
            case 3:
                amount = Random.Range(0, 2);
                bulletDamage += amount;
                upgradeText.text = "Your Damage has Increased.";
                break;
            case 4:

                if (reroll == 1)
                {
                    ModifyRandomStat();
                    break;
                }
                else
                {
                    amount = Random.Range(0, 1);
                    bulletDamage -= amount;
                    upgradeText.text = "Your Damage has Decreased.";
                    break;
                }

            case 5:
                amount = Random.Range(0.1f, 3);
                playerController.m_JumpSpeed += amount;
                upgradeText.text = "Your jump height has increased.";
                break;
            case 6:
                if (reroll == 1)
                {
                    ModifyRandomStat();
                    break;
                }
                else
                {
                    amount = Random.Range(0.1f, 3);
                    playerController.m_JumpSpeed -= amount;
                    upgradeText.text = "Your jump strength has weakened.";
                    break;
                }
        
            case 7:
                amount = Random.Range(0.1f, 3);
                player.fireRate += amount;
                upgradeText.text = "Your Fire Rate has Increased.";
                break;
            case 8:
                if (reroll == 1)
                {
                    ModifyRandomStat();
                    break;
                }
                else
                {
                    amount = Random.Range(0.1f, 3);
                    player.fireRate -= amount;
                    upgradeText.text = "Your weapon is degrading.";
                    break;
                }
            case 9:
                if (reroll == 1)
                {
                    ModifyRandomStat();
                    break;
                }
                else
                {
                    amount = Random.Range(0.001f, 0.005f);
                    player.bulletSpread += amount;
                    upgradeText.text = "You feel tired. Your aim has worsened.";
                    break;
                }
            case 10:
                amount = Random.Range(0.001f, 0.005f);
                if (player.bulletSpread <= 0)
                {
                    player.bulletSpread = 0;
                    Debug.Log("Aim is already perfect, rerolling");
                    ModifyRandomStat();
                }
                else
                {
                    player.bulletSpread -= amount;
                    upgradeText.text = "Adrenaline courses through your veins. Your aim improves.";
                }
                break;
            case 11:
                amount = Random.Range(20, 50);
                player.maxHealthPoints += amount;
                player.currentHealthPoints = player.maxHealthPoints;
                upgradeText.text = "You patch up your wounds, and your max HP increases.";
                break;
            case 12:
                if (reroll == 1)
                {
                    ModifyRandomStat();
                    break;
                }
                else
                {
                    amount = Random.Range(5, 15);
                    if (player.maxHealthPoints >= 40)
                    {
                        player.maxHealthPoints -= amount;
                        player.currentHealthPoints = player.maxHealthPoints;
                        upgradeText.text = "You patch up your wounds, but your max HP has decreased.";
                    }
                    else
                    {
                        Debug.Log("HP is too low, rerolling");
                        ModifyRandomStat();
                    }
                }
                break;
            case 13:
                float hpMissing = player.maxHealthPoints - player.currentHealthPoints;
                amount = Random.Range(0, hpMissing);
                player.currentHealthPoints = amount;
                upgradeText.text = "You recover some Health.";
                break;

            // Add in all the nice ones again so it's harder to get a bad roll
        }
    }
}
