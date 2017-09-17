using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyorBelt))]
public class EnableConveyor_Interactable : Interactable 
{
	ConveyorBelt belt; 

	// Use this for initialization
	void Start () 
	{
		belt = GetComponent<ConveyorBelt>(); 
	}
	
	public override void OnInteract()
	{
		belt.activated = !belt.activated; 
	}
}
