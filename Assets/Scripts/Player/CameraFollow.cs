using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smooth;


    // Update is called once per frame
    private void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothposition = Vector3.Lerp(transform.position, targetPosition, smooth * Time.fixedDeltaTime);
        transform.position = targetPosition;
    }
}