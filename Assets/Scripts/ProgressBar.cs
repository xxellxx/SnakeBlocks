using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public GameObject SnakeHead;
    //Transform FinishPlatform;
    public Slider ProgressSlider;
    float startZ = 1;
    float currentZ;
    float finishZ;
    public GameManagerScript GM;

    private void Awake()
    {
        //startZ = SnakeHead.transform.position.z;
        //FinishPlatform = GameObject.FindGameObjectWithTag("Finish").transform;
        //finishZ = GM.finishPlatformPositionZ;
    }

    private void Start()
    {
        //startZ = SnakeHead.transform.position.z;
        finishZ = GM.finishPlatformPositionZ;
    }

    private void Update()
    {
        if (GM.CurrentState == GameManagerScript.State.Playing)
        {
            currentZ = SnakeHead.transform.position.z;
            //finishZ = FinishPlatform.position.z;
            float t = Mathf.InverseLerp(startZ, finishZ, currentZ);
            ProgressSlider.value = t;

            //Debug.Log("FinishZ= "+finishZ   + " T= " + t + " currentZ= " + currentZ);
        }

        //currentZ = SnakeHead.transform.position.z;
        //float finishZ = FinishPlatform.position.z;
        //float t = Mathf.InverseLerp(startZ, finishZ, currentZ);
        //ProgressSlider.value = t;
    }
}
