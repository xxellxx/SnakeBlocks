using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    
    int blockAmount;
    public TextMeshPro blockAmountText;    
    GameObject SnakeHead;
    SnakeTail SnakeTail;
    GameManagerScript GM;
    AudioSource[] audioSourseSH = null;
    ParticleSystem BlockParticle;    
    Renderer rend;

   
    

    private void Awake()
    {
        blockAmount = Random.Range(1, 4);
        blockAmountText.text = "" + blockAmount;        
        SnakeHead = GameObject.FindGameObjectWithTag("Head");
        SnakeTail = SnakeHead.GetComponent<SnakeTail>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
        audioSourseSH = SnakeHead.GetComponents<AudioSource>();        
        BlockParticle = Object.FindObjectOfType<ParticleSystem>();
        float colorSet = Mathf.InverseLerp(3f, 1f, blockAmount);
        Debug.Log("colorSet= "+colorSet);
        rend = GetComponent<Renderer>();
        rend.material.SetFloat("_FloatColor", colorSet);
        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == SnakeHead.transform)
        {            
            for (int i = blockAmount; i >= 1; i--)
            {                
                if(i >= SnakeTail.snakeCount)
                {
                    GM.OnPlayerDied();
                    StartCoroutine(DestroyBlock());
                    return;
                }
                SnakeTail.RemoveCircle();
            }
            audioSourseSH[1].Play();
            BlockParticle.Play();
            StartCoroutine(DestroyBlock());
        }
    }
    
    IEnumerator DestroyBlock()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }


}
