using UnityEngine;
using UnityEngine.Tilemaps;

public class SwampGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private Tile tile;
    [SerializeField] private Tile[] swampStuff;

    [SerializeField] private int minRows;
    [SerializeField] private int maxRows;

    [SerializeField] private int minParts;
    [SerializeField] private int maxParts;

    [SerializeField] private int treeChance;
    [SerializeField] private int padding;

    [SerializeField] private Tilemap topTilemap;
    [SerializeField] private Tilemap botTilemap;

    public IBiom GenerateBiom()
    {
        SwampBiom swampBiom = new SwampBiom() { Name = "Swamp" };
        swampBiom.Render();

        var rows = Random.Range(minRows, maxRows);
        var parts = Random.Range(minParts, maxParts);
        var offset = Random.Range(0, minParts);

        Vector2 center = new Vector2(0, rows / 2);

        for (int i = 0; i < rows; i++)
        {

            for (int j = -offset; j < parts + offset; j++)
            {
                botTilemap.SetTile(new Vector3Int(j, i, 0), tile);
            }

            if (i <= rows / 2)
            {
                offset = Random.Range(offset, offset + 5);
            }
            else
            {
                offset = Random.Range(offset - 5, offset);
            }
        }

        for (int i = padding; i < rows; i++)
        {
            for (int j = -padding; j < parts-padding; j++)
            {
                if (Random.Range(0, 100) < treeChance)
                {
                    var index = Random.Range(0, swampStuff.Length - 1);
                    topTilemap.SetTile(new Vector3Int(j, i, 0), swampStuff[index]);
                }
            }
        }

        return swampBiom;
    }
}
