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

    public Tilemap TopTilemap { get; set; }
    public Tilemap BotTilemap { get; set; }

    private int rows;
    private int parts;
    private int offset;

    public void GenerateGrass()
    {
        rows = Random.Range(minRows, maxRows);
        parts = Random.Range(minParts, maxParts);
        offset = Random.Range(0, minParts);

        for (int i = 0; i < rows; i++)
        {

            for (int j = -offset; j < parts + offset; j++)
            {
                BotTilemap.SetTile(new Vector3Int(j, i, 0), tile);
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
    }

    public void GenerateStuff()
    {
        for (int i = padding; i < rows; i++)
        {
            for (int j = -padding; j < parts - padding; j++)
            {
                if (Random.Range(0, 100) < treeChance)
                {
                    var index = Random.Range(0, swampStuff.Length - 1);
                    TopTilemap.SetTile(new Vector3Int(j, i, 0), swampStuff[index]);
                }
            }
        }
    }

    public IBiom GetBiom()
    {
        SwampBiom swampBiom = new SwampBiom() { Name = "Swamp" };
        swampBiom.Render();

        return swampBiom;
    }
}
