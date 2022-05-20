using System.Collections.Generic;
using UnityEngine;
public class BandBuilder : MonoBehaviour, IBuilder
{
    Band band = new Band();


    public void Reset()
    {
        band = new Band();
    }

    public void BuildPartA()
    {
        band.Add(GameFacade.Instance.MonsterList[0]);
    }

    public void BuildPartB()
    {
        band.Add(GameFacade.Instance.MonsterList[1]);
    }

    public void BuildPartC()
    {
        band.Add(GameFacade.Instance.MonsterList[2]);
    }

    public void BuildPartD()
    {
        band.Add(GameFacade.Instance.MonsterList[3]);
    }

    public Band GetBand()
    {
        Band result = band;
        Reset();
        return result;
    }
}
