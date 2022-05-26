using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffectsCounter : MonoBehaviour
{
    [SerializeField] private List<Affector> affectors;
    [SerializeField] private Text counterText;

    private float counter;

    private void Awake()
    {
        foreach (var i in affectors)
        {
            i.OnAffect += IncreaseValue;
        }
    }

    private void IncreaseValue()
    {
        counter++;
        counterText.text = $"Used effects: {counter}";
    }

}
