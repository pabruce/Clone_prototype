using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour {

	public GameObject plantPrefab;
	public Transform player;
	public bool isActive;
	public KeyCode abilityKey;
	public LayerMask wallLayers;
	public GameObject abilityEffect;
	public Gradient redLine;
	public Gradient whiteLine;
	public float abilityRange;
	public bool canUseAbility;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!isActive && Input.GetKeyDown (abilityKey)) {
			isActive = true;
			abilityEffect.SetActive (true);
		}
		AbilityOutline ();
	}

	void SpawnPlant()
	{
		
	}

	void AbilityOutline()
	{
		if(isActive)
		{
			abilityEffect.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
			abilityEffect.GetComponent<LineRenderer> ().SetPosition (0, player.transform.position);
			abilityEffect.GetComponent<LineRenderer> ().SetPosition (1, abilityEffect.transform.position);

			//check for line of sight
			RaycastHit2D hit = Physics2D.Linecast (player.transform.position, abilityEffect.transform.position, wallLayers);
			if (hit.collider == null && Vector3.Distance(player.transform.position, abilityEffect.transform.position) <= abilityRange) {
				abilityEffect.GetComponent<LineRenderer> ().colorGradient = whiteLine;
				abilityEffect.transform.Find ("Circle").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.2f);
				canUseAbility = true;
			} else {
				abilityEffect.GetComponent<LineRenderer> ().colorGradient = redLine;
				abilityEffect.transform.Find ("Circle").GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 0.2f);
				canUseAbility = false;
			}
		}
		else
		{
			canUseAbility = false;
			if (abilityEffect.activeInHierarchy)
				abilityEffect.SetActive (false);
		}
			
	}
}
