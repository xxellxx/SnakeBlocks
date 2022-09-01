using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject SnakeHead;
    Vector3 Target;
    public float speed;

    private void FixedUpdate()
    {
                
        Target = new Vector3(transform.position.x, transform.position.y, SnakeHead.transform.position.z - 2f);
        Vector3 currentPosition = Vector3.Slerp(transform.position, Target, speed * Time.deltaTime);
        transform.position = currentPosition;  

    }
}


