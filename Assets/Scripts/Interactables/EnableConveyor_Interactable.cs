using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableConveyor_Interactable : Interactable 
{
	[Tooltip("Drag in the GameObject that will be affected")]
	public ConveyerController conveyorBelt; 
	
	public override void OnInteract()
	{
		conveyorBelt.isOn = !conveyorBelt.isOn;  
	}
}
