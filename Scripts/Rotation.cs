using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public int RotationSpeed;

	void Start ()
    {
		
	}
	
	void FixedUpdate ()
    {
        gameObject.transform.rotation *= Quaternion.AngleAxis(RotationSpeed * Time.deltaTime, Vector3.right);
    }
}
