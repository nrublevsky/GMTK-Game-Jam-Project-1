using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public int tileState;

    public GameObject dice;

    public DiceSideBehavior sideBehavior;


    void Start()
    {
        dice = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        
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
