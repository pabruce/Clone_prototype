using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSwitch : MonoBehaviour 
{
	[HideInInspector] public bool activated;

	[Header("Toggle via Inspector")]
	public bool clickToToggle; 

	// Use this for initialization
	void Start () 
	{
			
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateSwitchDisplay(); 

		if (clickToToggle)
		{
			clickToToggle = false; 
			ToggleSwitch(); 
		}
	}

	public void ToggleSwitch()
	{
		activated = !activated;
		SwitchInteract(); 
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

	void SwitchInteract()
	{
		foreach (Interactable i in GetComponents<Interactable>())
		{
			i.OnInteract(); 
		}
	}
}
