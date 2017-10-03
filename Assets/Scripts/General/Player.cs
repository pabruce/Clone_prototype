using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Player : Controller
{
	private int numberOfInputs;
	private KeyCode nextButtonNumber;

	/* Instance Vars */

	[SerializeField]
	private KeyCode use_ability;

	// A list of the states
	private BehaviorState[] states;

	private Vector2 direction;

	[SerializeField]
	public Stat movespeed = new Stat(0, 0);

	public bool canMove = true;

	// Clone variables
	[SerializeField]
	private float cloneTimerMax;
	private float cloneTimer;
	private Queue<KeyCode> userInputs;

	private BehaviorState normal;
	private BehaviorState passive;
	private BehaviorState recording;
	private BehaviorState playing;

	private GameObject clone;

	/* Instance Methods */
	public override void Awake ()
	{
		canMove = true;
		base.Awake ();
		normal = new BehaviorState("normal", this.normal_update, this.fupdate, this.lupdate);
		passive = new BehaviorState ("passive", this.passive_update, this.fupdate, this.lupdate);
		recording = new BehaviorState ("recording", this.recording_update, this.fupdate, this.lupdate);
		playing = new BehaviorState ("playing", this.playing_update, this.fupdate, this.lupdate);

		setState (normal);

		direction = Vector2.zero;

		userInputs = new Queue<KeyCode>();
	}

	// Toggle the special view layers off
	public void Start()
	{

	}

	private void normal_update()
	{

	}

	private void passive_update()
	{

	}

	private void recording_update()
	{

	}

	private void playing_update()
	{

	}

	private void fupdate()
	{
		//movement
		Vector2 movementVector = Vector2.zero;

		float horizontal = Input.GetAxis("Horizontal" + 1);
		float vertical = Input.GetAxis("Vertical" + 1);

		movementVector = new Vector2 (horizontal, vertical);

		if(canMove)
			physbody.AddForce (movementVector * movespeed.value);
		else
			physbody.velocity = Vector2.zero;

		if (movementVector != Vector2.zero)
			direction = movementVector;
		facePoint (direction + (Vector2)transform.position);
	}

	private void lupdate()
	{

	}
}
