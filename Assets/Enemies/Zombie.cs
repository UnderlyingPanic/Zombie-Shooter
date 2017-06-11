using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
    public class Zombie : MonoBehaviour
    {

    public GameObject deathSplat;
    public float maxHP;
    public float damage;
    public float bigDamageMultiplier;
    public float attackRange = 0f;

    private float currentHP;
    private Animator animator;
    private Player player;
    private float distanceToPlayer;
    private AICharacterControl AIControl;
    private Scorekeeper scorekeeper;
    private GameManager gameManager;
    

    // Use this for initialization
    void Start()
    {
        currentHP = maxHP;
        animator = GetComponent<Animator>();
        AIControl = GetComponent<AICharacterControl>();
        player = GameObject.FindObjectOfType<Player>();
        scorekeeper = FindObjectOfType<Scorekeeper>();
        gameManager = FindObjectOfType<GameManager>();
          
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
            Die();
        }

    }

    private void Die()
    {
        scorekeeper.zombiesKilled++;
        Vector3 splatPos = new Vector3(transform.position.x, transform.position.y + transform.lossyScale.y, transform.position.z); // lossyScale.y moves the splat spawn point up
        GameObject splat = Instantiate(deathSplat, splatPos, Quaternion.identity);
        Destroy(splat, 2f);
        gameManager.ZombieKilled();

        Destroy(gameObject);
    }

    public void DealDamage() // called as the zombie hits you
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
    public void DealBigDamage() // called right at the end so getting hit too many times by the same zombie is dangerous
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
