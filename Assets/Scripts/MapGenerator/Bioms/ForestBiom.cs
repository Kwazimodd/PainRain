using UnityEngine;

public class ForestBiom : IBiom
{
    public string Name { get; set; }

    public void Render()
    {
        Debug.Log($"{Name} biom is rendering");
    }
}