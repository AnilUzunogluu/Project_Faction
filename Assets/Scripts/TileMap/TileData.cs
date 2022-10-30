using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "Tile Data", menuName = "New Tile Data", order = 51)]
public class TileData : ScriptableObject
{
    [SerializeField] public List<TileBase> tiles;
    
    [SerializeField] private float speedMultiplier;
    [SerializeField] private bool isPlaceable;
    public float SpeedMultiplier => speedMultiplier;
    public bool IsPlaceable => isPlaceable;
}
