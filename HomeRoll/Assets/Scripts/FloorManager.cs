using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject[] tilesList;
    public TileBehavior tilesState;

    public int availableTiles;
    // Start is called before the first frame update
    void Start()
    {
        GatherTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GatherTiles()
    {
        tilesList = GameObject.FindGameObjectsWithTag("FloorTile");
        Debug.Log("Available Tiles = " + tilesList.Length);
    }

    public void RemoveTile()
    {
        foreach (var tile in tilesList)
        {
            tilesState = tile.GetComponent<TileBehavior>();
            if (tilesState.tilePresent == true)
            {
                break;
            }
            else
            {
                Destroy(tile.gameObject);
            }
        }
    }
}
