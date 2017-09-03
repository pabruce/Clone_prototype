using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAI : MonoBehaviour 
{
	public LayerMask visionLayers;
	public float sightRange = 3;
	public float moveSpeed;

	public Vector3 target;
	public bool hasTarget = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		VisionCone ();	
		if (Mathf.Abs (Vector3.Distance (transform.position, target)) < 0.25f && hasTarget)
			hasTarget = false;
		Movement ();
	}

	void Movement()
	{
		if(hasTarget)
		{
			Vector3 diff = transform.position - target;
			diff.Normalize();

			float rotation = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rotation + 90);

			transform.Translate (Vector3.up * moveSpeed * Time.deltaTime);
		}
	}

	void VisionCone()
	{
		//Physics2D.Linecast(transform.position)

		RaycastHit2D[] hits = new RaycastHit2D[11];

		hits[0] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 4.92f) + (transform.right * -0.87f), visionLayers);
		hits[1] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 4.7f) + (transform.right * -1.71f), visionLayers);
		hits[2] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 4.33f) + (transform.right * -2.5f), visionLayers);
		hits[3] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 3.83f) + (transform.right * -3.21f), visionLayers);
		hits[4] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 3.21f) + (transform.right * -3.83f), visionLayers);
		hits[5] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 5), visionLayers);
		hits[6] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 4.92f) + (transform.right * 0.87f), visionLayers);
		hits[7] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 4.7f) + (transform.right * 1.71f), visionLayers);
		hits[8] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 4.33f) + (transform.right * 2.5f), visionLayers);
		hits[9] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 3.83f) + (transform.right * 3.21f), visionLayers);
		hits[10] = Physics2D.Linecast (transform.position, transform.position + (transform.up * 3.21f) + (transform.right * 3.83f), visionLayers);

		if(hits[0].collider != null)
			Debug.DrawLine (transform.position, hits [0].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 4.92f) + (transform.right * -0.87f), Color.yellow);
		if(hits[1].collider != null)
			Debug.DrawLine (transform.position, hits [1].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 4.7f) + (transform.right * -1.71f), Color.yellow);
		if(hits[2].collider != null)
			Debug.DrawLine (transform.position, hits [2].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 4.33f) + (transform.right * -2.5f), Color.yellow);
		if(hits[3].collider != null)
			Debug.DrawLine (transform.position, hits [3].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 3.83f) + (transform.right * -3.21f), Color.yellow);
		if(hits[4].collider != null)
			Debug.DrawLine (transform.position, hits [4].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 3.21f) + (transform.right * -3.83f), Color.yellow);
		if(hits[5].collider != null)
			Debug.DrawLine (transform.position, hits [5].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 5), Color.yellow);
		if(hits[6].collider != null)
			Debug.DrawLine (transform.position, hits [6].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 4.92f) + (transform.right * 0.87f), Color.yellow);
		if(hits[7].collider != null)
			Debug.DrawLine (transform.position, hits [7].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 4.7f) + (transform.right * 1.71f), Color.yellow);
		if(hits[8].collider != null)
			Debug.DrawLine (transform.position, hits [8].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 4.33f) + (transform.right * 2.5f), Color.yellow);
		if(hits[9].collider != null)
			Debug.DrawLine (transform.position, hits [9].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 3.83f) + (transform.right * 3.21f), Color.yellow);
		if(hits[10].collider != null)
			Debug.DrawLine (transform.position, hits [10].point, Color.red);
		else
			Debug.DrawLine (transform.position, transform.position + (transform.up * 3.21f) + (transform.right * 3.83f), Color.yellow);

		for(int i = 0; i < hits.Length; i++)
		{
			if(hits[i].collider != null)
			{
				if (hits [i].collider.CompareTag ("Player")) 
				{
					target = hits [i].collider.transform.position;
					hasTarget = true;
				}
			}

		}

	}
}
