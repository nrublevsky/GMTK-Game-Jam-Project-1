 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //universal data and objects
    public Time timeCountdown;
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
        if (SceneManager.GetActiveScene().name == "Menu")
        {

        }
        if (SceneManager.GetActiveScene().name == "Level1")
        {

        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {

        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {

        }
        FindAll();
        


    }

    // Update is called once per frame
    void Update()
    {
        ControlSituation();
    }
    //methods for update
    public void ControlSituation() 
    {
        
        if (gameRunning)
        {
            CheckFloor(GetFloor());
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
            finishText.gameObject.SetActive(true);
            nextLevel.gameObject.SetActive(true);
        }
    }

    public void TimeCooldownRunning()
    {
        if (gameRunning)
        {
            StartCoroutine(TimeDecrease(gameTime));
        }
        else
        {
            StopAllCoroutines();
        }
    }

    public IEnumerator TimeDecrease(float time)
    {
        while (time != 0f)
        {
            Debug.Log(time);
            yield return new WaitForSeconds(0.01f);
            time -= 0.01f;
            gameTime = time;
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
}
