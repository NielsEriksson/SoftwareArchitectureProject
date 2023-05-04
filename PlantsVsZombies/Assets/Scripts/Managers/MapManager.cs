using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    private Dictionary <Vector2, Plant> dataFromTiles;
    private List<Vector3> tileCoords;
    [SerializeField]Plant prefab;
    bool shovel;
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
        if(Input.GetMouseButtonDown(1)){
            if (!GetTileIsFull() && !shovel)
            {
                //print(GetClickedTile() + " is not occupied yet");
                OccupyTile();
                
            }
            else if (GetTileIsFull() && shovel)
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
        dataFromTiles[GetTileWorldCoord()] = SpawnPrefab(prefab);
    }
    public void UnOccupyTile()
    {
        Debug.Log("shoveling");
        Plant plant = dataFromTiles[GetTileWorldCoord()];
        dataFromTiles[GetTileWorldCoord()] = null;
        plant.Die();
        
        
        
        //to do : delete plant that is on the tile
    }
    private Vector2 GetTileWorldCoord()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        Vector2 pos = new Vector2((gridPosition.x+0.5f)*2, (gridPosition.y+0.5f)*2);
        return pos;
    }
    public Plant SpawnPrefab(Plant prefab)
    {
        Plant planty = Instantiate(prefab, GetTileWorldCoord(), Quaternion.identity);
        return planty;
    }

    public void ToggleShovel()
    {
        if (shovel) shovel = false;
        else shovel = true;
    }

}
