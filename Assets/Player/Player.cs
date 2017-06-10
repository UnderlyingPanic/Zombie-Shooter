using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private float maxHealthPoints =100f;
    private float currentHealthPoints= 100f;
    public float healthAsPercentage
    {
        get { return currentHealthPoints / (float)maxHealthPoints; }
    }
    private Bloodsplat bloodSplat;
    private Animator gunAnimator;
    private float secondsPerBullet;

    public float fireRate; // Shots per Second
    public float bulletSpread;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6f;
    public GameObject gameCanvas;
    public GameObject deadText;
    public bool isDead;

    
    
   
    // Use this for initialization
    void Start () {
        bloodSplat = GetComponentInChildren<Bloodsplat>();
        gunAnimator = GetComponentInChildren<Animator>();
        isDead = false;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {

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

        Vector3 bulletSpreadVector = RandomiseBulletSpread(bulletSpread); // Calls the Randomise function to return a new vector

        gunAnimator.SetTrigger("Trigger Shoot");
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;

        Vector3 randomisedSpreadVector = Camera.main.transform.forward + bulletSpreadVector; // mods the starting point of travel by the spread vector above
        
        bullet.GetComponent<Rigidbody>().velocity = randomisedSpreadVector * bulletSpeed; // Fire Bullet
        Destroy(bullet, 2.0f);
    }

    private Vector3 RandomiseBulletSpread (float maxSpread)
    {
        float xVector = Random.Range (-maxSpread, maxSpread);
        float yVector = Random.Range(-maxSpread, maxSpread);
        float ZVector = Random.Range(-maxSpread, maxSpread);

        return new Vector3(xVector, yVector, ZVector);


        throw new UnityException("RandomiseBulletSpread didn't manage to return a vector");
    }

    public void PlayDead()
    {
        isDead = true;
        currentHealthPoints = 0;
        Time.timeScale = 0;
        deadText.SetActive(true);
    }
}
