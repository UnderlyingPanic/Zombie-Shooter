using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour {

    
    [HideInInspector]
    public float currentHealthPoints= 100f;
    public float healthAsPercentage
    {
        get { return currentHealthPoints / (float)maxHealthPoints; }
    }
    private Bloodsplat bloodSplat;
    private Animator gunAnimator;
    private float secondsPerBullet;
    private StatManager statManager;
    private FirstPersonController fpsController;

    public GameObject doorText;
    public AudioClip gunShotSound;
    public float maxHealthPoints = 100f;
    public float bulletDamage;
    public float fireRate; // Shots per Second
    public float bulletSpread;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6f;
    public GameObject gameCanvas;
    public GameObject deadText;
    public bool isDead;
    public Transform muzzleFlashSpawn;
    public GameObject muzzleFlashObject;
    [HideInInspector]public bool endGame = false;


    // Use this for initialization
    void Start () {
        statManager = FindObjectOfType<StatManager>();
        bloodSplat = GetComponentInChildren<Bloodsplat>();
        gunAnimator = GetComponentInChildren<Animator>();
        fpsController = GetComponent<FirstPersonController>();
        isDead = false;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        print(endGame);
        secondsPerBullet = 1 / fireRate;

        if (Input.GetMouseButtonDown(0))
        {
            InvokeRepeating("Fire", 0.0001f, secondsPerBullet);
        }
        if (Input.GetMouseButtonUp(0))
        {
            CancelInvoke();
        }

        if (currentHealthPoints < 0)
        {
            PlayDead();
        }

        if (isDead)
        {
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
	}

    public void TakeDamage(float damage)
    {
        currentHealthPoints -= damage;
        bloodSplat.SpawnBloodsplat();
    }

    public void Fire()
    {
        AudioSource audioSource;
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource aud in audioSources)
        {
            if (aud.priority == 1)
            {
                audioSource = aud;
                audioSource.clip = gunShotSound;
                audioSource.Play();
            }
        }

        Vector3 bulletSpreadVector = RandomiseBulletSpread(bulletSpread); // Calls the Randomise function to return a new vector

        gunAnimator.SetTrigger("Trigger Shoot");
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;

        Vector3 randomisedSpreadVector = Camera.main.transform.forward + bulletSpreadVector; // mods the starting point of travel by the spread vector above
        
        bullet.GetComponent<Rigidbody>().velocity = randomisedSpreadVector * bulletSpeed; // Fire Bullet
        Destroy(bullet, 2.0f);
        var muzzleFlash = Instantiate(muzzleFlashObject, this.muzzleFlashSpawn.position, muzzleFlashSpawn.rotation) as GameObject;
        muzzleFlash.transform.parent = Camera.main.transform;
        Destroy(muzzleFlash, 1f);
    }

    private Vector3 RandomiseBulletSpread (float maxSpread)
    {
        float xVector = Random.Range (-maxSpread, maxSpread);
        float yVector = Random.Range(-maxSpread, maxSpread);
        float ZVector = Random.Range(-maxSpread, maxSpread);

        return new Vector3(xVector, yVector, ZVector);
    }

    public void PlayDead()
    {
        isDead = true;
        currentHealthPoints = 0;
        Time.timeScale = 0;
        deadText.SetActive(true);
    }

    public void PassStatsToStatManager ()
    {
        statManager.currentHealthPoints = currentHealthPoints;
        statManager.maxHealthPoints = maxHealthPoints;
        statManager.bulletDamage = bulletDamage;
        statManager.fireRate = fireRate;
        statManager.bulletSpread = bulletSpread;
        statManager.walkSpeed = fpsController.m_WalkSpeed;
        statManager.runSpeed = fpsController.m_RunSpeed;
        statManager.jumpSpeed = fpsController.m_JumpSpeed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (endGame)
        {
            Door door = collision.gameObject.GetComponent<Door>();
            if (door)
            {
                print("Touching door");
                doorText.SetActive(true);
                door.DisplayText();

                if (Input.GetKey(KeyCode.E))
                {
                    door.OpenDoor();
                }
            } else
            {
                print("Not touching door");
                doorText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        doorText.SetActive(false);
    } 
}
