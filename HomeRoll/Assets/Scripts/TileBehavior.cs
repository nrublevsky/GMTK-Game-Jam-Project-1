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
            case 1:
                tileRenderer.material.color = new Color(174,255,165);
                break;
            case 2:
                tileRenderer.material.color = new Color(248, 255, 95);
                break;
            case 3:
                tileRenderer.material.color = new Color(255, 149, 124);
                break;
            case 4:
                tileRenderer.material.color = new Color(255, 133, 229);
                break;
            case 5:
                tileRenderer.material.color = new Color(153, 136, 255);
                break;
            case 6:
                tileRenderer.material.color = new Color(85, 255, 237);
                break;
            default:

                break;
        }
    }
    public void CheckState()
    {
        
    }

}
