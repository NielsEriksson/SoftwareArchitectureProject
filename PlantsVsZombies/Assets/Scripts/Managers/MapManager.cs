using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    private Dictionary <TileBase, bool> dataFromTiles;
    private TileBase clickedTile;

    void Awake(){
        dataFromTiles = new Dictionary<TileBase, bool>();   //init dic
        BoundsInt bounds = tilemap.cellBounds;              //get bounds
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);//save array of tiles
        foreach (TileBase tile in allTiles)
        {
            if (tile == null) return;
            dataFromTiles.Add(tile, false);                 //save info in dic with all bools being false0
        }
    }
    private void Update()
    {
        clickedTile = GetClickedTile();
        if(Input.GetMouseButtonDown(0)){
            if (!GetTileIsFull())
            {
                print(clickedTile + " is not occupied yet");
                OccupyTile();
            }
            else print("is occupied");
        }
    }

    public bool GetTileIsFull (){
        bool isFull;
        dataFromTiles.TryGetValue(clickedTile, out isFull);
        return isFull;
    }
    private TileBase GetClickedTile()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        TileBase clickedTile = tilemap.GetTile(gridPosition);
        return clickedTile;
    }
    private void OccupyTile()
    {
        dataFromTiles[clickedTile] = true;
    }
    
}
