using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMovement : MovementObject {

    private Vector3 target;
    Transform AlienShip;

    public override void Start()
    {
        base.Start();
        MovementSpeed = 2.0f;
        AlienShip = this.gameObject.transform.Find("Alien");
    }

    public override void Update()
    {
        base.Update();
        ObjRotation();
    }

    public override void Move()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = 0;
        var delta = MovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, delta);
    }

    public override void ObjRotation()
    {
        CalculateVelocity();
        AlienShip.rotation = Quaternion.Euler(0, 0, -Velocity.x);
    }
}
