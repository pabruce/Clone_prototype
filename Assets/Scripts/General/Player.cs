using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : Controller
{
	/* Instance Vars */

	[SerializeField]
	private int playerNumber = 1;

	public bool MechActive = false;

	[SerializeField]
	private KeyCode use_ability;

	// A list of the states
	private BehaviorState[] states;

	private Vector2 direction;

	[SerializeField]
	public Stat movespeed = new Stat(0, 0);

	//for lense mechanic stuff
	[SerializeField]
	private Camera subjectCamera;
	private float lenseResetTimer;
	[SerializeField]
	private float lenseResetTimerMax = 5f;
	private bool lenseActive = false;
	private float lenseCooldown;
	[SerializeField]
	private float lenseCooldownMax = 3f;
	[SerializeField]
	private Image lenseStatusInd;
	[SerializeField]
	private int playerLayer;

	public bool canMove = true;

	/* Instance Methods */
	public override void Awake ()
	{
		canMove = true;
		base.Awake ();
		setState (new BehaviorState("prime", this.updatePrime, this.fixedUpdatePrime, this.lateUpdatePrime));

		direction = Vector2.zero;
	}

	// Toggle the special view layers off
	public void Start()
	{
		//don't do anyting if we have no camera to modify
		if (subjectCamera == null)
			return;

		//disable the layer on this camera
		int mask = subjectCamera.cullingMask;
		int toggleMask = 0;
		for (int i = 1; i <= 2; i++)
			toggleMask = toggleMask | 1 << LayerMask.NameToLayer ("SpecialWall" + i);
		subjectCamera.cullingMask = mask & ~(toggleMask);
	}

	private void updatePrime()
	{
		//don't do anyting if we have no camera to modify
		if (subjectCamera == null)
			return;

		lenseCooldown -= Time.deltaTime;
		lenseResetTimer -= Time.deltaTime;
		if (lenseResetTimer <= 0f && lenseActive)
		{
			//end the lense and start the cooldown
			toggleLenseView ();
			lenseActive = false;
			lenseStatusInd.color = Color.red;
			lenseCooldown = lenseCooldownMax;
		}
		if (Input.GetKeyDown (use_ability) && subjectCamera != null && !lenseActive && lenseCooldown <= 0f)
		{
			//start the lense and the effect duration timer
			toggleLenseView ();
			lenseResetTimer = lenseResetTimerMax;
			lenseActive = true;
			lenseStatusInd.color = Color.green;
		}
		if (lenseActive) //set fill amount by timer percentage
			lenseStatusInd.fillAmount = lenseResetTimer / lenseResetTimerMax;
		else //set fill amount by cooldown percentage
		{
			float perc = lenseCooldown / lenseCooldownMax;
			lenseStatusInd.fillAmount = perc > 0f ? perc : 0f;
		}
	}

	// Flip the bit in the camera mask that corresponds to this player's special layer
	private void toggleLenseView()
	{
		int mask = subjectCamera.cullingMask;
		int toggleMask = LayerMask.NameToLayer ("SpecialWall" + playerLayer);
		if ((mask & 1 << toggleMask) != 0)
			subjectCamera.cullingMask = mask & ~(1 << toggleMask);
		else
			subjectCamera.cullingMask = mask | 1 << toggleMask;
	}

	private void fixedUpdatePrime()
	{
		//movement
		Vector2 movementVector = Vector2.zero;

		float horizontal = Input.GetAxis("Horizontal" + playerNumber);
		float vertical = Input.GetAxis("Vertical" + playerNumber);

		movementVector = new Vector2 (horizontal, vertical);

		if(canMove)
			physbody.AddForce (movementVector * movespeed.value);
		else
			physbody.velocity = Vector2.zero;
		
		if (movementVector != Vector2.zero)
			direction = movementVector;
		facePoint (direction + (Vector2)transform.position);

	}

	private void lateUpdatePrime()
	{

	}
}
