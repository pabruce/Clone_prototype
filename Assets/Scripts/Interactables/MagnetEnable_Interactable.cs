using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetEnable_Interactable : Interactable 
{
	[Tooltip("Drag in the GameObject that will be affected")]
	public Magnet magnet; 

	public override void OnInteract()
	{
		magnet.activated = !magnet.activated; 
	}
}
