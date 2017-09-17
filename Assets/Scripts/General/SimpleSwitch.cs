using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSwitch : MonoBehaviour 
{
	public bool activated; 
	public Interactable[] toggleTargets; 

	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateSwitchDisplay(); 
	}

	public void ToggleSwitch()
	{
		activated = !activated;
		ToggleTargets(); 
	}

	void UpdateSwitchDisplay()
	{
		if (activated)
		{
			transform.localScale = new Vector3 (Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
		}
		else
		{
			transform.localScale = new Vector3 (-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
		}
	}

	void ToggleTargets()
	{
		foreach (Interactable i in toggleTargets)
		{
			i.OnInteract(); 
		}
	}
}
