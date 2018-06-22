using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOptimize : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject player = GameObject.Find("Player(Clone)");
        Transform tire = player.transform.GetChild(0);
        float difference = tire.transform.position.z - gameObject.transform.position.z;

        if (difference > 100)
        {
            if (gameObject.tag == "BloodSplatter")
            {
                BloodSaver.AddSplatter(gameObject.transform.position);
            }
            Destroy(gameObject);
        }
	}
}
