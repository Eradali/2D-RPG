using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeingTrees : MonoBehaviour
{

    public Tilemap tilemap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, 0.5f);
            Debug.Log("Fade in");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tilemap.color = new Color(tilemap.color.r, tilemap.color.g, tilemap.color.b, 1f);
            Debug.Log("Fade in");
        }
    }
}
