using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private TileManager tileManager;

    public GridLayout gridLayout;
    public List<Tile> neighborTiles;
    public Vector3Int cellPosition;

    private void Start()
    {
        tileManager = TileManager.instance;

        gridLayout = transform.parent.GetComponent<GridLayout>();
        cellPosition = gridLayout.WorldToCell(transform.position);

        //use Invoke() to avoid errors where CheckForNeighbors() will
        //finish running before all the tiles have their coordinates assigned.
        Invoke("CheckForNeighbors", 1);
    }

    public void CheckForNeighbors()
    {
        //checks the coordinates of all the tiles in the "allTiles" list.
        //if the x or y coordinates are + or - 1, the tile is added to this tiles
        //individual list of neighboring tiles.
        foreach (Tile tile in tileManager.allTiles)
        {
            if (Mathf.Abs(tile.cellPosition.x - cellPosition.x) == 1 && tile.cellPosition.y == cellPosition.y
                || Mathf.Abs(tile.cellPosition.y - cellPosition.y) == 1 && tile.cellPosition.x == cellPosition.x)
            {
                neighborTiles.Add(tile);
            }           
        }
    }

    //this is an example of how you would run code on the neighbors of an individual tile
    public void runCodeOnNeighbors()
    {
        foreach (Tile tile in neighborTiles)
        {
            //your code here!
        }
    }

}
