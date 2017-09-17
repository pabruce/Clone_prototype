using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Magnet))]
public class MagnetReverse_Interactable : Interactable 
{
	Magnet magnet; 

	void Start()
	{
		magnet = GetComponent<Magnet>(); 
	}

	public override void OnInteract()
	{
		magnet.push = !magnet.push; 
	}
}
