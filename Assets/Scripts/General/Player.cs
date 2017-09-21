using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : Controller
{
	[SerializeField]
	private int playerNumber = 1;

	public bool MechActive = false;

	/* Instance Vars */

	/*
	[SerializeField]
	private KeyCode key_up;
	[SerializeField]
	private KeyCode key_left;
	[SerializeField]
	private KeyCode key_down;
	[SerializeField]
	private KeyCode key_right;
	*/
	[SerializeField]
	private KeyCode use_ability;
	/*
	[SerializeField]
	private string abilityName;
	*/

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

	public bool canMove = true;

	/* Instance Methods */
	public override void Awake ()
	{
		canMove = true;
		base.Awake ();
		setState (new BehaviorState("prime", this.updatePrime, this.fixedUpdatePrime, this.lateUpdatePrime));

		direction = Vector2.zero;
	}

	// Inject some test data into self
	public void Start()
	{
		
	}

	private void updatePrime()
	{
		if (subjectCamera == null)
			return;

		lenseCooldown -= Time.deltaTime;
		lenseResetTimer -= Time.deltaTime;
		if (lenseResetTimer <= 0f && lenseActive)
		{
			toggleLenseView ();
			lenseActive = false;
			lenseStatusInd.color = Color.red;
			lenseCooldown = lenseCooldownMax;
		}
		if (Input.GetKeyDown (use_ability) && subjectCamera != null && !lenseActive && lenseCooldown <= 0f)
		{
			toggleLenseView ();
			lenseResetTimer = lenseResetTimerMax;
			lenseActive = true;
			lenseStatusInd.color = Color.green;
		}

		if (lenseActive)
			lenseStatusInd.fillAmount = lenseResetTimer / lenseResetTimerMax;
		else
		{
			float perc = lenseCooldown / lenseCooldownMax;
			lenseStatusInd.fillAmount = perc > 0f ? perc : 0f;
		}
	}

	private void toggleLenseView()
	{
		int mask = subjectCamera.cullingMask;
		if ((mask & 1 << 10) != 0)
			subjectCamera.cullingMask = mask & ~(1 << 10);
		else
			subjectCamera.cullingMask = mask | 1 << 10;
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
