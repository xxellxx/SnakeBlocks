using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody RigidbodyHead;


    private void Update()
    {
        RigidbodyHead.velocity = new Vector3(0, 0, speed);
    }
}

