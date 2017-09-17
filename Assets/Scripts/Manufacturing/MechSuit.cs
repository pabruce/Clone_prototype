using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechSuit : MonoBehaviour
{
	void OnTriggerStay2D()
	{

		GameObject character = GameObject.FindGameObjectWithTag ("Player");
		Player playerScript = character.GetComponent<Player> ();

		playerScript.MechActive = true;
	}

}
