using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDest;

    // Update is called once per frame
    void Update()
    {
        if(patrolDest == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolPoints[0].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                patrolDest = 1;
            }
        }

        if (patrolDest == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, patrolPoints[1].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                patrolDest = 0;
            }
        }
    }
}
