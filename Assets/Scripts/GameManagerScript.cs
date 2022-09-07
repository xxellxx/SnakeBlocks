using System.Collections;
using System.Collections.Generic;
//using System.Windows.Controls;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    //public Canvas GameCanvas;
    public GameObject PanelStartMenu;
    public GameObject PanelGameOver;
    public GameObject PanelGame;
    
    public GameObject SnakeHead;
    public GameObject SnakeCountText;
    

    //public Scene PlayScene;
    public State CurrentState;
    public int levelIndex = 0;
    public enum State
    {
        Start,
        Playing,
        Won,
        Loss
    }

    public void OnPlayerDied()
    {        
        
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        PanelGame.SetActive(false);
        PanelGameOver.SetActive(true);
        PanelStartMenu.SetActive(false);
        Debug.Log("GameOver");

        SnakeHead.SetActive(false);
        SnakeCountText.SetActive(false);
    }

    public void OnPlayerRichedFinish()
    {

    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPlayerStart()
    {
        if (CurrentState == State.Start)
        {
            PanelGame.SetActive(true);
            PanelGameOver.SetActive(false);
            PanelStartMenu.SetActive(false);
            CurrentState = State.Playing;
            SnakeHead.SetActive(true);
            SnakeCountText.SetActive(true);
        }
        else if(CurrentState == State.Loss)
        {
            CurrentState = State.Start;
            ReloadLevel();
        }
    }

    private void Start()
    {
        if (CurrentState != State.Start) return;
        PanelGame.SetActive(false);
        PanelGameOver.SetActive(false);
        PanelStartMenu.SetActive(true);
        SnakeHead.SetActive(false);
        SnakeCountText.SetActive(false);


    }
}
