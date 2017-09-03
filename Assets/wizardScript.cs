using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wizardScript : MonoBehaviour 
{
	public float moveSpeed = 1;
	public int currentSpellID = 0;
	public ParticleSystem particles;
	public GameObject itemSlot;
	public bool hasItem = false;

	public float itemReach = 1.5f;
	public LayerMask itemLayer;
	public GameObject flashSpellPrefab;
	public LayerMask wallLayers;
	private LineRenderer spellLine;
	public Gradient redLine;
	public Gradient whiteLine;

	// Use this for initialization
	void Start () 
	{
		spellLine = gameObject.GetComponent<LineRenderer> (); 
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
		Magic ();
		MagicEffect ();
		ItemGrabber ();
	}

	void Movement()
	{
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W))
		{
			transform.Translate (Vector3.up * moveSpeed * Time.deltaTime);
		}

		//rotate
		if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 45));
		}
		else if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 135));
		}
		else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 225));
		}
		else if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 315));
		}
		else if(Input.GetKey(KeyCode.A))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 90));
		}
		else if(Input.GetKey(KeyCode.D))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 270));
		}
		else if(Input.GetKey(KeyCode.S))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 180));
		}
		else if(Input.GetKey(KeyCode.W))
		{
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
		}

	}

	void Magic()
	{
		if(Input.GetKeyDown(KeyCode.Mouse0) && currentSpellID == 1)
		{
			RaycastHit2D hit = Physics2D.Linecast (transform.position, particles.transform.position, wallLayers);
			if(hit.collider == null)
			{
				Instantiate (flashSpellPrefab, particles.transform.position, Quaternion.identity);
			}
			currentSpellID = 0;
		}

		if (Input.GetKeyDown (KeyCode.Alpha1))
			currentSpellID = 1;
	}

	void MagicEffect()
	{
		particles.gameObject.transform.position = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);
		spellLine.SetPosition (0, transform.position);
		switch(currentSpellID)
		{
		case 0:
			spellLine.SetPosition (1, transform.position);
			if (particles.isPlaying)
				particles.Stop();
			if (particles.transform.Find("FlashTarget").GetComponent<SpriteRenderer>().enabled)
				particles.transform.Find("FlashTarget").GetComponent<SpriteRenderer>().enabled = false;
			break;
		case 1:
			spellLine.SetPosition (1, particles.transform.position);
			if (!particles.isPlaying)
				particles.Play ();
			if (!particles.transform.Find ("FlashTarget").GetComponent<SpriteRenderer> ().enabled)
				particles.transform.Find ("FlashTarget").GetComponent<SpriteRenderer> ().enabled = true;
			RaycastHit2D hit = Physics2D.Linecast (transform.position, particles.transform.position, wallLayers);
			if (hit.collider == null) {
				spellLine.colorGradient = whiteLine;
				particles.transform.Find ("FlashTarget").GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.2f);
			}
			else {
				spellLine.colorGradient = redLine;
				particles.transform.Find ("FlashTarget").GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0, 0.2f);
			}
			break;
		}
			
	}

	void ItemGrabber()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			Collider2D item = Physics2D.OverlapCircle (transform.position, itemReach, itemLayer);
			if(item != null && !hasItem)
			{
				item.gameObject.transform.SetParent (itemSlot.transform);
				hasItem = true;
				item.gameObject.transform.localPosition = Vector3.zero;
				item.gameObject.GetComponent<CircleCollider2D> ().enabled = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.Space) && hasItem)
		{
			hasItem = false;
			Transform item = itemSlot.transform.GetChild (0);
			item.GetComponent<CircleCollider2D> ().enabled = true;
			item.SetParent (null);
			item.GetComponent<Rigidbody2D> ().velocity = transform.forward * 10;
		}
	}

	void OnCollisionEnter2D(Collision2D colliderHit)
	{
		if (colliderHit.collider.CompareTag ("Guard"))
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
			//Application.LoadLevel(Application.loadedLevel);
	}

}
