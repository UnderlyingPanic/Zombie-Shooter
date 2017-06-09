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
    public Bloodsplat bloodSplat;

    // Use this for initialization
    void Start () {
        bloodSplat = GetComponentInChildren<Bloodsplat>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void TakeDamage(float damage)
    {
        currentHealthPoints -= damage;
        bloodSplat.SpawnBloodsplat();
    }
}
