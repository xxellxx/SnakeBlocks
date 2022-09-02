using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCount : MonoBehaviour
{
    public GameObject SnakeHead;
    Vector3 Target;
    public float speed;
    public float posX;

    private void FixedUpdate()
    {

        Target = new Vector3(SnakeHead.transform.position.x, transform.position.y, SnakeHead.transform.position.z);
        Vector3 currentPosition = Vector3.Slerp(transform.position, Target, speed * Time.deltaTime);
        currentPosition.x += posX;
        transform.position = currentPosition;

    }
}
