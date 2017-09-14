using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeBox : MonoBehaviour 
{
	public bool isCharged;
	public SpriteRenderer chargeIndicator;

	void Update()
	{
		if (isCharged)
			chargeIndicator.color = Color.yellow;
		else
			chargeIndicator.color = Color.grey;
	}
}
