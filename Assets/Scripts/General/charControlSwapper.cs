using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControlSwapper : MonoBehaviour 
{
	[SerializeField]
	public Player curPlayer1;
	public Player curPlayer2;

	public GameObject player1Camera;
	public GameObject player2Camera;
	public GameObject defaultCamera;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			Debug.Log ("Player 1 Active");
			curPlayer1.playerNumber = 1;
			curPlayer1.enabled = true;
			curPlayer2.enabled = false;

			Debug.Log("Player 2 Abilities Activated");
			curPlayer2.GetComponentInChildren<GrappleHook> ().enabled = false;
			curPlayer2.GetComponent<SwitchInteraction> ().enabled = false;
			curPlayer2.GetComponent<Itemgrabber> ().enabled = false;

			Debug.Log ("ReEnable Abilities on player 1");
			curPlayer1.GetComponent<Chameleon> ().enabled = true;
			curPlayer1.GetComponentInChildren<GrappleHook> ().enabled = true;
			curPlayer1.GetComponent<SwitchInteraction> ().enabled = true;
			curPlayer1.GetComponent<Itemgrabber> ().enabled = true;

			//swap to cam 1
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			Debug.Log ("Player 2 Active");
			curPlayer2.playerNumber = 2;
			curPlayer1.enabled = false;
			curPlayer2.enabled = true;
			if (curPlayer2.enabled = true) 
			{
				curPlayer2.playerNumber = 1;
			}

			Debug.Log ("Player 2 Abilities Activated");
			//Re-Enable Abilities on player 2
			curPlayer2.GetComponentInChildren<GrappleHook> ().enabled = true;
			curPlayer2.GetComponent<SwitchInteraction> ().enabled = true;
			curPlayer2.GetComponent<Itemgrabber> ().enabled = true;

			Debug.Log ("Player 1 Abilities Deactivated");
			//disable Abilities on player 1
			curPlayer1.GetComponent<Chameleon> ().enabled = false;
			curPlayer1.GetComponentInChildren<GrappleHook> ().enabled = false;
			curPlayer1.GetComponent<SwitchInteraction> ().enabled = false;
			curPlayer1.GetComponent<Itemgrabber> ().enabled = false;

			//swap to cam 2 
		}
	}
}
