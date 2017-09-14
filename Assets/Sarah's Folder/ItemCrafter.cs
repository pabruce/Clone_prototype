using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCrafter : MonoBehaviour {

	public ItemDetector[] ingredientDetectors;
	bool isUsed;
	public GameObject itemToSpawn;
	public Transform spawnLocation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isUsed)
		{
			if(CheckDetectors())
			{
				Instantiate (itemToSpawn, spawnLocation.position, spawnLocation.rotation);
				isUsed = true;
			}
		}
	}

	bool CheckDetectors()
	{
		for(int i = 0; i < ingredientDetectors.Length; i++)
		{
			if (!ingredientDetectors [i].isActive)
				return false;
		}
		return true;
	}
}
