using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject newTile;
    [SerializeField] GameObject archerPrefab;
    [SerializeField] bool isPlaceable;

    void OnMouseDown() 
    {
        if(isPlaceable)
        {
        Instantiate(newTile, transform.position, Quaternion.identity);
        Instantiate(archerPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        }
    }
}
