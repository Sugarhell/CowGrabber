using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowGrabber : MonoBehaviour {
    Collider2D[] cowsColliders;
    bool PullCows = false;
    private void Update()
    {
        cowsColliders = Physics2D.OverlapCircleAll(transform.position, 5);
        CheckCows();
    }

    void CheckCows()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            PullCows = !PullCows;
        }

        NewMethod();
    }

    private void NewMethod()
    {
        if (!PullCows)
        {
            return;
        }
        foreach (Collider2D c in cowsColliders)
        {
            if (c != null && c.gameObject.CompareTag("Cow"))
            {

                Vector3 tmp = transform.position - c.transform.position;
                Vector3 direction = (c.transform.position - transform.position).normalized;
                float tmp1 = Vector3.Dot(direction, -transform.up);
                if (tmp1 > 0.8)
                {

                    c.GetComponent<ICow>().Interaction(this.transform.GetChild(0));
                    

                }

            }

        }
    }
}
