using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyorBelt))]
public class ReverseConveyor_Interactable : Interactable 
{
	ConveyorBelt belt; 

	// Use this for initialization
	void Start () 
	{
		belt = GetComponent<ConveyorBelt>(); 
	}
	
	public override void OnInteract()
	{
		belt.speed *= -1;  
	}
}
