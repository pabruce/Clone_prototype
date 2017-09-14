using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSpell : MonoBehaviour 
{
	public LayerMask guardLayer;
	public LayerMask wallLayers;

	// Use this for initialization
	void Start () 
	{
		AttractGuards ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void AttractGuards()
	{
		Collider2D[] guardsHit = Physics2D.OverlapCircleAll (transform.position, 2, guardLayer);
		for(int i = 0; i < guardsHit.Length; i++)
		{
			//print (guardsHit [i].name);
			RaycastHit2D hit = Physics2D.Linecast (transform.position, guardsHit[i].transform.position, wallLayers);
			if(hit.collider == null)
			{
				//print ("clear");
				if(guardsHit[i].CompareTag("Guard")) 
				{
					guardsHit [i].GetComponent<GuardAI> ().target = transform.position;
					guardsHit [i].GetComponent<GuardAI> ().hasTarget = true;
				}
				else if(guardsHit[i].CompareTag("FlashTrigger"))
				{
					guardsHit [i].GetComponent<FlashTrigger> ().Trigger();
				}
			}

		}
		StartCoroutine (EndEffect ());
	}

	IEnumerator EndEffect()
	{
		yield return new WaitForSeconds (0.1f);
		Destroy (gameObject);
	}
}
