using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    // Public Variables
    public int Seconds;

	void Start ()
    {
        Destroy(this.gameObject, Seconds);
	}
	
	void Update ()
    {
		
	}
}
