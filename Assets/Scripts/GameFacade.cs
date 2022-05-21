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

    //add new possible items
}
