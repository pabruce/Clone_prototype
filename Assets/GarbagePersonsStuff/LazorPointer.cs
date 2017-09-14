using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazorPointer : MonoBehaviour {
	public wizardScript player;
	public LayerMask lazerImpactLayers;
	private LineRenderer lazerLine;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<wizardScript>();
		lazerLine = gameObject.GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player.hasItem && transform.parent.CompareTag("Player") && Input.GetKey(KeyCode.E))
		{
			RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 10000f, lazerImpactLayers);
			lazerLine.SetPosition (0, transform.position);
			lazerLine.SetPosition (1, hit.point);
		}
		else
		{
			lazerLine.SetPosition (0, transform.position);
			lazerLine.SetPosition (1, transform.position);
		}

		/*RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 10000f, lazerImpactLayers);
		lazerLine.SetPosition (0, transform.position);
		lazerLine.SetPosition (1, hit.point);*/
	}
}
