using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogScript : MonoBehaviour 
{
	public GameObject meat;
	public bool isAngry = true;
	public ItemDetector itemDetector;

	// Use this for initialization
	void Start () 
	{
		meat.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isAngry && itemDetector.isActive)
		{
			isAngry = false;
			transform.Translate (Vector3.left * 4);
			meat.SetActive (true);
			gameObject.layer = LayerMask.NameToLayer ("Wall");
		}
	}


}
