using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    GameObject SnakeHead;
    Collider SnakeHeadCollider;
    GameManagerScript GM;

    private void Awake()
    {
        SnakeHead = GameObject.FindGameObjectWithTag("Head");
        SnakeHeadCollider = SnakeHead.GetComponent<Collider>();
        GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManagerScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other == SnakeHeadCollider)
        {
            GM.OnPlayerRichedFinish();
        }
    }
}

