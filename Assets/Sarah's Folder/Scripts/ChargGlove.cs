using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargGlove : MonoBehaviour 
{
	public LineRenderer beam;
	public ParticleSystem particles;
	public bool isCharged;
	public LayerMask chargeBoxLayer;
	public float range;
	private bool showBeam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		beam.SetPosition (0, transform.position);
		if (!showBeam)
			beam.SetPosition (1, transform.position);
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			RaycastHit2D hit = Physics2D.Linecast (transform.position, transform.position + (transform.up * range), chargeBoxLayer);
			if(hit.collider != null)
			{
				showBeam = true;
				ChargeBox boxHit = hit.collider.GetComponent<ChargeBox> ();
				beam.SetPosition (1, hit.transform.position);
				if(isCharged && !boxHit.isCharged)
				{
					isCharged = false;
					boxHit.isCharged = true;
				}
				else if(!isCharged && boxHit.isCharged)
				{
					isCharged = true;
					boxHit.isCharged = false;
				}
			}
			else
				beam.SetPosition (1, transform.position + (transform.up * range));
			StartCoroutine (EndBeam (0.3f));
		}

		if (isCharged && !particles.isPlaying)
			particles.Play ();
		if (!isCharged && particles.isPlaying)
			particles.Stop ();
	}

	IEnumerator EndBeam(float time)
	{
		yield return new WaitForSeconds (time);
		showBeam = false;
	}
}
