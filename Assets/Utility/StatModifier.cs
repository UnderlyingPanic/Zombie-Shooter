using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class StatModifier : MonoBehaviour {

    public Text upgradeText;

    private GameManager gameManager; //Zombie Speed is changed here, as well as upgrade frequency.
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
        //TODO - Make "luck", i,e increase/decrease the random.range for "reroll"
        //Basic process: Roll a random integer between 1 and the number of potential functions/upgrades.
        //               Roll a "Reroll" integer, which allows the negative ones to be rerolled
        //               Match the Integer rolled to the appropriate case. If it is a negative change, we check to see if a "reroll" is allowed.
        //               If the reroll is triggered, the whole code rerolls, INCLUDING the reroll integer.

        //               In theory, the "int reroll" random.range can be widened/shortened to change the odds of landing a reroll. 

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

                if (reroll == 0)
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
                amount = Random.Range(0.1f, 2f);
                player.bulletDamage += amount;
                upgradeText.text = "Your Damage has Increased.";
                break;
            case 4:

                if (reroll == 0)
                {
                    ModifyRandomStat();
                    break;
                }
                else
                {
                    amount = Random.Range(0.1f, 1f);
                    player.bulletDamage -= amount;
                    upgradeText.text = "Your Damage has Decreased.";
                    break;
                }

            case 5:
                amount = Random.Range(0.1f, 3);
                playerController.m_JumpSpeed += amount;
                upgradeText.text = "Your jump height has increased.";
                break;
            case 6:
                if (reroll == 0)
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
                if (reroll == 0)
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
                if (reroll == 0)
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
                if (reroll == 0)
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
                        Debug.Log("We rolled the 'maxHP reduction', but HP is too low - rerolling");
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
        }
    }
}
