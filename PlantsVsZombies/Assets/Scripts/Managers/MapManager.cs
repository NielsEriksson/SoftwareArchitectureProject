using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class MapManager : MonoBehaviour
{
    private Dictionary <Vector2, Plant> dataFromTiles;
    private List<Vector3> tileCoords;
    private bool shovel;
    [SerializeField] private float gridScale;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private Plant prefab;
    [SerializeField] GameObject shovelButtonImage;
    [SerializeField] Texture2D shovelMouseTexture;
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
        foreach (Vector3 v in tileCoords) //save all tiles and add a flower to them
        {
            dataFromTiles.Add(new Vector2(v.x,v.y), null);
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            //if (!GetTileIsFull() && !shovel)
            //{
            //    OccupyTile();
            //}
            //else
            if (GetTileIsFull() && shovel)
            {
                UnOccupyTile();
            }
        }
    }

    public bool GetTileIsFull()
    {
        Plant isFull;
        dataFromTiles.TryGetValue(GetTilePosInDic(), out isFull);
        if(isFull == null) { return false; }
        return true;
    }
    public bool OccupyTile(Plant plant)
    {
        if (dataFromTiles.ContainsKey(GetTilePosInDic())){ //check if this tile is in dic
            dataFromTiles[GetTilePosInDic()] = SpawnPrefab(plant); 
            return true;
        }
        return false;
    }
    public void UnOccupyTile()
    {
        Plant plant = dataFromTiles[GetTilePosInDic()];
        dataFromTiles[GetTilePosInDic()] = null;
        plant.Die();
    }
    private Vector2 GetTilePosWithOffset()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        Vector2 pos = new Vector2((gridPosition.x+0.5f)*1.75f, (gridPosition.y+0.5f)*1.75f);
        return pos;
    }
    private Vector2 GetTilePosInDic()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);
        Vector2 pos = new Vector2(gridPosition.x * 1.75f, gridPosition.y * 1.75f);
        return pos;
    }

    public Plant SpawnPrefab(Plant prefab)
    {
        Plant planty = Instantiate(prefab, GetTilePosWithOffset(), Quaternion.identity);
        return planty;
    }

    public void ToggleShovel()
    {
        if (shovel)
        {
            shovel = false;
            shovelButtonImage.SetActive(true);
            Cursor.SetCursor(default, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            shovel = true;
            shovelButtonImage.SetActive(false);
            Cursor.SetCursor(shovelMouseTexture, Vector2.zero, CursorMode.Auto);
            int i = 0;
        }
    }
    public void ClearGrid()
    {
        for(int i = 0; i <tileCoords.Count; i++) 
        {
            if (dataFromTiles[tileCoords[i]]!= null)
            {
                dataFromTiles[tileCoords[i]].Die();
                dataFromTiles[tileCoords[i]] = null;
            }
        }
    }
}
