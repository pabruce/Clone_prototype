using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Interactable : Interactable 
{
	[Tooltip("Drag in the GameObject that will be affected")]
	public GameObject obj; 

	[Tooltip("The angle that the object will rotate each time")]
	public float rotateAmount; 

	public override void OnInteract()
	{
		obj.transform.Rotate(new Vector3 (0, 0, rotateAmount));   
	}
}
