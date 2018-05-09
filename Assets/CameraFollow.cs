using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject targetFollow;
    Vector3 targetPos;
    Vector3 IntepolatePos;
    public float followSpeed;
	// Use this for initialization
	
	// Update is called once per frame
	void LateUpdate () {
        targetPos.x = targetFollow.transform.position.x;
        targetPos.y = targetFollow.transform.position.y;
        targetPos.z = this.transform.position.z;
        IntepolatePos = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
        this.transform.position = IntepolatePos;
	}
}
