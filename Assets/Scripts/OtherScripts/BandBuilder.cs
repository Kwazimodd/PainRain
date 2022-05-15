using System.Collections.Generic;
using UnityEngine;
public class BandBuilder : MonoBehaviour, IBuilder
{
    Band band = new Band();
    
    [SerializeField]
    List<GameObject> monsters = new List<GameObject>();


    public void Reset()
    {
        band = new Band();
    }

    public void BuildPartA()
    {
        band.Add(monsters[0]);
    }

    public void BuildPartB()
    {
        band.Add(monsters[1]);
    }

    public void BuildPartC()
    {
        band.Add(monsters[2]);
    }

    public void BuildPartD()
    {
        band.Add(monsters[3]);
    }

    public Band GetBand()
    {
        Band result = band;
        Reset();
        return result;
    }
}
