using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemgrabber : MonoBehaviour {

	public bool hasItem = false;
	public float itemReach = 1.5f;
	public LayerMask itemLayer;
	public KeyCode grabButton;
	public GameObject itemSlot;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ItemGrabber ();
	}

	void ItemGrabber()
	{
		if(Input.GetKeyDown(grabButton))
		{
			Collider2D item = Physics2D.OverlapCircle (transform.position, itemReach, itemLayer);
			if(item != null && !hasItem)
			{
				item.gameObject.transform.SetParent (itemSlot.transform);
				hasItem = true;
				item.gameObject.transform.localPosition = Vector3.zero;
				item.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) && hasItem)
		{
			hasItem = false;
			Transform item = itemSlot.transform.GetChild (0);
			item.GetComponent<CircleCollider2D> ().enabled = true;
			item.SetParent (null);
			item.GetComponent<Rigidbody2D> ().velocity = transform.forward * 10;
		}
	}

}
