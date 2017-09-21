using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechSuit_V2 : MonoBehaviour {

	public GameObject character;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player"))
			character = col.gameObject;
		else
			return;
		Itemgrabber grabber = character.GetComponent<Itemgrabber> ();

		grabber.SuitToGrab = this;

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Player"))
			character = col.gameObject;
		else
			return;
		Itemgrabber grabber = character.GetComponent<Itemgrabber> ();

		grabber.SuitToGrab = null;
	}
}
