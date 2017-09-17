using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Patrol : MonoBehaviour
{

    public Transform[] patrolPoints;
    public float Speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    void Start()
    {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Speed);
        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < .1f)
        {
            //We have reached the patrol point - get the next one 
            //Check to see if we have any patrol points - if not go back to the beginning
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }

        //Turn to face the current patrol point 
        //Finding direction Vector that points to patrol point
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        //Figure out the rotation in degrees of the next patrol point we need to face 
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        //Made the rotation to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Apply rotation to transform
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 180f);
    }
}
