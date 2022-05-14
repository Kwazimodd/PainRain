using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ForestBiom : IBiom
{
    public string Name { get; set; }

    public void Render()
    {
        Debug.Log($"{Name} biom is rendering");
    }
}
