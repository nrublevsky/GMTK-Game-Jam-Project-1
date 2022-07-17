using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public int tileState;
    public bool tilePresent;

    public GameObject dice;

    public MeshRenderer tileRenderer;

    public DiceSideBehavior sideBehavior;


    void Start()
    {
        tilePresent = true;
        dice = GameObject.Find("Player");
               
        sideBehavior = dice.GetComponentInChildren<DiceSideBehavior>();

        tileRenderer = GetComponent<MeshRenderer>();
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

    public void SetUpTile()
    {

        switch (tileState)
        {
            case 0:
                
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:

                break;
            case 4:

                break;
            case 5:

                break;
            default:

                break;
        }
    }
    public void CheckState()
    {
        
    }

}
