using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StatManager : MonoBehaviour {

    //Player
    
    public float maxHealthPoints;
    
    public float currentHealthPoints;
   
    public float bulletDamage;
   
    public float fireRate;
  
    public float bulletSpread;

    //FPS Controller
  
    public float walkSpeed;
 
    public float runSpeed;
   
    public float jumpSpeed;

    private Player player;
    private FirstPersonController fpsController;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(transform.gameObject);
        player = FindObjectOfType<Player>();
        fpsController = FindObjectOfType<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KickOutStats ()
    {
        player = FindObjectOfType<Player>();
        print("Kicking out Stats to Player");
        player.maxHealthPoints = maxHealthPoints;
        player.currentHealthPoints = currentHealthPoints;
        player.bulletDamage = bulletDamage;
        player.fireRate = fireRate;
        player.bulletSpread = bulletSpread;

        fpsController.m_WalkSpeed = walkSpeed;
        fpsController.m_RunSpeed = runSpeed;
        fpsController.m_JumpSpeed = jumpSpeed;
    }
}
