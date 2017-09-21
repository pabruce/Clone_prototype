using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningReciever : MonoBehaviour {

	public float timer = 0;
	public bool isActive;
	public float delay = 0.25f;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () 
	{
		sprite = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (timer > 0)
			timer -= Time.deltaTime;
		else
			timer = 0;
		isActive = (timer > 0);

		if (isActive)
			sprite.color = Color.yellow;
		else
			sprite.color = Color.grey;
	}

	public void Charge()
	{
		timer = delay;
	}
}
