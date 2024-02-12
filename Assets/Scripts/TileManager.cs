using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    #region SINGLETON FOR MANAGER
    //this is a singleton for the TileManager instance!
    public static TileManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one TileManager in scene!");
            return;
        }
        instance = this;
        Debug.Log("Instance achived: TileManager");
    }
    #endregion

    //a list of all the tiles in the scene.
    public List<Tile> allTiles;

    //assign your tilemap to this transform in the inspector!
    public Transform tileParent; 
    
    //identifier for what tile will be added to the allTiles list next
    private Tile tileToAdd;

    private void Start()
    {  
        //this goes through of all the child objects with the Tile script
        //attached to the tileParent transform. if it has a Tile script,
        // it is added to the allTiles list! if it doesn't, it is ignored.
        foreach (Transform child in tileParent)
        {
            tileToAdd = child.GetComponent<Tile>();
            allTiles.Add(tileToAdd);
        }
    }
}
