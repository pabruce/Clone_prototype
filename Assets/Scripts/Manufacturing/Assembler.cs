using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : MonoBehaviour
{
    public bool isGenerating = false;

    public ItemDetector itemDetector;


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
        AssemblerControl();

    }

    void AssemblerControl()
    {
        if (itemDetector != null)
        {
            //check detector
			if (!isGenerating && itemDetector.isActive)
            {
				isGenerating = true;
                Instantiate(key, new Vector2(-5,-4), Quaternion.identity);
            }
        }
        else
        {
			if (Vector3.Distance(player.transform.position, transform.position) <= 0.75f && Input.GetKeyDown(KeyCode.E) && !isGenerating)
            {
				isGenerating = true;
            }
        }
    }
    public void ActivateAssembler()
    {
		isGenerating = true;
       
    }
}
