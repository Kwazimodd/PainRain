using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerSorter : MonoBehaviour
{

    private List<Obstacle> obstacles= new List<Obstacle>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            Obstacle o = collision.GetComponent<Obstacle>();
            if (obstacles.Count == 0|| o.MySpriteRenderer.sortingOrder-1< transform.parent.GetComponent<SpriteRenderer>().sortingOrder)
            {
                transform.parent.GetComponent<SpriteRenderer>().sortingOrder = o.MySpriteRenderer.sortingOrder - 1;
                SpriteRenderer[] a = transform.GetComponentsInChildren<SpriteRenderer>();
                for (int i = 0; i < a.Length; i++)
                {
                    a[i].sortingOrder = o.MySpriteRenderer.sortingOrder - 1;
                }
            }
            obstacles.Add(o);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Obstacle o = collision.GetComponent<Obstacle>();

            obstacles.Remove(o);
            if (obstacles.Count == 0)
            { 
                transform.parent.GetComponent<SpriteRenderer>().sortingOrder = 200;
            }
            else
            {
                obstacles.Sort();
                transform.parent.GetComponent<SpriteRenderer>().sortingOrder = obstacles[0].MySpriteRenderer.sortingOrder - 1;
            }
        }
    }
}
