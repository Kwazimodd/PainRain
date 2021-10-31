using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TreeTile : Tile
{
    public override bool StartUp(Vector3Int position, ITilemap tilemap, GameObject go)
    {
        if (go!=null)
        {
            go.GetComponent<SpriteRenderer>().sortingOrder = -position.y * 2;
        }
        return base.StartUp(position, tilemap, go);
    }
}
