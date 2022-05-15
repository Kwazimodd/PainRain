using UnityEngine;
public class SwampBiom : IBiom
{
    public string Name { get; set; }

    public void Render()
    {
        Debug.Log($"{Name} biom is rendering");
    }
}
