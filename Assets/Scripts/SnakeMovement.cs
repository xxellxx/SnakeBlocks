using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody RigidbodyHead;

    //private Vector3 _previousMousePosition;    
    public float sensitivity;

    private Vector3 touchLastPos;
    float sidewaySpeed;



    private void Update()
    {
        //RigidbodyHead.velocity = new Vector3(0, 0, speed);

        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 delta = Input.mousePosition - _previousMousePosition;
        //    RigidbodyHead.velocity = new Vector3(delta.x * Sensitivity, 0, 0);
        //}            
        //_previousMousePosition = Input.mousePosition;
        //

        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos.x = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
            touchLastPos.y = 0;
            touchLastPos.z = 0;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaySpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = (Camera.main.ScreenToViewportPoint(Input.mousePosition) - touchLastPos);
            sidewaySpeed += delta.x * sensitivity;
            touchLastPos.x = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        }
    }
    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaySpeed) > 4) sidewaySpeed = 4 * Mathf.Sign(sidewaySpeed);

        RigidbodyHead.velocity = new Vector3(sidewaySpeed * 3, 0, speed);
        sidewaySpeed = 0;
    }
}

