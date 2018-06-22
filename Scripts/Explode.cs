using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Public Variables
    public GameObject BloodParticle;
    public GameObject BloodSplatter;
    public int NumberOfParticles; 

	void Start ()
    {
		
	}
	
	void Update ()
    {
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject); // Destroy the object 

            for (int i = 0; i < NumberOfParticles; i++)
            {
                Instantiate(BloodParticle, gameObject.transform.position, Quaternion.identity); // Spawn all explosion particles
            }

            if (gameObject.tag == "Person")
            {
				PlayerController.kills++;
				PlayerPrefs.SetInt("Kills", PlayerController.kills);

                // Blood splatter
                Vector3 position = gameObject.transform.position;
                position.y += 0.1f;
                Instantiate(BloodSplatter, position, BloodSplatter.transform.rotation);
            }
        }
    }
}
