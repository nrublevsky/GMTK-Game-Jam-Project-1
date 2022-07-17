using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public int tileState;
    public bool tilePresent;

    public GameObject dice;

    public DiceSideBehavior sideBehavior;


    void Start()
    {
        tilePresent = true;
        dice = GameObject.Find("Player");
        
        
        sideBehavior = dice.GetComponentInChildren<DiceSideBehavior>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.tag == "SideTile")
        {
            sideBehavior = collision.gameObject.GetComponentInChildren<DiceSideBehavior>();
            if (sideBehavior.sideNum == tileState)
            {
                Debug.Log("blip");
                tilePresent = false;
            }
            Debug.Log("blip");
            tilePresent = false;
        }
        if (gameObject.tag == "Destroyer")
        {
            Debug.Log("blop");
        }
    }
    public void CheckState()
    {
        switch (tileState)
        {
            case 0:
                
            case 1:
                SetFireTile();
                break;
            case 2:

            case 3:
                SetWaterTile();
                break;
            case 4:

            case 5:
                SetAirTile();
                break;
            case 6:

            case 7:
                SetGroundTile();
                break;
            case 8:

            case 9:
                SetWoodTile();
                break;
            case 10:

            case 11:
                SetIceTile();
                break;
            case 12:
                SetLavaTile();
                break;
            case 13:
                
            case 14:
                SetVoidTile();
                break;
            case 15:    

                break;
                
        }
        
    }
    public void SetFireTile()
    {

    }
    public void SetWaterTile()
    {

    }
    public void SetAirTile()
    {

    }
    public void SetGroundTile()
    {

    } 
    public void SetWoodTile()
    {

    } 
    public void SetIceTile()
    {

    }
    public void SetLavaTile()
    {

    }
    public void SetVoidTile()
    {

    }
}
