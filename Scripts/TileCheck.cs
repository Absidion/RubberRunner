using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCheck : MonoBehaviour {

	void Start ()
    {
        BloodSaver.InitialSpawn();
	}
	
	void Update ()
    {
        BloodSaver.CheckForTile();
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Tile")
        {
            if (BloodSaver.GetLastCollidedTile() != collision.gameObject)
            {
                BloodSaver.SetLastCollidedTile(collision.gameObject);
                BloodSaver.IncrementTile();
            }
        }
    }
}
