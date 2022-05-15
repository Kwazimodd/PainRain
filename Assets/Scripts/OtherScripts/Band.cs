using System.Collections.Generic;
using UnityEngine;

public class Band : MonoBehaviour
{
    private List<GameObject> band = new List<GameObject>();

    public void Add (GameObject gameObject)
    {
        band.Add(gameObject);
    }

    public List<GameObject> GetBand()
    {
        return band;
    }
}
