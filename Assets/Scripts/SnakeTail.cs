using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public Transform SnakePart;

    List<Transform> snakeCircles = new List<Transform>();
    List<Vector3> positions = new List<Vector3>();

    public float circleDiameter;


    private void Start()
    {
        positions.Add(SnakeHead.position);
        AddCircle();
        AddCircle();
    }
    private void Update()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if(distance > circleDiameter)
        {
            positions.Insert(0, SnakeHead.position);
            positions.RemoveAt(positions.Count - 1);

            distance -= circleDiameter;
        }

        for(int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance/circleDiameter);
        }
    }
    public void AddCircle()
    {
        Transform circle = Instantiate(SnakePart, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }
}
