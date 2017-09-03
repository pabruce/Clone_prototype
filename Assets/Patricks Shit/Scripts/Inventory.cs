using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory = new GameObject[10];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        //find first open slot in inv
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + "was added");
                itemAdded = true;            
                //Do something with the object
                item.SendMessage("DoInteraction");
                break;
            }
        }

        if (!itemAdded)
        {
            Debug.Log("Inventory Full. Left Item.");
        }
    }

     public bool FindItem(GameObject item)
     {
       for (int i = 0; i < inventory.Length; i++)
       {
         if (inventory[i] == item)
         {
           return true; //item found
         }
       }

        return false; //item not found
     }
    
}
