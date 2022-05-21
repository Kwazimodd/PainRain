using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GeneratorFacade : MonoBehaviour
{
    private List<IGenerator> generators = new List<IGenerator>();

    [SerializeField] private Tilemap topTilemap;
    [SerializeField] private Tilemap botTilemap;

    [SerializeField] private Dropdown modeDropdown;
    [SerializeField] private Dropdown biomsDropdown;

    private void Awake()
    {
        generators.Add(GetComponent<PlainsGenerator>());
        generators.Add(GetComponent<ForestGenerator>());
        generators.Add(GetComponent<SwampGenerator>());
    }

    public void SetEnableDropdown()
    {
        biomsDropdown.enabled = modeDropdown.value == 0;
    }

    public void Generate()
    {
        if (modeDropdown.value == 0)
        {
            GenerateOne();
        }
        else
        {
            GenerateAll();
        }
    }

    public void GenerateOne()
    {
        Generate(generators[biomsDropdown.value], true);
    }

    public void GenerateAll()
    {
        for (int i = 0; i < generators.Count; i++)
        {
            Generate(generators[i], false);
        }
    }

    public void Generate(IGenerator generator, bool clearTiles)
    {
        if (clearTiles)
        {
            topTilemap.ClearAllTiles();
            botTilemap.ClearAllTiles();
        }

        generator.GenerateGrass();
        generator.GenerateStuff();
        var biom = generator.GetBiom();
        Debug.Log($"{biom.Name} was generated");
    }
}
