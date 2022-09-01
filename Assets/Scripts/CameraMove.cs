using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject SnakeHead;
    public Vector3 PlatformToCameraOffset;
    public float Speed;

    private void Update()
    {
        //Vector3 targetPosition = SnakeHead.transform.position + PlatformToCameraOffset;
        //transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, SnakeHead.transform.position + PlatformToCameraOffset, Time.deltaTime * Speed);

    }
}


