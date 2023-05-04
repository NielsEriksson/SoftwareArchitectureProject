using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    private Dictionary <Vector2, Plant> dataFromTiles;
    private List<Vector3> tileCoords;
    [SerializeField]Plant prefab;
    private void Start()
    {
        tileCoords = new List<Vector3>();
        dataFromTiles = new Dictionary<Vector2, Plant>();

        for (int n = tilemap.cellBounds.xMin; n < tilemap.cellBounds.xMax; n++) //get tiles coords in worldspace
        {
            for (int p = tilemap.cellBounds.yMin; p < tilemap.cellBounds.yMax; p++)
            {
                Vector3Int localPlace = (new Vector3Int(n, p, (int)tilemap.transform.position.y));
                Vector3 place = tilemap.CellToWorld(localPlace);
                if (tilemap.HasTile(localPlace))
                {
                    tileCoords.Add(place);
                }
            }
        }
        foreach (Vector3 v in tileCoords) //save all tiles and add a bool to them
        {
            dataFromTiles.Add(new Vector2(v.x,v.y), null);
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if (!GetTileIsFull())
            {
                //print(GetClickedTile() + " is not occupied yet");
                OccupyTile();
                SpawnPrefab(prefab); //to do; change the prefab to a plant
            }
            else
            {
                //print("is occupied");
                UnOccupyTile();
            }
        }
    }

    public bool GetTileIsFull()
    {
        Plant isFull;
        dataFromTiles.TryGetValue(GetTileWorldCoord(), out isFull);
        if(isFull == null) { return false; }
        return true;
    }
    private void OccupyTile()
    {
        dataFromTiles[GetTileWorldCoord()] = prefab;
    }
    public void UnOccupyTile()
    {
        dataFromTiles[GetTileWorldCoord()] = null;
        //to do : delete plant that is on the tile
    }
    private Vector2 GetTileWorldCoord()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        Vector2 pos = new Vector2((gridPosition.x+0.5f)*2, (gridPosition.y+0.5f)*2);
        return pos;
    }
    public void SpawnPrefab(Plant prefab)
    {
        Instantiate(prefab, GetTileWorldCoord(), Quaternion.identity);
    }

}
