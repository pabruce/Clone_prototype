using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour 
{
	public bool activated; 
	public float strength; 
	public float range; 
	public bool push; 

	ParticleSystem pushParticles; 
	ParticleSystem pullParticles; 


	// Use this for initialization
	void Start () 
	{
		pushParticles = transform.Find("PushParticles").GetComponent<ParticleSystem>(); 
		pullParticles = transform.Find("PullParticles").GetComponent<ParticleSystem>(); 
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		List<Rigidbody2D> affected = new List<Rigidbody2D>(); 

		if (activated)
		{
			// Particles
			if (push)
			{
				pushParticles.gameObject.SetActive(true); 
				pullParticles.gameObject.SetActive(false); 
			}
			else
			{
				pushParticles.gameObject.SetActive(false); 
				pullParticles.gameObject.SetActive(true);
			}

			// Find objects within range
			RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -transform.up, range); 
			//Debug.DrawRay(transform.position, -transform.up * range); 

			Debug.Log("hits: " + hits.Length); 

			for (int i = 0; i < hits.Length; i++)
			{
				if (hits[i].transform.gameObject.GetComponent<MagneticObject>())
				{
					affected.Add(hits[i].transform.gameObject.GetComponent<Rigidbody2D>()); 
				}
			}

			// Push/pull affected objects
			foreach (Rigidbody2D rb in affected)
			{
				if (push)
				{
					if (rb.GetComponent<LightningBolt> () != null)
						rb.velocity = rb.GetComponent<LightningBolt> ().moveSpeed * rb.transform.up + (-transform.up * strength * rb.gameObject.GetComponent<MagneticObject> ().strengthMultiplier);
					else
						rb.AddForce(-transform.up * strength * rb.gameObject.GetComponent<MagneticObject>().strengthMultiplier * 0.0001f);
				}
				else
				{
					if (rb.GetComponent<LightningBolt> () != null)
						rb.velocity = rb.GetComponent<LightningBolt> ().moveSpeed * rb.transform.up + (transform.up * strength * rb.gameObject.GetComponent<MagneticObject> ().strengthMultiplier);
					else
						rb.AddForce(transform.up * strength * rb.gameObject.GetComponent<MagneticObject>().strengthMultiplier * 0.0001f);
				}
			}
		}
		else
		{
			pushParticles.gameObject.SetActive(false); 
			pullParticles.gameObject.SetActive(false); 
		}
	}

	public void Toggle()
	{
		activated = !activated; 
	}
}
