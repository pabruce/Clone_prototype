using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashTrigger : MonoBehaviour {


	public bool isTriggered = false;
	public bool isReusable = false;
	public float activeTime = 1;
	private float timer = 0;

	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
	}

	// Update is called once per frame
	void Update () 
	{
		if (isTriggered && timer == 0) 
		{
			isTriggered = false;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		}
		if (timer > 0)
			timer -= Time.deltaTime;
		else
			timer = 0;
	}

	public void Trigger()
	{
		isTriggered = true;
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0);
		timer = activeTime;
	}
}
