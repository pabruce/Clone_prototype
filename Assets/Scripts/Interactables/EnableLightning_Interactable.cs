using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLightning_Interactable : Interactable {

	[Tooltip("Drag in the GameObject that will be affected")]
	public LightningSender teslaCoil; 

	public override void OnInteract()
	{
		teslaCoil.isOn = !teslaCoil.isOn;  
	}
}
