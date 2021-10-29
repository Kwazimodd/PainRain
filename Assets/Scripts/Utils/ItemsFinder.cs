using System;
using System.Collections.Generic;
using UnityEngine;

public class Finder<T>: MonoBehaviour
{
    private List<BaseItem> visibleItemsList = new List<BaseItem>();

    private void OnInteraction()
    {
        if (visibleItemsList.Count == 0) return;
        visibleItemsList[0].gameObject.GetComponent<BaseItem>().Interaction();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && TryGetComponent(typeof(BaseItem), out Component component))
        {
            visibleItemsList.Add((BaseItem)component);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player") && TryGetComponent(typeof(BaseItem), out Component component))
        {
            visibleItemsList.Remove((BaseItem)component);
        }
    }
}