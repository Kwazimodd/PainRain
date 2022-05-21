using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlainsGenerator : MonoBehaviour, IGenerator
{
    [SerializeField] private Tile tile;
    [SerializeField] private Tile bush;

    [SerializeField] private int bushChance;
    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private int borderX;
    [SerializeField] private int borderY;

    [SerializeField] private Tilemap topTilemap;
    [SerializeField] private Tilemap botTilemap;

    public void GenerateGrass()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                botTilemap.SetTile(new Vector3Int(j, i, 0), tile);
            }
        }
    }

    public void GenerateStuff()
    {
        for (int i = borderY; i < height - borderY; i++)
        {
            for (int j = borderX; j < width - borderX; j++)
            {
                if (Random.Range(0, 200) < bushChance)
                {
                    topTilemap.SetTile(new Vector3Int(j, i, 0), bush);
                }
            }
        }
    }

    public IBiom GetBiom()
    {
        PlainsBiom plainsBiom = new PlainsBiom() { Name = "Plains" };
        plainsBiom.Render();

        return plainsBiom;
    }
}
