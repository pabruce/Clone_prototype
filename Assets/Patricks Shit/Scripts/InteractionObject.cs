using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

    public bool inventory; //if true, object is stored
    public bool openable; //if true, object openable
    public bool locked; //if true, object lock
    public GameObject itemNeeded; //item needed to interact

    public Animator anim;

    public void DoInteraction()
    {
        //Picked up and put in inventory
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(false);
    }
}
