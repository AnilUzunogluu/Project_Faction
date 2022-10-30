using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{

    [SerializeField][Tooltip("Set tilemap named ARENA on the grid.")] private Tilemap arena;
    [SerializeField][Tooltip("Place corresponding TileDatas according to used tiles in the arena.")] private List<TileData> tileDatas;

    private Dictionary<TileBase, TileData> _dataFromTiles;

    private Camera _camera;

    private void Awake()
    {
        //Creates the dictionary to contain all the information on individual tiles used in the arena.
        _dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (var tileData in tileDatas)
        {
            foreach (var tile in tileData.tiles)
            {
                _dataFromTiles.Add(tile, tileData);
            }
        }
    }

    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = arena.WorldToCell(mousePosition);

            TileBase clickedTile = arena.GetTile(gridPosition);

            float moveSpeed = _dataFromTiles[clickedTile].SpeedMultiplier;

            Debug.Log($"movespeed on this {clickedTile} tile is {moveSpeed}");
        }
    }

    public float GetSpeedMultiplier(Vector2 worldPosition)
    {
        Vector3Int gridPosition = arena.WorldToCell(worldPosition);

        TileBase tile = arena.GetTile(gridPosition);

        return _dataFromTiles[tile].SpeedMultiplier;
    }
}
