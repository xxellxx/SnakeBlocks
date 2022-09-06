using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    int foodAmount;
    public TextMesh foodAmountText;
    public Collider SnakeHead;
    public SnakeTail SnakeTail;
    // Start is called before the first frame update
    void Start()
    {
        foodAmount = Random.Range(1, 4);
        foodAmountText.text = "" + foodAmount; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == SnakeHead)
        {
            for(int i = foodAmount; i>=1; i--)
            {
                SnakeTail.AddCircle();
            }

            Destroy(this.gameObject);
        }
    }
}
