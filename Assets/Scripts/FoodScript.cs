using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    int foodAmount;
    public TextMesh foodAmountText;
    GameObject SnakeHead;
    SnakeTail SnakeTail;
    Collider SnakeHeadCollider;
    // Start is called before the first frame update
    void Start()
    {
        //foodAmount = Random.Range(1, 4);
        //foodAmountText.text = "" + foodAmount;
        //SnakeHead = GameObject.FindGameObjectWithTag("Head");
        //SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        //SnakeHeadCollider = SnakeHead.GetComponent<Collider>();
    }

    private void Awake()
    {
        foodAmount = Random.Range(1, 4);
        foodAmountText.text = "" + foodAmount;
        SnakeHead = GameObject.FindGameObjectWithTag("Head");
        SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        SnakeHeadCollider = SnakeHead.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == SnakeHeadCollider)
        {
            for(int i = foodAmount; i>=1; i--)
            {
                SnakeTail.AddCircle();
            }

            Destroy(this.gameObject);
        }
    }
}
