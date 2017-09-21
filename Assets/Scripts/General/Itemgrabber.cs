using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemgrabber : MonoBehaviour 
{

	public bool hasItem = false;
	public float itemReach = 1.5f;
	public LayerMask itemLayer;
	public KeyCode grabButton;
	public GameObject itemSlot;
	public PushHeavyBlock boxToGrab;
	public PushHeavyBlock boxBeingMoved;
	public MechSuit_V2 SuitToGrab;
	public MechSuit_V2 WornSuit;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ItemGrabber ();
	}

	void ItemGrabber()
	{
		GameObject character = GameObject.FindGameObjectWithTag ("Player");
		Player playerScript = character.GetComponent<Player> ();

		if(Input.GetKeyDown(grabButton))
		{
			Collider2D item = Physics2D.OverlapCircle (transform.position, itemReach, itemLayer);
			if(SuitToGrab != null && WornSuit == null)
			{
				WornSuit = SuitToGrab;
				WornSuit.transform.SetParent (transform);
				WornSuit.transform.localPosition = Vector3.zero;
				WornSuit.GetComponent<BoxCollider2D> ().enabled = false;
				SuitToGrab = null;
				gameObject.GetComponent<Player> ().MechActive = true;
			}
			else if(boxToGrab != null && boxBeingMoved == null)
			{
				boxToGrab.GetComponent<Rigidbody2D> ().simulated = false;
				boxToGrab.transform.SetParent (transform);
				boxBeingMoved = boxToGrab;
			}
			else if(boxBeingMoved != null)
			{
				boxBeingMoved.GetComponent<Rigidbody2D> ().simulated = true;
				boxBeingMoved.transform.SetParent (null);
				boxBeingMoved = null;
			}
			else if(item != null && !hasItem && WornSuit == null)
			{
				item.gameObject.transform.SetParent (itemSlot.transform);
				hasItem = true;
				playerScript.MechActive = true;
				item.gameObject.transform.localPosition = Vector3.zero;
				item.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(WornSuit != null)
			{
				WornSuit.transform.SetParent (null);
				gameObject.GetComponent<Player> ().MechActive = false;
				WornSuit.GetComponent<BoxCollider2D> ().enabled = true;
				WornSuit = null;
			}
			else if(hasItem)
			{
				hasItem = false;
				playerScript.MechActive = false;
				Transform item = itemSlot.transform.GetChild (0);
				item.GetComponent<CircleCollider2D> ().enabled = true;
				item.SetParent (null);
				item.GetComponent<Rigidbody2D> ().velocity = transform.forward * 10;
			}
		}
	}
}
