using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : MonoBehaviour
{
<<<<<<< HEAD
    public bool isOpen = false;
    public bool lockedToPlayer;

    public ButtonScript linkedButton;
    public ItemDetector itemDetector;
    public ItemDetector itemDetector2;


    public GameObject player;
    public Transform key;
    public float distanceToPlayer;

    // Use this for initialization    
void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
 

        /*if (linkedButton == null && itemDetector == null && flashTrigger == null)
			timeDelay = 0;*/
    }

    // Update is called once per frame
    void Update()
    {
        DoorControl();

    }

    void DoorControl()
    {
        //countdown timer
        if (linkedButton != null)
        {
            //check button
            if (!isOpen && linkedButton.isTriggered)
            {
                isOpen = true;
              
            }

        }
        else if (itemDetector != null)
        {
            //check detector
            if (!isOpen && itemDetector.isActive && itemDetector2.isActive)
            {
                isOpen = true;
                Instantiate(key, new Vector2(-5,-4), Quaternion.identity);
            }
        }
        else
        {
            if (Vector3.Distance(player.transform.position, transform.position) <= 0.75f && Input.GetKeyDown(KeyCode.E) && !isOpen && !lockedToPlayer)
            {
                isOpen = true;
            }
        }
    }
    public void Open()
    {
        isOpen = true;
       
    }

    public void Open(float time)
    {
        isOpen = true;
      
    }
=======
	
>>>>>>> 9c4dcb8f65eda8caa699767cdc2e4c539a146110
}
