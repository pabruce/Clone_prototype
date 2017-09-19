using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningReciever : MonoBehaviour 
{
	public bool isActive;
	private float timer;
	private float timeBetweenHits = 0.25f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timer > 0)
			timer -= Time.deltaTime;
		else
			timer = 0;
		isActive = timer > 0;
	}
		
	public void Activate()
	{
		timer = timeBetweenHits;
	}
}
