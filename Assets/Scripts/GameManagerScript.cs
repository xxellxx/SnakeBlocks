using System.Collections;
using System.Collections.Generic;
using TMPro;
//using System.Windows.Controls;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    //public Canvas GameCanvas;
    public GameObject PanelStartMenu;
    public GameObject PanelGameOver;
    public GameObject PanelGame;
    
    public GameObject SnakeHead;
    public GameObject SnakeCountText;

    public List<GameObject> PlatformPrefabs;

    public GameObject FinishPlatform;

    public TextMeshProUGUI LevelIndexText;
    public TextMeshProUGUI ScoreText;

    public TextMeshProUGUI[] BestScores;



    public State CurrentState;
    public int levelIndex = 1;
    int score;
    int bestScore = 0;



    public int maxPlatforms = 3;
    public enum State
    {
        Start,
        Playing,
        Won,
        Loss
    }

    private void Awake()
    {
        if (levelIndex % 5 == 0 && levelIndex < 30)
        {
            maxPlatforms++;
        }
        
        for(int i = 0; i < maxPlatforms; i++)
        {
            Instantiate(PlatformPrefabs[Random.Range(0, PlatformPrefabs.Count)], new Vector3(0, -0.5f, (5 + i * 10)), Quaternion.identity);
            if(i == maxPlatforms - 1)
            {
                Instantiate(FinishPlatform, new Vector3(0, -0.5f, (0.5f + (i + 1) * 10)), Quaternion.identity);
            }
        }
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        for (int i = 0; i < BestScores.Length; i++)
        {
            BestScores[i].text = "Best score " + bestScore;
        }


        //for(int i = 0; i<PlatformPrefabs.Count; i++)
        //{
        //    Instantiate(PlatformPrefabs[i], new Vector3(0, -0.5f, (5 + i * 10)), Quaternion.identity);
        //}
    }
    public void OnPlayerDied()
    {        
        
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        PlayerPrefs.SetInt("GM", (int)State.Loss);
        levelIndex = 1;
        PlayerPrefs.SetInt("Level", levelIndex);
        PanelGame.SetActive(false);
        PanelGameOver.SetActive(true);
        PanelStartMenu.SetActive(false);
        Debug.Log("GameOver");

        SnakeHead.SetActive(false);
        SnakeCountText.SetActive(false);
        levelIndex = 1;
        LevelIndexText.text = "Level " + levelIndex;

        score = SnakeHead.GetComponent<SnakeTail>().score;
        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            for(int i = 0; i < BestScores.Length; i++)
            {
                BestScores[i].text = "Best score " + score;
            }
        }
        PlayerPrefs.SetInt("Score", 0);
    }

    public void OnPlayerRichedFinish()
    {
        levelIndex++;
        CurrentState = State.Won;
        PlayerPrefs.SetInt("Level", levelIndex);
        PlayerPrefs.SetInt("GM", (int)State.Won);
        PlayerPrefs.SetInt("Score", SnakeHead.GetComponent<SnakeTail>().score);
        ReloadLevel();
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnPlayerStart()
    {
        CurrentState = (State)PlayerPrefs.GetInt("GM");

        if (CurrentState == State.Start)
        {
            levelIndex = PlayerPrefs.GetInt("Level", 1);
            LevelIndexText.text = "Level " + levelIndex;
            PanelGame.SetActive(true);
            PanelGameOver.SetActive(false);
            PanelStartMenu.SetActive(false);
            CurrentState = State.Playing;
            
            PlayerPrefs.SetInt("GM", (int)State.Playing);
            SnakeHead.SetActive(true);
            SnakeCountText.SetActive(true);
            SnakeHead.GetComponent<SnakeTail>().score = PlayerPrefs.GetInt("Score");
        }
        else if(CurrentState == State.Loss)
        {
            //CurrentState = State.Start;
            //PlayerPrefs.SetInt("GM", (int)State.Start);
            ReloadLevel();
        }
        else if(CurrentState == State.Won)
        {
            ReloadLevel();
        }
    }

    private void Start()
    {
        CurrentState = (State)PlayerPrefs.GetInt("GM");
        LevelIndexText.text = "Level " + levelIndex;

        if (CurrentState == State.Start)
        {
            PanelGame.SetActive(false);
            PanelGameOver.SetActive(false);
            PanelStartMenu.SetActive(true);
            SnakeHead.SetActive(false);
            SnakeCountText.SetActive(false);
        }
        else if(CurrentState == State.Loss)
        {
            //OnPlayerStart();
            PlayerPrefs.SetInt("GM", (int)State.Start);
            OnPlayerStart();
        }
        else if(CurrentState == State.Won)
        {
            CurrentState = State.Start;
            PlayerPrefs.SetInt("GM", (int)State.Start);
            OnPlayerStart();
        }

    }
}
