using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class GeneratorFacade : MonoBehaviour
{
    private List<IGenerator> generators = new List<IGenerator>();

    [SerializeField] private Tilemap topTilemap;
    [SerializeField] private Tilemap botTilemap;

    [SerializeField] private Dropdown dropdown;

    private void Start()
    {
        generators.Add(GetComponent<PlainsGenerator>());
        generators.Add(GetComponent<ForestGenerator>());
        generators.Add(GetComponent<SwampGenerator>());
    }

    public void StartGenerate()
    {
        Generate(generators[dropdown.value]);
    }

    public void Generate(IGenerator generator)
    {
        topTilemap.ClearAllTiles();
        botTilemap.ClearAllTiles();

        var biom = generator.GenerateBiom();
        Debug.Log($"{biom.Name} was generated");
        
    }
}
