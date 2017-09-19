using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseConveyor_Interactable : Interactable 
{
	[Tooltip("Drag in the GameObject that will be affected")]
	public ConveyerController conveyorBelt; 

	
	public override void OnInteract()
	{
		conveyorBelt.isReversed = !conveyorBelt.isReversed; 
	}
}
