using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Bullet : MonoBehaviour {

    public float bulletDamage;
    public GameObject bloodsplat;

	// Use this for initialization
	void Start () {
        
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
                Instantiate(bloodsplat, contact.point, Quaternion.identity);
            }

            zombie.TakeDamage(bulletDamage);
        }

        Destroy(this.gameObject);
    }
    
}
