using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class StatManager : MonoBehaviour {

    //Player
    [HideInInspector]
    public float maxHealthPoints;
    [HideInInspector]
    public float currentHealthPoints;
    [HideInInspector]
    public float bulletDamage;
    [HideInInspector]
    public float fireRate;
    [HideInInspector]
    public float bulletSpread;

    //FPS Controller
    [HideInInspector]
    public float walkSpeed;
    [HideInInspector]
    public float runSpeed;
    [HideInInspector]
    public float jumpSpeed;

    private Player player;
    private FirstPersonController fpsController;


    // Use this for initialization
    void Start () {
        player = FindObjectOfType<Player>();
        fpsController = FindObjectOfType<FirstPersonController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KickOutStats ()
    {
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
