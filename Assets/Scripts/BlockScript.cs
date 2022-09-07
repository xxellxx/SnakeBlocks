using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    // Start is called before the first frame update
    int blockAmount;
    public TextMesh blockAmountText;    
    GameObject SnakeHead;
    SnakeTail SnakeTail;
    GameManagerScript GM;
    //Collider SnakeHeadCollider;
    void Start()
    {
        //blockAmount = Random.Range(1, 4);
        //blockAmountText.text = "" + blockAmount;
        //SnakeHead = GameObject.FindGameObjectWithTag("Head");
        //SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        //GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        
    }

    private void Awake()
    {
        blockAmount = Random.Range(1, 4);
        blockAmountText.text = "" + blockAmount;
        SnakeHead = GameObject.FindGameObjectWithTag("Head");
        SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == SnakeHead.transform)
        {            
            for (int i = blockAmount; i >= 1; i--)
            {                
                if(i >= blockAmount)
                {
                    GM.OnPlayerDied();
                    StartCoroutine(DestroyBlock());
                    return;
                }
                SnakeTail.RemoveCircle();
            }

            StartCoroutine(DestroyBlock());
        }
    }
    
    IEnumerator DestroyBlock()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }


}
