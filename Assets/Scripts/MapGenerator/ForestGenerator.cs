using UnityEngine;
using UnityEngine.Tilemaps;

public class ForestGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private Tile tile;
    [SerializeField] private Tile[] treeTiles;

    [SerializeField] private int radius;
    [SerializeField] private float padding;
    [SerializeField] private int spawnTreeChance;
    public Tilemap TopTilemap { get; set; }
    public Tilemap BotTilemap { get; set; }
    private Vector2 center => new Vector2(radius - 0.5f, radius - 0.5f);

    public IBiom GetBiom()
    {
        ForestBiom forestBiom = new ForestBiom() { Name = "Forest" };
        forestBiom.Render();

        return forestBiom;
    }

    public void GenerateGrass()
    {
        //drawing circle
        for (int i = 0; i < (2 * radius); i++)
        {
            for (int j = 0; j < (2 * radius); j++)
            {
                if (Vector2.Distance(new Vector2(j, i), center) < radius - 0.5f)
                {
                    botTilemap.SetTile(new Vector3Int(j, i, 0), tile);
                }
            }
        }
    }

    public void GenerateStuff()
    {
        for (int i = 0; i < (2 * radius); i++)
        {
            for (int j = 0; j < (2 * radius); j++)
            {
                if (Vector2.Distance(new Vector2(j, i), center) < radius - 0.5f - padding)
                {
                    if (Random.Range(0, 100) < spawnTreeChance)
                    {
                        var treeIndex = Random.Range(0, treeTiles.Length - 1);
                        topTilemap.SetTile(new Vector3Int(j, i, 0), treeTiles[treeIndex]);
                    }
                }
            }
        }
    }
}
