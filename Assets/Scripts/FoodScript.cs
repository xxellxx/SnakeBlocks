using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    int foodAmount;
    public TextMeshPro foodAmountText;
    GameObject SnakeHead;
    SnakeTail SnakeTail;
    Collider SnakeHeadCollider;
    AudioSource[] audioSourseSH = null; 

    private void Awake()
    {
        foodAmount = Random.Range(1, 4);
        foodAmountText.text = "" + foodAmount;
        SnakeHead = GameObject.FindGameObjectWithTag("Head");
        SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        SnakeHeadCollider = SnakeHead.GetComponent<Collider>();
        audioSourseSH = SnakeHead.GetComponents<AudioSource>();       
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other == SnakeHeadCollider)
        {
            for(int i = foodAmount; i>=1; i--)
            {
                SnakeTail.AddCircle();                                
            }
            audioSourseSH[0].Play();
            Destroy(this.gameObject);
        }
    }
}
