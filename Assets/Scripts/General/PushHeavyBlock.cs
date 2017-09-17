using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushHeavyBlock : MonoBehaviour 
{

	void OnTriggerEnter2D(Collider2D col)
	{
		GameObject character = GameObject.FindGameObjectWithTag ("Player");
		Player playerScript = character.GetComponent<Player> ();

		if (playerScript.MechActive == true) 
		{
			GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Static;
	}
}
		