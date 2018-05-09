using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour {
    private float MovementSpeed;
    Vector3 targetPosition;
    Vector3 Velocity;
    Vector3 PreviousPosition;
    Transform AlienShip;
	// Use this for initialization
	void Start () {
        MovementSpeed = 5;
        PreviousPosition = transform.position;
        AlienShip = this.gameObject.transform.Find("Alien");
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CalculateVelocity();
        TiltShip();
	}

    private Vector2 GetInput()
    {
        return new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };
    }

    private void Move()
    {
        targetPosition = new Vector3(GetInput().x, GetInput().y, 0);
        targetPosition = transform.TransformDirection(targetPosition);
        transform.position += targetPosition * MovementSpeed * Time.deltaTime;
    }

    private void CalculateVelocity()
    {
        Velocity = (transform.position - PreviousPosition) / Time.deltaTime;
        PreviousPosition = transform.position;
        Debug.Log(Velocity);
    }

    private void TiltShip()
    {
        AlienShip.rotation = Quaternion.Euler(0, 0, -Velocity.x);
    }
}
