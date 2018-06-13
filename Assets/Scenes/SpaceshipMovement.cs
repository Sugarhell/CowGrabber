using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipMovement : MovementObject {
    Transform AlienShip;
	// Use this for initialization
	public override void Start () {
        base.Start();
        PreviousPosition = transform.position;
        AlienShip = this.gameObject.transform.Find("Alien");
        
	}
	
	// Update is called once per frame
	public override void Update()
    {
        base.Update();
        CalculateVelocity();
    }

    public override void ObjRotation()
    {
        AlienShip.rotation = Quaternion.Euler(0, 0, -Velocity.x);
    }

}
