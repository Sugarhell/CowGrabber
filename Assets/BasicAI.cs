using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour {

    Collider2D[] Paths;
    Path2D path;
    public Transform ta;

    private void Start()
    {
        Paths = Physics2D.OverlapCircleAll(this.transform.position, 10.0f);
        foreach(Collider2D c in Paths)
        {
            if(c.gameObject.GetType().IsSubclassOf(typeof(Path2D)))
            {
                path = c.GetComponent<Path2D>();
                break;
            }
        }
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {

            Move(ta);
            Debug.Log("Patrolling");
        
            
    }


    private void Move(Transform WayPoint)
    {
        Vector3 Direction = WayPoint.position - transform.position;
        transform.position += Direction.normalized * 4.0f*Time.deltaTime;
    }
}


