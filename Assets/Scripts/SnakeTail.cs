using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public Transform SnakePart;

    public GameManagerScript GM;

    List<Transform> snakeCircles = new List<Transform>();
    List<Vector3> positions = new List<Vector3>();

    public float circleDiameter;

    public TextMeshPro SnakeCountText;

    public int snakeCount = 1;

    public int score = 0;
    public TextMeshProUGUI scoreText;


    private void Start()
    {
        positions.Add(SnakeHead.position);
        SnakeCountText.text = snakeCount + "";
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score " + score;

        AddCircle();
        AddCircle();
    }
    private void Update()
    {
        float distance = (SnakeHead.position - positions[0]).magnitude;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddCircle();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RemoveCircle();
        }

        if (distance > circleDiameter)
        {            
            Vector3 direction = (SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * circleDiameter);
            positions.RemoveAt(positions.Count - 1);

            distance -= circleDiameter;
        }

        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / circleDiameter);
        }
    }
    public void AddCircle()
    {
        Transform circle = Instantiate(SnakePart, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
        snakeCount++;
        SnakeCountText.text = snakeCount + "";
        score++;
        scoreText.text = "Score " + score;
    }

    public void RemoveCircle()
    {
        if(snakeCount >= 2)
        {
            Destroy(snakeCircles[0].gameObject);
            snakeCircles.RemoveAt(0);
            positions.RemoveAt(1);
            snakeCount--;
            SnakeCountText.text = snakeCount + "";
        }
        else
        {
            GM.OnPlayerDied();
        }
        
    }
}
