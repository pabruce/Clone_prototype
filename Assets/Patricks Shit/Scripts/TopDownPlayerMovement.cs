using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerMovement : MonoBehaviour 
{

    public float speed;

    public Animator anim;

    public GameObject sparkler;

    public float sparklerForce;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //moving right
        if (horizontal > .01f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }

        //moving left
        if (horizontal > -.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);
        }

        //moving up 
        if (vertical > .01)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
        }

        //moving downwards
        if (vertical > -.01)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        transform.Translate(horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime, 0f, Space.World);

        //anim.SetFloat("speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));

    }
}
