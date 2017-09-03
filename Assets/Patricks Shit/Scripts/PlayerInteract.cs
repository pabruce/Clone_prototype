using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;

     void Update()
    {
        if (Input.GetButtonDown("Interact") && currentInterObj)
        {
            //Check to see if this objecct is to be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentInterObj);
            }

            //check if object can be opened
            if (currentInterObjScript.openable)
            {
                //check if object is locked
                if (currentInterObjScript.locked)
                {
                    //check to see if we have object to unlock
                    //search inventory for the item needed 
                    if (inventory.FindItem(currentInterObjScript.itemNeeded))
                    {
                        //we found the item needed
                        currentInterObjScript.locked = false;
                        Debug.Log(currentInterObj.name + " was unlocked");
                    }
                    else
                    {
                        Debug.Log(currentInterObj.name + " was not unlocked");
                    }
                }
                else
                {
                    //object is not locked - open the object
                    Debug.Log(currentInterObj.name + "is unlocked");
                    currentInterObjScript.Open();
                }
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            Debug.Log(other.name);
            currentInterObj = other.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currentInterObj)
            {
                currentInterObj = null;
            }
        }
    }

}
