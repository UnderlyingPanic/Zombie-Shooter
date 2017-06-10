using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class Zombie : MonoBehaviour
    {

    public float maxHP;
    public float damage;
    public float bigDamageMultiplier;
    public float attackRange = 0f;

    private float currentHP;
    private Animator animator;
    private Player player;
    private float distanceToPlayer;
    private ThirdPersonCharacter character;
    private AICharacterControl AIControl;
    private Scorekeeper scorekeeper;

       


    // Use this for initialization
    void Start()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        character = GetComponent<ThirdPersonCharacter>();
        AIControl = GetComponent<AICharacterControl>();
        player = GameObject.FindObjectOfType<Player>();
        scorekeeper = FindObjectOfType<Scorekeeper>();
            
    }

    // Update is called once per frame
    void Update()
    {

        distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            if (AIControl.attacking == false)
            {
                animator.SetTrigger("Trigger Attack");
            }
        }

        if (currentHP < 0)
        {
            //TODO death animation / bloodsplat or something
            Destroy(gameObject);
        }

    }
    public void DealDamage()
    {
        if (distanceToPlayer <= attackRange)
        {
            player.TakeDamage(damage);
        }
        else
        {
            scorekeeper.timesDodged++;
        }

    }
    public void DealBigDamage()
    {
        if (distanceToPlayer <= attackRange)
        {
            player.TakeDamage(damage * bigDamageMultiplier);
        }
        else
        {
            scorekeeper.timesDodged++;
        }

    }

    public void TakeDamage (float damage)
    {
        currentHP -= damage;
    }
}
