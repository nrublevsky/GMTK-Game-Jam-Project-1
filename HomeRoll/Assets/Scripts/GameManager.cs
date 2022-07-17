 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //universal data and objects
    public int score;

    public Text playerScore;
    public Text timeCounter;

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
        CheckFloor();
       
    }
    public void CheckFloor()
    {
        
    }
    
    //methods for start

    public void FindAll()
    {
        Player();
        Floor();
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
