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
    public SnakeMovement SM;

    //public Scene PlayScene;
    public State CurrentState;
    public int levelIndex = 0;
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public void OnPlayerDied()
    {
        SM.enabled = false;
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        PanelGame.SetActive(false);
        PanelGameOver.SetActive(true);
        PanelStartMenu.SetActive(false);
        Debug.Log("GameOver");
        
    }

    public void OnPlayerRichedFinish()
    {

    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
       
    }
}
