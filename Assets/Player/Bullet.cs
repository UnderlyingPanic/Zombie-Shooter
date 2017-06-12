using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Bullet : MonoBehaviour {

    private float bulletDamage;
    public GameObject bloodsplat;
    

    //TODO Implement damage reduction over time

	// Use this for initialization
	void Start () {
        bulletDamage = FindObjectOfType<Player>().bulletDamage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter (Collision col)
    {
        Zombie zombie = col.gameObject.GetComponent<Zombie>();

        if (zombie) {

            foreach (ContactPoint contact in col.contacts)
            {
                GameObject splat = Instantiate(bloodsplat, contact.point, Quaternion.identity) as GameObject;
                Destroy(splat, 1f);
            }

            zombie.TakeDamage(bulletDamage);
        }

        Destroy(this.gameObject);
    }
    
}
