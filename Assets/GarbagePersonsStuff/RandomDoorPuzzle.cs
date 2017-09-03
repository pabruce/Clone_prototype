using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDoorPuzzle : MonoBehaviour 
{
	public DoorScript[] doors = new DoorScript[8];
	public FlashTrigger[] triggers = new FlashTrigger[9];
	public DoorScript endDoor;
	public int[] shuffleArray = new int[8]{0, 1, 2, 3, 4, 5, 6, 7};

	public bool[] triggerCheck = new bool[9];
	public int currentDoor = 0;
	private float timer = 0;

	// Use this for initialization
	void Start () 
	{
		ResetPuzzle ();
		ShuffleArray ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(triggerCheck[0])
			timer += Time.deltaTime;
		for(int i = 0; i < triggers.Length; i++)
		{
			if(triggers[i].isTriggered && !triggerCheck[i])
			{
				triggerCheck [i] = true;
				if (currentDoor != 8) {
					doors [shuffleArray[currentDoor]].Open ();
					currentDoor++;
				} else
					endDoor.Open ();
			}
		}
		if (timer > 4 && !triggerCheck [1] && !triggerCheck [2] && !triggerCheck [3] && !triggerCheck [4] && !triggerCheck [5] && !triggerCheck [6] && !triggerCheck [7] && !triggerCheck [8])
			ResetPuzzle();
	}

	void ResetPuzzle()
	{
		print ("RESETTING");
		currentDoor = 0;
		for (int i = 0; i < triggerCheck.Length; i++) {
			triggerCheck [i] = false;
		}
		for(int i = 0; i < shuffleArray.Length; i++) {
			shuffleArray [i] = i;
		}
		timer = 0;
	}

	void ShuffleArray()
	{
		int temp;
		for(int i = 0; i < shuffleArray.Length; i++)
		{
			int rand = Random.Range (0, 8);
			temp = shuffleArray [rand];
			shuffleArray [rand] = shuffleArray [i];
			shuffleArray [i] = temp;
		}
	}

	void OnTriggerEnter2D(Collider2D colliderHit)
	{
		if (colliderHit.CompareTag ("Player"))
		{
			ResetPuzzle ();
			ShuffleArray ();
		}
	}
}
