using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowapocalypse : MonoBehaviour, ICow {

    bool ispulled = false;
    Rigidbody2D cowRigidbody;

    private void Start()
    {
        cowRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!ispulled)
        {
            if(this.transform.localScale.x < 1 && this.transform.localScale.y < 1)
            {
                this.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime);
            }
        }
    }


    public void Interaction(Transform target)
    {
        ispulled = true;
        cowRigidbody.gravityScale = 0;
        Vector3 targetDirection = target.transform.position - transform.position;
        transform.position += targetDirection * 4 * Time.deltaTime;
    }

    public void EndInteraction()
    {
        ispulled = false;
        cowRigidbody.gravityScale = 1;
    }
}
