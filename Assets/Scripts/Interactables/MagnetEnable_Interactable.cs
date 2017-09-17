using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Magnet))]
public class MagnetEnable_Interactable : Interactable 
{
	Magnet magnet; 

	void Start()
	{
		magnet = GetComponent<Magnet>(); 
	}

	public override void OnInteract()
	{
		magnet.activated = !magnet.activated; 
	}
}
