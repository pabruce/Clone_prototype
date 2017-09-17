using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOCamera : MonoBehaviour 
{

		public Transform Object1;
		public Transform Object2;
		public Vector3 center;

		void Update () 
	{
		center = ((Object2.position - Object1.position)/2.0f) + Object1.position;
		transform.LookAt(center);
	}
}
