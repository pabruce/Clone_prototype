using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerDir_Interactable : Interactable 
{
	[Tooltip("Drag in the GameObject that will be affected")]
	public ConveyerBelt_v2 conveyorSegment; 

	[Tooltip("The current state index. When the switch is flipped, curState++ and that index is chosen from conveyerDirStates to pick the new directions.")]
	public int curState; 

	[System.Serializable]
	public struct ConveyerDirState
	{
		public ConveyerBelt_v2.Directions posDir; 
		public ConveyerBelt_v2.Directions revDir; 
	}

	[Tooltip("Array of conveyor directions, corresponding to the curState.")]
	public ConveyerDirState[] conveyerDirStates; 

	public override void OnInteract()
	{
		if (conveyerDirStates.Length == 0)
		{
			return; 
		}

		curState++; 

		if (curState >= conveyerDirStates.Length || curState < 0)
		{
			curState = 0; 
		}

		conveyorSegment.positiveDirection = conveyerDirStates[curState].posDir; 
		conveyorSegment.reverseDirection = conveyerDirStates[curState].revDir; 

	}
}
