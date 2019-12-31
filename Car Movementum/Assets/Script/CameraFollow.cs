using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectFollow;
    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;

    public void lookAtTarget()
    {
        Vector3 lookDirection = objectFollow.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
    }

    public void moveToTarget()
    {
        Vector3 targetPos = objectFollow.position + objectFollow.forward * offset.z +
                            objectFollow.right * offset.x + objectFollow.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    public void FixedUpdate()
    {
        lookAtTarget();
        moveToTarget();
    }

}
