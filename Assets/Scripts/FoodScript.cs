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

    //public GameObject ScoreGameText;    
    //public int ScorePlay = 0;
    //string scoreText;
    // Start is called before the first frame update
    void Start()
    {
        //foodAmount = Random.Range(1, 4);
        //foodAmountText.text = "" + foodAmount;
        //SnakeHead = GameObject.FindGameObjectWithTag("Head");
        //SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        //SnakeHeadCollider = SnakeHead.GetComponent<Collider>();
        //AudioSource audioSourseSH = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        foodAmount = Random.Range(1, 4);
        foodAmountText.text = "" + foodAmount;
        SnakeHead = GameObject.FindGameObjectWithTag("Head");
        SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        SnakeHeadCollider = SnakeHead.GetComponent<Collider>();
        audioSourseSH = SnakeHead.GetComponents<AudioSource>();

        //ScoreGameText = (UnityEngine.UI.Text)GameObject.FindGameObjectWithTag("PanelGame").GetComponent("Score");
        //ScoreGameText = GameObject.FindGameObjectWithTag("Score");
        //scoreText = ScoreGameText.GetComponent<UnityEngine.UI.Text>().text;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if(other == SnakeHeadCollider)
        {
            for(int i = foodAmount; i>=1; i--)
            {
                SnakeTail.AddCircle();
                //ScorePlay++;
                //scoreText = "Score " + ScorePlay;
                
                //ScoreGameText.GetComponent<UnityEngine.UI.Text>().text = "Score " + ScorePlay;
                //PlayerPrefs.SetInt("ScorePlay", ScorePlay);                
            }
            audioSourseSH[0].Play();
            Destroy(this.gameObject);
        }
    }
}
