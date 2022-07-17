using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehavior : MonoBehaviour
{
    public int tileState;
    public bool tilePresent;

    public GameObject dice;

    public Renderer tileRenderer;

    public DiceSideBehavior sideBehavior;


    void Start()
    {
        tilePresent = true;
        dice = GameObject.Find("Player");
               
        sideBehavior = dice.GetComponentInChildren<DiceSideBehavior>();

        tileRenderer = GetComponent<MeshRenderer>();

        SetUpTile();
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
            else
            {
                tilePresent = false;
                Debug.Log("blop");
            }
        }
        
    }

    public void SetUpTile()
    {

        if (tileState == 1)
        {
            tileRenderer.material.color = new Color32(174, 255, 165, 255);
        }
        if (tileState == 2)
        {
            tileRenderer.material.color = new Color32(248, 255, 95, 255);
        }
        if (tileState == 3)
        {
            tileRenderer.material.color = new Color32(255, 149, 124, 255);
        }
        if (tileState == 4)
        {
            tileRenderer.material.color = new Color32(255, 133, 229, 255);
        }
        if (tileState == 5)
        {
            tileRenderer.material.color = new Color32(153, 136, 255, 255);
        }
        if (tileState == 6)
        {
            tileRenderer.material.color = new Color32(85, 255, 237, 255);
        }
    }
    public void CheckState()
    {
        
    }

}
