using UnityEngine;
using UnityEngine.Tilemaps;

public class PlainsBiom : IBiom
{
    public string Name { get; set; }

    public void Render()
    {
        Debug.Log($"{Name} biom is rendering");
    }
}
