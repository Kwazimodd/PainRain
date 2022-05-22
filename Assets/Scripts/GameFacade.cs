using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private static GameFacade instance;

    public static GameFacade Instance 
    {
        get
        {
            if (instance==null)
            {
                instance = FindObjectOfType<GameFacade>();
            }

            return instance;
        }
    }

    [SerializeField]
    private List<GameObject> monsterList;

    public List<GameObject> MonsterList { get => monsterList; }

    Director director;
    BandBuilder bandBuilder;

    private void Start()
    {
        director = new Director();
        bandBuilder = new BandBuilder();
        director.Builder = bandBuilder;
        InvokeRepeating(nameof(SpawnBand), 0, 10);
        InvokeRepeating(nameof(SpawnAsotiation), 0, 60);
    }

    private void SpawnBand()
    {
        Composite composite = new Composite();
        director.BuildRandomBand();
        composite.Add(bandBuilder.GetBand());
        composite.Create();
    }

    private void SpawnAsotiation()
    {
        Composite composite = new Composite();
        for (int i = 0; i < 4; i++)
        {
            director.BuildRandomBand();
            composite.Add(bandBuilder.GetBand());
        }
        composite.Create();
    }
}
