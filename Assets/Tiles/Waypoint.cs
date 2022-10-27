using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject newTile;
    [SerializeField] GameObject cannonPrefab;
    [SerializeField] bool isPlaceable;

    void OnMouseDown() 
    {
        if(isPlaceable)
        {
        Instantiate(newTile, transform.position, Quaternion.identity);
        Instantiate(cannonPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        }
    }
}
