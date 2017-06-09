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

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 6f;

    // Use this for initialization
    void Start () {
        bloodSplat = GetComponentInChildren<Bloodsplat>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
            
        
	}

    public void TakeDamage(float damage)
    {
        currentHealthPoints -= damage;
        bloodSplat.SpawnBloodsplat();
    }

    public void Fire()
    {
        
       var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
       bullet.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * bulletSpeed;

      Destroy(bullet, 2.0f);
    }
}
