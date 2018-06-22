using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHeightGenerator : MonoBehaviour {

    // Use this for initialization
    void Start () {
        for(int i = 0; i < 9; i++)
        {
			GameObject building = transform.Find("building_" + (i+1)).gameObject;
            Vector3 size = new Vector3(building.transform.localScale.x, Random.Range(30.0f, 200.0f), building.transform.localScale.z);
            building.transform.localScale = size;
        } 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
