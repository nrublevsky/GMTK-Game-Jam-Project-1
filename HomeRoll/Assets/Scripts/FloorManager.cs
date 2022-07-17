using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public List<GameObject> tilesList;
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
        RemoveTile();  
    }

    public void GatherTiles()
    {
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("FloorTile");
        Debug.Log("Available Tiles = " + tiles.Length);

        for (int i = 0; i < tiles.Length; i++)
        {
            GameObject tile = tiles[i];
            tilesList.Add(tile);
        }

        Debug.Log("Available Tiles = " + tilesList.Count);
    }

    public void RemoveTile()
    {
        foreach (var tile in tilesList)
        {
            if (tile.gameObject != null)
            { 
                tilesState = tile.GetComponent<TileBehavior>();
                if (tilesState.tilePresent != true)
                {
                    Destroy(tile);
                   
                }
                else
                {
                
                }
            }
            else
            {
                tilesList.Remove(tile);
            }
        }
    }
}
