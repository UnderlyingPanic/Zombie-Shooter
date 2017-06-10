using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private float maxHealthPoints =100f;
    private float currentHealthPoints= 100f;
    public float healthAsPercentage
    {
        get { return currentHealthPoints / (float)maxHealthPoints; }
    }
    private Bloodsplat bloodSplat;
    private Animator gunAnimator;
    private bool allowFire;

    public float fireRate; // Shots per Second

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6f;

    private float secondsPerBullet;

    // Use this for initialization
    void Start () {
        bloodSplat = GetComponentInChildren<Bloodsplat>();
        gunAnimator = GetComponentInChildren<Animator>();
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
	}

    public void TakeDamage(float damage)
    {
        currentHealthPoints -= damage;
        bloodSplat.SpawnBloodsplat();
    }

    public void Fire()
    {
        gunAnimator.SetTrigger("Trigger Shoot");
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;
        Destroy(bullet, 2.0f);
    }
}
