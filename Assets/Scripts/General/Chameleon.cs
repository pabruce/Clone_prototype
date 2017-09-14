using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chameleon : MonoBehaviour {

	public bool isHidden;
	public bool isInHideZone;
	public KeyCode hideButton;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () 
	{
		if(isInHideZone && Input.GetKeyDown(hideButton))
		{
			ToggleHide ();
		}
		if(isHidden && !isInHideZone)
		{
			ToggleHide ();
		}

	}

	void ToggleHide()
	{
		isHidden = !isHidden;
		if(isHidden)
		{
			gameObject.layer = 14;
			gameObject.GetComponent<SpriteRenderer> ().color = new Color(0, 0.6f, 0.2f);
		}
		else
		{
			gameObject.layer = 13;
			gameObject.GetComponent<SpriteRenderer> ().color = Color.green;
		}
	}
}
