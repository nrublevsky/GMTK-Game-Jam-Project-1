 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //universal data and objects
    public Text timeCounter;
    public Text finishText;
    public Button nextLevel;
    public Button quitGame;
    public Button restartGame;

    public float gameTime;

    public bool gameRunning;

    public string currentSceneName;

    //level data and objects
    public GameObject player;

    public int playerLives;

    public GameObject floor;

    public int tilesLeft;
    
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {

        }
        if (SceneManager.GetActiveScene().name == "MainLevel")
        {
            FindAll();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartMenu")
        {

        }
        if (SceneManager.GetActiveScene().name == "MainLevel")
        {
            ControlSituation();
        }
        
    }
    //methods for update
    public void ControlSituation() 
    {
        
        if (gameRunning)
        {
            CheckFloor(GetFloor());
            UpdateTimer(gameTime);
        }
        if (!gameRunning)
        {
            UpdateUI();
        }    
    }

    public GameObject GetFloor()
    {
        return floor;
    }

    public void UpdateTimer(float time)
    {
        timeCounter.text = "Time Left: "+time;
    }
    public void CheckFloor(GameObject floor)
    {
        FloorManager flManager = floor.GetComponent<FloorManager>();
        tilesLeft = flManager.tilesList.Count;
        if (tilesLeft < 64)
        {
            TimeCooldownRunning();
        }
        if (tilesLeft < 1)
        {
            gameRunning = false;
        }
    }

    public void UpdateUI()
    {     
        
        if (!gameRunning)
        {
            timeCounter.gameObject.SetActive(false);
            float gTToDisplay = gameTime%1;
            finishText.text = "Good Job! We Are very proud of you =* \n Your remaining time: " + gTToDisplay;
            finishText.gameObject.SetActive(true);
            restartGame.gameObject.SetActive(true);
            quitGame.gameObject.SetActive(true);
        }
    }

    public void TimeCooldownRunning()
    {
        if (gameRunning)
        {
            StartCoroutine(TimeDecrease(gameTime));
        }
        if (!gameRunning)      
        {
            
        }
    }

    public IEnumerator TimeDecrease(float time)
    {
        
            if (time > 0f)
            {                
                yield return new WaitForSecondsRealtime(0.1f);
                time -= 0.1f;
                gameTime = time;               
            }
            if (time <= 0f)
            {
                gameRunning = false;               
            }
                   
    }
    
    //methods for start

    public void FindAll()
    {
        SetUpGame();
        Player();
        Floor();
    } 

    public void SetUpGame()
    {
        gameRunning = true;

        gameTime = 15.00f;
                
        finishText.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(false);
        restartGame.gameObject.SetActive(false);
        quitGame.gameObject.SetActive(false);
    }

    public GameObject Player()
    {
        player = GameObject.FindWithTag("Player");
        return player;
    } 


    public GameObject Floor()
    {
        floor = GameObject.FindWithTag("Floor");
        return floor;
    }

    public int TilesLeft(GameObject floorObject)
    {
        floorObject = floor;
        int tiles = floorObject.GetComponent<int>();
        return tilesLeft;
    }
    //serialized data and methods

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit() 
    {
    Application.Quit();
    }
}
