using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObj_Interactable : Interactable 
{
	public override void OnInteract()
	{
		gameObject.SetActive(!gameObject.activeSelf); 
	}
}
