using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Controller
{
	/* Instance Vars */

	[SerializeField]
	private KeyCode key_up;
	[SerializeField]
	private KeyCode key_left;
	[SerializeField]
	private KeyCode key_down;
	[SerializeField]
	private KeyCode key_right;
	[SerializeField]
	private KeyCode use_ability;
	[SerializeField]
	private string abilityName;

	// A list of the states
	private BehaviorState[] states;

	private Vector2 direction;

	[SerializeField]
	private Stat movespeed = new Stat(0, 0);

	// This is a temporary solution for differentiating between player types
	// Eventually, these might be better suited as subclasses of Player
	public enum PlayerType {HACKER, INFIL};
	public PlayerType playerType; 
	public Player otherPlayer; 

	Rigidbody2D rb; 

	// Spinning
	public float spinSpeed; 
	public float throwSpeed; 


	/* Instance Methods */
	public override void Awake ()
	{
		base.Awake ();
		setState (new BehaviorState("prime", this.UpdatePrime, this.FixedUpdatePrime, this.LateUpdatePrime));

		if (GetComponent<Rigidbody2D>() != null)
			rb = GetComponent <Rigidbody2D>(); 


		direction = Vector2.zero;
	}

	// Inject some test data into self
	public void Start()
	{
		//if(abilityName != "")
			//self.addAbility (Ability.get(abilityName));
	}

	private void UpdatePrime()
	{
		//invoke abilities
		//if (Input.GetKey (use_ability)) //TODO swap for proper bindings later
			//useAbility (0, Vector2.zero);

		// Check for spin; Infiltrator throws the hacker
		if (playerType == PlayerType.INFIL && Input.GetKeyDown(KeyCode.Space))
		{
			if (Vector3.Distance(transform.position, otherPlayer.transform.position) < 1.0f)
			{
				// Set behavior states
				setState(new BehaviorState("throwSpin", this.ThrowSpinUpdate)); 

				otherPlayer.transform.SetParent(transform); 
				transform.position = new Vector2 (otherPlayer.transform.position.x, otherPlayer.transform.position.y + 1); 

				// Note: not sure if other player should be called in the parameter instead of this
				otherPlayer.setState(new BehaviorState ("throwWait", otherPlayer.ThrowWaitUpdate)); 
			}
		}

	}

	private void FixedUpdatePrime()
	{
		//movement
		Vector2 movementVector = Vector2.zero;

		bool up = Input.GetKey(key_up); //TODO swap for proper bindings later
		bool left = Input.GetKey(key_left);
		bool down = Input.GetKey(key_down);
		bool right = Input.GetKey(key_right);

		if (up)
			movementVector += Vector2.up;
		if (left)
			movementVector += Vector2.left;
		if (down)
			movementVector += Vector2.down;
		if (right)
			movementVector += Vector2.right;

		physbody.AddForce (movementVector * movespeed.value);

		if (movementVector != Vector2.zero)
			direction = movementVector;
		facePoint (direction + (Vector2)transform.position);
	}

	private void LateUpdatePrime()
	{

	}

	/// <summary>
	/// Infiltrator only: controls while spinning the hacker
	/// </summary>
	private void ThrowSpinUpdate()
	{
		//rb.freezeRotation = false; 
		//rb.AddTorque(spinSpeed * Time.deltaTime, ForceMode2D.Force);  
		transform.Rotate(new Vector3(0, 0, spinSpeed * Time.deltaTime)); 

		if (Input.GetKeyDown(KeyCode.Space))
		{
			otherPlayer.transform.SetParent(GameObject.Find("Players").transform); 
			otherPlayer.rb.AddForce(-transform.right * throwSpeed); 
			otherPlayer.setState(new BehaviorState ("throwMove", otherPlayer.ThrowMoveUpdate)); 

			transform.localRotation = Quaternion.Euler(new Vector3 (0, 0, 0)); 
			setState (new BehaviorState("prime", this.UpdatePrime, this.FixedUpdatePrime, this.LateUpdatePrime));
		}
	}

	/// <summary>
	/// Hacker only: update while being spun by the infiltrator
	/// </summary>
	private void ThrowWaitUpdate()
	{
		

	}

	/// <summary>
	/// Hacker only: update while being thrown
	/// </summary>
	private void ThrowMoveUpdate()
	{
		if (rb.velocity.magnitude < 0.01f)
		{
			transform.localRotation = Quaternion.Euler(new Vector3 (0, 0, 0)); 
			setState (new BehaviorState("prime", this.UpdatePrime, this.FixedUpdatePrime, this.LateUpdatePrime));
		}
	}
}
