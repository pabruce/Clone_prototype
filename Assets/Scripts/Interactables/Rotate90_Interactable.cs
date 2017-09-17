using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate90_Interactable : Interactable 
{
	
	public override void OnInteract()
	{
		transform.Rotate(new Vector3 (0, 0, 90));   
	}
}
