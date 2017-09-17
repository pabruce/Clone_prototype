using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocity : MonoBehaviour {

	public Vector3 velocity;

	Rigidbody2D rigBod;

	// Use this for initialization
	void Start () {
		rigBod = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		velocity = rigBod.velocity;
	}
}
