using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private List<Affector> affectors;

    [SerializeField] private int secondsToPerform;

    [SerializeField] private float previousSize;
    [SerializeField] private float currentSize;

    private void Awake()
    {
        foreach (var i in affectors)
        {
            i.OnAffect += Shake;
        }
    }

    private void Shake()
    {
        camera.orthographicSize = currentSize;
        ReturnPreviousSize();
    }

    private async void ReturnPreviousSize()
    {
        await System.Threading.Tasks.Task.Delay(secondsToPerform * 1000);
        camera.orthographicSize = previousSize;
    }
}
