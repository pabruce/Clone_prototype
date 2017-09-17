using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour 
{
	public float speed = 1.0f;

	void OnTriggerStay2D(Collider2D col)
	{
		Rigidbody2D rig;

		rig = col.gameObject.GetComponent<Rigidbody2D> ();

		rig.AddForce (Vector3.right * speed * Time.deltaTime);
		print ("SHIT WORKS");
	}



}
