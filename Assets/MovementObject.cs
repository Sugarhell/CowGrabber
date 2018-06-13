using UnityEngine;
using System.Collections;

public class MovementObject : MonoBehaviour
{
    private Transform Objtransform;
    public float MovementSpeed = 3.0f;
    Vector3 targetPosition;
    GameObject ObjModel;
    public Vector3 PreviousPosition;
    public Vector3 Velocity;
    // Use this for initialization

    public virtual void Start()
    {
        Objtransform = this.transform;
        PreviousPosition = this.transform.position;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Move();
    }

    private Vector2 GetInput()
    {
        return new Vector2
        {
            x = Input.GetAxis("Horizontal"),
            y = Input.GetAxis("Vertical")
        };
    }

    public virtual void Move()
    {
        targetPosition = new Vector3(GetInput().x, GetInput().y, 0);
        targetPosition = transform.TransformDirection(targetPosition);
        transform.position += targetPosition * MovementSpeed * Time.deltaTime;
    }

    public virtual void CalculateVelocity()
    {
        Velocity = (transform.position - PreviousPosition) / Time.deltaTime;
        PreviousPosition = transform.position;
        Debug.Log(Velocity);
    }

    public virtual void ObjRotation()
    {

    }


}
