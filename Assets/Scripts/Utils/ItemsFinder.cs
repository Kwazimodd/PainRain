using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemsFinder: MonoBehaviour
{
    private List<GameObject> visibleItemsTagsList = new List<GameObject>();
    
    
    private void OnInteraction()
    {
        if (visibleItemsTagsList.Count == 0) return;
        visibleItemsTagsList[0].GetComponent<BaseItem>().Interaction();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.tag.Contains("Interactable"))
        {
            visibleItemsTagsList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Contains("Interactable") )
        {
            visibleItemsTagsList.Remove(other.gameObject);
        }
    }
}