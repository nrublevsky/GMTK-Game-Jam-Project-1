 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //universal data and objects
    public Time timeCountdown;
    public Text timeCounter;
    public Text finishText;
    public Button nextLevel;

    public bool gameRunning;

    //level data and objects
    public GameObject player;

    public int playerLives;

    public GameObject floor;

    public int tilesLeft;
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (tilesLeft < 1)
        {
            gameRunning = false;
        }
    }

    public void UpdateUI()
    {
        
        if (!gameRunning)
        {
            

            finishText.gameObject.SetActive(true);
            nextLevel.gameObject.SetActive(true);
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
                
        finishText.gameObject.SetActive(false);
        nextLevel.gameObject.SetActive(false);
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
