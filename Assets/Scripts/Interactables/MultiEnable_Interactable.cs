using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiEnable_Interactable : Interactable 
{
	[Tooltip("The current state index. When the switch is flipped, curState++ and that index is chosen from enableStates.")]
	public int curState; 

	[System.Serializable] 
	public struct EnableState
	{
		public GameObject[] objectsToEnable; 
		public GameObject[] objectsToDisable; 
	}

	public EnableState[] enableStates; 



	public override void OnInteract()
	{
		if (enableStates.Length == 0)
		{
			return; 
		}

		curState++; 

		if (curState >= enableStates.Length || curState < 0)
		{
			curState = 0; 
		}

		foreach (GameObject g in enableStates[curState].objectsToEnable)
		{
			g.SetActive(true); 
		}

		foreach (GameObject g in enableStates[curState].objectsToDisable)
		{
			g.SetActive(false); 
		}
	}
}
