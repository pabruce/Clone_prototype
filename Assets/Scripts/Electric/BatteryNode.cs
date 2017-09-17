using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryNode : MonoBehaviour 
{
	public Color onColor; 
	public Color offColor; 

	public bool activated; 

	//public GameObject[] toggleTargets; 
	public Interactable[] toggleTargets; 


	public float useTimerLength;
	private float useTimer; 

	SpriteRenderer rend; 

	GameObject progressBar; 

	void Awake ()
	{
		rend = GetComponent<SpriteRenderer>(); 
	}

	// Use this for initialization
	void Start () 
	{
		useTimer = useTimerLength; 

		SetColor(); 

		//if (transform.Find("ProgressBar").gameObject != null)
		if (transform.Find("ProgressBar") != null)
		{
			progressBar = transform.Find("ProgressBar").gameObject; 
			progressBar.transform.localScale = new Vector3 (0, progressBar.transform.localScale.y, progressBar.transform.localScale.z); 
		}
	}

	// Update is called once per frame
	void Update () 
	{
		/*
		if (justToggled && !Input.GetKey(KeyCode.RightShift))
		{
			justToggled = false; 
		}
		*/

		SetColor(); 
	}

	public bool Interact(bool willActivate)
	{
		if (useTimer < useTimerLength && useTimerLength != 0)
		{
			float scaleX = ((useTimer) / useTimerLength) * 2; 

			if (progressBar != null)
				progressBar.transform.localScale = new Vector3 (scaleX, progressBar.transform.localScale.y, progressBar.transform.localScale.z); 
		}
		if (useTimer > 0)
		{
			useTimer -= Time.deltaTime; 
			if (useTimer < 0)
			{
				useTimer = 0;
				//tempShockStat.charged = !tempShockStat.charged;

				progressBar.transform.localScale = new Vector3 (0, progressBar.transform.localScale.y, progressBar.transform.localScale.z); 
				SetActivated(willActivate); 
				return true; 
			}
		}
		return false; 
	}

	// Resets interaction if the player didn't finish
	public void ResetInteract()
	{
		useTimer = useTimerLength; 
		progressBar.transform.localScale = new Vector3 (0, progressBar.transform.localScale.y, progressBar.transform.localScale.z); 
	}
		


	public void SetActivated(bool _activated)
	{
		activated = _activated; 
		useTimer = useTimerLength; 
		ToggleTargets(); 
	}

	void ToggleTargets()
	{
		/*
		foreach (GameObject g in toggleTargets)
		{
			if (!g.GetComponent<Magnet>().Equals(null))
			{
				g.GetComponent<Magnet>().Toggle(); 
			}
			else
			{
				g.SetActive(!g.activeSelf);
			}
		}
		*/ 

		foreach (Interactable i in toggleTargets)
		{
			i.OnInteract(); 
		}
	}

	void SetColor()
	{
		if (activated)
		{
			rend.color = onColor; 
		}
		else
		{
			rend.color = offColor; 
		}
	}
}
