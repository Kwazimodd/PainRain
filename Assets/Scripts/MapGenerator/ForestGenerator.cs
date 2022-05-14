using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ForestGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private Tile tile;
    [SerializeField] private Tile[] treeTiles;

    [SerializeField] private int radius;
    [SerializeField] private float padding;
    [SerializeField] private int spawnTreeChance;

    [SerializeField] private Tilemap topTilemap;
    [SerializeField] private Tilemap botTilemap;
    public IBiom GenerateBiom()
    {
        ForestBiom forestBiom = new ForestBiom() { Name = "Forest" };
        forestBiom.Render();

        Vector2 center = new Vector2(radius - 0.5f, radius - 0.5f);

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

        //adding stuff
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

        return forestBiom;
    }
}
